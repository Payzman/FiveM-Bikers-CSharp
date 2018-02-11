namespace Server.CouchDB
{
    using CitizenFX.Core;

    public class ConnectedState : State
    {
        public ConnectedState(Connection connection) : base(connection)
        {
        }

        bool temp = true;

        public override void HandleResponse(dynamic response, string reason, dynamic param)
        {
            //Implementation pending
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
