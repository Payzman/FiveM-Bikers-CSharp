using System.Collections.Generic;
using CitizenFX.Core;
using System;

namespace Server.CouchDB
{
    // The actual HTTP Requests and Responses are done by a lua script!
    class DatabaseCollection
    {
        CouchDBRoot root;
        Database players;
        List<string> databases;
        private List<PlayerDocument> users = new List<PlayerDocument>();
        
        public void HandleResponse(dynamic response, string reason, dynamic param)
        {
            switch(reason)
            {
                case Strings.reason_connectivity:
                    CheckConnectivity(response);
                    break;
                case Strings.get_all_dbs:
                    GetAllDatabases(response);
                    break;
                case Strings.get_player_docs:
                    CheckPlayerDatabase(response);
                    break;
                case Strings.get_single_player_doc:
                    GetPlayerDocument(response);
                    break;
                case Strings.request_uuids:
                    AddNewUser(response, param);
                    break;
            }
        }

        private void AddNewUser(dynamic response, dynamic param)
        {
            string uuid = response.uuids[0];
            Debug.WriteLine("Got a new Universal Unique Identifier: " + uuid);
            // UUIDs are currently only used for generating new documents (for new users...).
            // The implementation will change at a later stage but atm it's the easiest.
            string url = Strings.player_base + "/" + uuid;
            string reason = ""; /*i dont need a callback*/
            ServerScript.TriggerEvent("Server:HttpPut", url, param, reason);
        }

        private void GetPlayerDocument(dynamic response)
        {
            try
            {
                PlayerDocument player = new PlayerDocument(response);
                users.Add(player);
                Debug.WriteLine("Added new player with Endpoint = " + player.Endpoint + " and Name = " + player.Name);
            }
            catch (ArgumentException e)
            {
                Debug.WriteLine(e.Message + "\nThe database entry seems to be faulty. Please check the database");
            }
        }

        private void CheckPlayerDatabase(dynamic response)
        {
            players = new Database(response);
            ServerScript.TriggerEvent("Server:LoadedPlayerdocs");
        }

        private void GetAllDatabases(dynamic response)
        {
            databases = new List<string>();
            foreach (object obj in response)
            {
                databases.Add(response.ToString());
            }
        }

        private void CheckConnectivity(dynamic response)
        {
            root = new CouchDBRoot(response);
            ServerScript.TriggerEvent("Server:HttpGet", Strings.all_dbs_url, Strings.get_all_dbs);
            ServerScript.TriggerEvent("Server:Initialized");
        }

        public void Connect()
        {
            ServerScript.TriggerEvent("Server:HttpGet", Strings.couchdb_url, Strings.reason_connectivity);
        }

        public void Load()
        {
            ServerScript.TriggerEvent("Server:HttpGet", Strings.player_doc_url, Strings.get_player_docs);
        }

        public void GetPlayerInfo()
        {
            foreach(DatabaseRows document in players.rows)
            {
                string url = Strings.player_base + "/" + document.id.ToString();
                Debug.WriteLine("Getting entry from " + url);
                string reason = Strings.get_single_player_doc;
                ServerScript.TriggerEvent("Server:HttpGet", url, reason);
            }
        }

        public PlayerDocument PlayerInDatabase(int source)
        {
            Player player = new PlayerList()[source];
            PlayerDocument user = users.Find(x => (x.Name == player.Name
                                                && x.Endpoint == player.EndPoint));
            return user;
        }
    }
}
