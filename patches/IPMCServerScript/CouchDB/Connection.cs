namespace Server.CouchDB
{
    public class Connection
    {
        private State state;
        private PlayerDatabase players;

        public Connection()
        {
            this.state = new NotConnectedState(this);
        }

        public PlayerDatabase Players { get => this.players; set => this.players = value; }

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
                case Strings.request_uuids:
                    players.UploadNewUser(response, param);
                    break;
            }
        }
    }
}
