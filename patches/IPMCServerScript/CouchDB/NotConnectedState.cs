using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.CouchDB
{
    class NotConnectedState : State
    {
        public NotConnectedState(Connection connection) : base(connection) { }

        public override void HandleResponse()
        {
            throw new NotImplementedException();
        }

        public override void Request()
        {
            throw new NotImplementedException();
        }
    }
}
