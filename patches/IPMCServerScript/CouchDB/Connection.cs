namespace Server.CouchDB
{
    public class Connection
    {
        private State state;
        private PlayerDatabase players;
        private DatabaseCollection dbcoll;

        public PlayerDatabase Players { get => players; set => players = value; }

        public Connection()
        {
            state = new NotConnectedState(this);
            dbcoll = new DatabaseCollection();
        }

        public void ChangeState(State state)
        {
            this.state = state;
        }

        public void Request()
        {
            state.Request();
        }

        public void HandleResponse(dynamic response, string reason, dynamic param)
        {
            state.HandleResponse(response, reason, param);
            DeprecatedHandleResponse(response, reason, param);
        }

        public void DeprecatedHandleResponse(dynamic response, string reason, dynamic param)
        {
            switch (reason)
            {
                case Strings.get_player_docs:
                    players = new PlayerDatabase(response);
                    break;
                case Strings.get_single_player_doc:
                    players.AddPlayerDocument(response);
                    break;
                case Strings.request_uuids:
                    players.UploadNewUser(response, param);
                    break;
            }
        }

        public void Load()
        {
            ServerScript.TriggerEvent("Server:HttpGet", Strings.player_doc_url, Strings.get_player_docs);
        }
    }
}
