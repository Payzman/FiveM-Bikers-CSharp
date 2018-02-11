using System;

namespace Server.CouchDB
{
    class IdleState : State
    {
        public IdleState(Connection connection) : base(connection)
        {
        }

        public override void HandleResponse(dynamic response, string reason, dynamic param)
        {
            throw new NotImplementedException();
        }

        public override void Request()
        {
            throw new NotImplementedException();
        }
    }
}
