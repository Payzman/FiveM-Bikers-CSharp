namespace Server.CouchDB
{
    using CitizenFX.Core;
    using System.Collections.Generic;

    public class ConnectedState : State
    {
        private bool temp = true;

        public ConnectedState(Connection connection) : base(connection)
        {
        }

        public override void HandleResponse(dynamic response, string reason, dynamic param)
        {
            if (reason == Strings.get_player_docs)
            {
                connection.Players = new PlayerDatabase(response);
            }
        }

        public override void Request()
        {
            if(temp)
            {
                ServerScript.TriggerEvent("Server:HttpGet", Strings.player_doc_url, Strings.get_player_docs);
                temp = false;
            }
        }
    }
}
