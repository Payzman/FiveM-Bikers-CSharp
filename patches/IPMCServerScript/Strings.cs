using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    static class Strings
    {
        /* URLs */
        public const string couchdb_url = "http://127.0.0.1:5984"; /* running on localhost port 5984 */
        public const string all_dbs_url = couchdb_url + "/_all_dbs";
        public const string player_base = couchdb_url + "/players";
        public const string player_doc_url = player_base + "/_all_docs";
        /* Reasons */
        public const string reason_connectivity = "connectivity test";
        public const string get_all_dbs = "get all databases";
        public const string get_player_docs = "Get Player Docs";
    }
}
