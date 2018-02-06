using System.Collections.Generic;
using CitizenFX.Core;

namespace Server.CouchDB
{
    // The actual HTTP Requests and Responses are done by a lua script!
    class DatabaseCollection
    {
        private Root root;
        public PlayerDatabase players;

        public DatabaseCollection(Root root_db)
        {
            this.root = root_db;
        }
        
        public void DeprecatedHandleResponse(dynamic response, string reason, dynamic param)
        {
        }

        public void Load()
        {
            /* get all player docs */
            ServerScript.TriggerEvent("Server:HttpGet", Strings.player_doc_url, Strings.get_player_docs);
            /* other docs might be added at a later stage */
        }
    }
}
