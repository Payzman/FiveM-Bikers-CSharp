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
            // when a new user joins the server for the first time:
            if(reason == Strings.request_uuids)
            {
                connection.Players.UploadNewUser(response, param);
            }
        }

        public override void Request() { }
    }
}
