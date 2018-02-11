namespace Server.CouchDB
{
    using CitizenFX.Core;
    using System.Collections.Generic;

    public class ConnectedState : State
    {
        public ConnectedState(Connection connection) : base(connection)
        {
        }

        public override void HandleResponse(dynamic response, string reason, dynamic param)
        {
            if (reason == Strings.get_player_docs)
            {
                connection.Players = new PlayerDatabase(response);
                connection.ChangeState(new LoadingState(connection));
            }
        }

        public override void Request()
        {
            ServerScript.TriggerEvent("Server:HttpGet", Strings.player_doc_url, Strings.get_player_docs);
        }
    }
}
