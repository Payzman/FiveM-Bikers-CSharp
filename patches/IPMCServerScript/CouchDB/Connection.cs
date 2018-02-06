using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.CouchDB
{
    class Connection
    {
        private State state;
        public PlayerDatabase players;
        private DatabaseCollection dbcoll;
        private Root root;

        public Connection(Root couchdb)
        {
            state = new NotConnectedState(this);
            this.root = couchdb;
            dbcoll = new DatabaseCollection(root);
        }

        public void ChangeState(State state)
        {
            this.state = state;
        }

        public void Request()
        {
            state.Request();
        }

        public void HandleResponse()
        {
            state.HandleResponse();
        }

        public void DeprecatedHandleResponse(dynamic response, string reason, dynamic param)
        {
            switch (reason)
            {
                case Strings.reason_connectivity:
                    root.CheckConnectivity(response);
                    break;
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
