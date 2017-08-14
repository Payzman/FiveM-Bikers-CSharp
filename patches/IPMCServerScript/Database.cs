using System.Collections.Generic;
using CitizenFX.Core;

namespace Server
{
    public class Value
    {
        public string rev { get; set; }

        public Value(dynamic obj)
        {
            rev = obj.rev;
        }
    }

    public class Row
    {
        public string id { get; set; }
        public string key { get; set; }
        public Value value { get; set; }

        public Row(dynamic obj)
        {
            id = obj.id;
            key = obj.key;
            value = new Value(obj.value);
        }
    }

    class PlayerDatabase
    {
        public int total_rows { get; set; }
        public int offset { get; set; }
        public List<Row> rows { get; set; }

        public PlayerDatabase(dynamic obj)
        {
            total_rows = obj.total_rows;
            offset = obj.offset;
            rows = new List<Row>();
            foreach(dynamic row in obj.rows)
            {
                rows.Add(new Row(row));
            }
            Debug.WriteLine("Couch DB: Updated player database with:");
            Debug.WriteLine("\t  total rows: " + total_rows);
            Debug.WriteLine("\t  offset: " + offset);
        }
    }
    // The actual HTTP Requests and Responses are done by a lua script!
    class Database
    {
        // static stuff
        static string url = "http://127.0.0.1:5984";
        static string all_dbs = url + "/_all_dbs";
        // dynamic stuff
        CouchDBRoot root;
        PlayerDatabase players;
        List<string> databases;
        List<PlayerDocument> users;

        public void HandleResponse(dynamic response, string reason)
        {
            switch(reason)
            {
                case "connectivity test":
                    root = new CouchDBRoot(response);
                    ServerScript.TriggerEvent("Server:HttpGet", all_dbs, "get all databases");
                    Debug.WriteLine("Couch DB: initialized (Version " + root.version + ")");
                    ServerScript.TriggerEvent("Server:Initialized");
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
                    ServerScript.TriggerEvent("Server:LoadedPlayerdocs");
                    break;
            }
        }

        public void Connect()
        {
            ServerScript.TriggerEvent("Server:HttpGet", url, "connectivity test");
        }

        public void Load()
        {
            string all_player_docs = url + "/players/_all_docs";
            string reason = "get player docs";
            ServerScript.TriggerEvent("Server:HttpGet", all_player_docs, reason);
        }
    }
}
