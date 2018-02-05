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

        public Connection()
        {
            state = new NotConnectedState(this);
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
    }
}
