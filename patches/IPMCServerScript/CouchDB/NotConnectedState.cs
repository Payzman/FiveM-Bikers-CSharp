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
        // temporary
        bool temp = true;

        public override void HandleResponse(dynamic response, string reason, dynamic param)
        {
            Root root = new Root(response);
        }

        public override void Request()
        {
            // connectivity test
            if(temp)
            {
                ServerScript.TriggerEvent("Server:HttpGet", Strings.couchdb_url, Strings.reason_connectivity);
                temp = false;
            }
        }
    }
}
