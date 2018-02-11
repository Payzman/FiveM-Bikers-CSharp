using System;

namespace Server.CouchDB
{
    class ConnectedState : State
    {
        public ConnectedState(Connection connection) : base(connection)
        {
        }

        public override void HandleResponse(dynamic response, string reason, dynamic param)
        {
            throw new NotImplementedException();
        }

        public override void Request()
        {
            ServerScript.TriggerEvent("Server:HttpGet", Strings.player_doc_url, Strings.get_player_docs);
        }
    }
}
