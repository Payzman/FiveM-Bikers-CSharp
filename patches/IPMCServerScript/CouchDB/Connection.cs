using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.CouchDB
{
    class Connection
    {
        private State state;
        public PlayerDatabase players;
        private DatabaseCollection dbcoll;

        public Connection(Root couchdb)
        {
            state = new NotConnectedState(this);
            dbcoll = new DatabaseCollection(couchdb);
        }

        public void ChangeState(State state)
        {
            this.state = state;
        }

        public void Request()
        {
            state.Request();
        }

        public void HandleResponse()
        {
            state.HandleResponse();
        }

        public void DeprecatedHandleResponse(dynamic response, string reason, dynamic param)
        {
            dbcoll.DeprecatedHandleResponse(response, reason, param);
            players = dbcoll.players;
        }

        public void Load()
        {
            dbcoll.Load();
        }
    }
}
