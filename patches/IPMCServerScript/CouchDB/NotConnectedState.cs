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

        public override void HandleResponse(dynamic response, string reason, dynamic param)
        {
            if(reason == Strings.reason_connectivity)
            {
                Root root = new Root(response);
                connection.ChangeState(new ConnectedState(connection));
            }
        }

        public override void Request()
        {
            ServerScript.TriggerEvent("Server:HttpGet", Strings.couchdb_url, Strings.reason_connectivity);
        }
    }
}
