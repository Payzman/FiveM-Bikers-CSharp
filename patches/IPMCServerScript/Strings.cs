namespace Server
{
    static class Strings
    {
        /* URLs */
        public const string couchdb_url = "http://127.0.0.1:5984"; /* running on localhost port 5984 */
        public const string all_dbs_url = couchdb_url + "/_all_dbs";
        public const string player_base = couchdb_url + "/players";
        public const string player_doc_url = player_base + "/_all_docs";
        public const string uuids = couchdb_url + "/_uuids";
        /* Reasons */
        public const string reason_connectivity = "connectivity test";
        public const string get_all_dbs = "get all databases";
        public const string get_player_docs = "Get Player Docs";
        public const string get_single_player_doc = "Get Single Player Document";
        public const string request_uuids = "Requested UUID";
    }
}
