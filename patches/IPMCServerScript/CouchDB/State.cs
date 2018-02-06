using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.CouchDB
{
    abstract class State
    {
        protected Connection connection;

        public State(Connection connection)
        {
            this.connection = connection;
        }

        public abstract void Request();

        public abstract void HandleResponse(dynamic response, string reason, dynamic param);
    }
}
