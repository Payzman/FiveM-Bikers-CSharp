using System;
using System.Threading.Tasks;
// Watch out because there is a CitizenFX Server and CitizenFX Client version!!
using CitizenFX.Core;
using Server.CouchDB;

namespace Server
{
    public class ServerScript : BaseScript
    {
        enum Db_State
        {
            not_connected,
            connected,
            loading, //Database -> Script
            updating, // Script -> Database
            idle,
        };
        Db_State database_state;

        DatabaseCollection database;
        Root couchdb;
        Connection connection;

        public ServerScript()
        {
            database_state = Db_State.not_connected;
            couchdb = new Root();
            database = new DatabaseCollection(couchdb);
            this.connection = new Connection();
            EventHandlers["Server:HttpResponse"] += new Action<dynamic, string, dynamic>(database.DeprecatedHandleResponse);
            EventHandlers["Server:Initialized"] += new Action(Initialized);
            EventHandlers["Server:LoadedPlayerdocs"] += new Action(LoadedPlayerDocs);
            EventHandlers["Server:playerConnected"] += new Action<int>(initPlayer);
            Tick += OnTick;
        }

        private async Task OnTick()
        {
            await Task.FromResult(0);
            connection.Request();
            switch(database_state)
            {
                case Db_State.connected:
                    database.players.GetPlayerInfo();
                    database_state = Db_State.idle;
                    break;
                case Db_State.loading:
                    database.Load();
                    break;
            }
        }

        void initPlayer(int source)
        {
            Player player = new PlayerList()[source];
            PlayerDocument user = database.players.PlayerInDatabase(source);
            if(user != null)
            {
                // Load player information
                Debug.WriteLine("We know that dude");
            }
            else
            {
                database.players.AddNewUser(player);
            }
        }

        void Initialized()
        {
            database_state = Db_State.loading;
        }

        void LoadedPlayerDocs()
        {
            // provisional -> connected state is after ALL databases were loaded in.... just playerdatabase for now.
            database_state = Db_State.connected;
        }
    }
}
