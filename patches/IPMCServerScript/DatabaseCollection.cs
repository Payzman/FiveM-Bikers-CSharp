using System.Collections.Generic;
using CitizenFX.Core;

namespace Server.CouchDB
{
    // The actual HTTP Requests and Responses are done by a lua script!
    class DatabaseCollection
    {
        private PlayerDatabase players;

        public DatabaseCollection()
        {

        }

        public PlayerDatabase Players { get => players; set => players = value; }
    }
}
