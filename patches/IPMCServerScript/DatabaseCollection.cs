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
    }
}
