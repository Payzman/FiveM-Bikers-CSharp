using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Web;

namespace IPMCServerScript
{
    class PlayerDatabase
    {
        public int total_rows { get; set; }
        public int offset { get; set; }
        public List<object> rows { get; set; }

        public PlayerDatabase(dynamic obj)
        {
            total_rows = obj.total_rows;
            offset = obj.offset;
            rows = obj.rows;
            Debug.WriteLine("Couch DB: Updated player database with:");
            Debug.WriteLine("\t total rows: " + total_rows);
            Debug.WriteLine("\t offset: " + offset);
        }
    }
    // The actual HTTP Requests and Responses are done by a lua script!
    class IPMCDatabase
    {
        // static stuff
        static string url = "http://127.0.0.1:5984";
        static string all_dbs = url + "/_all_dbs";
        // dynamic stuff
        IPMCCouchDbRoot root;
        PlayerDatabase players;
        List<string> databases;
        List<PlayerDocument> users;

        public void HandleResponse(dynamic response, string reason)
        {
            switch(reason)
            {
                case "connectivity test":
                    root = new IPMCCouchDbRoot(response);
                    IPMCServer.TriggerEvent("IPMC:HttpGet", all_dbs, "get all databases");
                    Debug.WriteLine("Couch DB: initialized (Version " + root.version + ")");
                    IPMCServer.TriggerEvent("Server:Initialized");
                    break;
                case "get all databases":
                    databases = new List<string>();
                    foreach(object obj in response)
                    {
                        databases.Add(response.ToString());
                    }
                    break;
                case "get player docs":
                    players = new PlayerDatabase(response);
                    IPMCServer.TriggerEvent("Server:LoadedPlayerdocs");
                    break;
            }
        }

        public void Connect()
        {
            IPMCServer.TriggerEvent("IPMC:HttpGet", url, "connectivity test");
        }

        public void Load()
        {
            string all_player_docs = url + "/players/_all_docs";
            string reason = "get player docs";
            IPMCServer.TriggerEvent("IPMC:HttpGet", all_player_docs, reason);
        }
    }
}
