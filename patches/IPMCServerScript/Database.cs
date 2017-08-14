﻿using System.Collections.Generic;
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
        }
    }
    // The actual HTTP Requests and Responses are done by a lua script!
    class Database
    {
        CouchDBRoot root;
        PlayerDatabase players;
        List<string> databases;
        List<PlayerDocument> users;

        public void HandleResponse(dynamic response, string reason)
        {
            switch(reason)
            {
                case Strings.reason_connectivity:
                    root = new CouchDBRoot(response);
                    ServerScript.TriggerEvent("Server:HttpGet", Strings.all_dbs_url, Strings.get_all_dbs);
                    ServerScript.TriggerEvent("Server:Initialized");
                    break;
                case Strings.get_all_dbs:
                    databases = new List<string>();
                    foreach(object obj in response)
                    {
                        databases.Add(response.ToString());
                    }
                    break;
                case Strings.get_player_docs:
                    players = new PlayerDatabase(response);
                    ServerScript.TriggerEvent("Server:LoadedPlayerdocs");
                    break;
            }
        }

        public void Connect()
        {
            ServerScript.TriggerEvent("Server:HttpGet", Strings.couchdb_url, Strings.reason_connectivity);
        }

        public void Load()
        {
            ServerScript.TriggerEvent("Server:HttpGet", Strings.player_doc_url, Strings.get_player_docs);
        }
    }
}
