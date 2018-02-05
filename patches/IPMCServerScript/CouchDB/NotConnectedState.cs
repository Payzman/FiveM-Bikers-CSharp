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

        }

        public override void Request()
        {
            // connectivity test
            ServerScript.TriggerEvent("Server:HttpGet", Strings.couchdb_url, Strings.reason_connectivity);
        }
    }
}
