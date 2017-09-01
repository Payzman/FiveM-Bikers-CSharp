using System.Collections.Generic;
using CitizenFX.Core;

namespace Server.CouchDB
{
    // The actual HTTP Requests and Responses are done by a lua script!
    class DatabaseCollection
    {
        Root root;
        public PlayerDatabase players;
        List<string> databases;

        public DatabaseCollection(Root root_db)
        {
            this.root = root_db;
        }
        
        public void HandleResponse(dynamic response, string reason, dynamic param)
        {
            switch(reason)
            {
                case Strings.reason_connectivity:
                    root.CheckConnectivity(response);
                    break;
                case Strings.get_all_dbs:
                    GetAllDatabases(response);
                    break;
                case Strings.get_player_docs:
                    players = new PlayerDatabase(response);
                    break;
                case Strings.get_single_player_doc:
                    players.AddPlayerDocument(response);
                    break;
                case Strings.request_uuids:
                    players.UploadNewUser(response, param);
                    break;
            }
        }

        private void GetAllDatabases(dynamic response)
        {
            databases = new List<string>();
            foreach (object obj in response)
            {
                databases.Add(response.ToString());
            }
        }

        public void Load()
        {
            /* get all player docs */
            ServerScript.TriggerEvent("Server:HttpGet", Strings.player_doc_url, Strings.get_player_docs);
            /* other docs might be added at a later stage */
        }
    }
}
