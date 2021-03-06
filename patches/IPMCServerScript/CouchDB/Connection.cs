﻿namespace Server.CouchDB
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
            this.state.Request();
        }

        public void HandleResponse(dynamic response, string reason, dynamic param)
        {
            state.HandleResponse(response, reason, param);
        }
    }
}
