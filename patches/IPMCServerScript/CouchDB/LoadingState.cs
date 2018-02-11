using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.CouchDB
{
    class LoadingState : State
    {
        public LoadingState(Connection connection) : base(connection)
        {
        }

        public override void HandleResponse(dynamic response, string reason, dynamic param)
        {
            //throw new NotImplementedException();
        }

        public override void Request()
        {
            //throw new NotImplementedException();
        }
    }
}
