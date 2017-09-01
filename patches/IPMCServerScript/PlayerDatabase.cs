using System;
using System.Dynamic;
using System.Collections.Generic;
using CitizenFX.Core;

namespace Server.CouchDB
{
    class PlayerDatabase : Database
    {
        public List<PlayerDocument> users = new List<PlayerDocument>();

        public PlayerDatabase(dynamic obj) : base((ExpandoObject)obj)
        {
            ServerScript.TriggerEvent("Server:LoadedPlayerdocs");
        }

        public void GetPlayerInfo()
        {
            foreach (DatabaseRows document in rows)
            {
                string url = Strings.player_base + "/" + document.id.ToString();
                Debug.WriteLine("Getting entry from " + url);
                string reason = Strings.get_single_player_doc;
                ServerScript.TriggerEvent("Server:HttpGet", url, reason);
            }
        }

        public void AddPlayerDocument(dynamic response)
        {
            try
            {
                PlayerDocument player = new PlayerDocument(response);
                Debug.WriteLine(player.ToString());
                users.Add(player);
                Debug.WriteLine("Added new player with Endpoint = " + player.Endpoint + " and Name = " + player.Name);
            }
            catch (ArgumentException e)
            {
                Debug.WriteLine(e.Message + "\nThe database entry seems to be faulty. Please check the database");
            }
        }

        public PlayerDocument PlayerInDatabase(int source)
        {
            Player player = new PlayerList()[source];
            PlayerDocument user = users.Find(x => (x.Name == player.Name
                                                && x.Endpoint == player.EndPoint));
            return user;
        }

        public void AddNewUser(Player player)
        {
            Debug.WriteLine("Create a new User");
            string url = Strings.uuids;
            string reason = Strings.request_uuids;
            PlayerDocument newplayer = new PlayerDocument(player.Name, player.EndPoint);
            ServerScript.TriggerEvent("Server:HttpGet", url, reason, newplayer);
        }

        public void UploadNewUser(dynamic response, dynamic param)
        {
            string uuid = response.uuids[0];
            Debug.WriteLine("Got a new Universal Unique Identifier: " + uuid);
            // UUIDs are currently only used for generating new documents (for new users...).
            // The implementation will change at a later stage but atm it's the easiest.
            string url = Strings.player_base + "/" + uuid;
            string reason = ""; /*i dont need a callback*/
            ServerScript.TriggerEvent("Server:HttpPut", url, param, reason);
        }
    }
}
