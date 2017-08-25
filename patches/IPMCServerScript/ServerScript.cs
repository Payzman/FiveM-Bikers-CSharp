using System;
using System.Threading.Tasks;
// Watch out because there is a CitizenFX Server and CitizenFX Client version!!
using CitizenFX.Core;

namespace Server
{
    public class ServerScript : BaseScript
    {
        enum Db_State
        {
            not_connected,
            connected,
            loading,
            updating,
        };
        Db_State database_state;

        Database database;

        public ServerScript()
        {
            database_state = Db_State.not_connected;
            database = new Database();
            EventHandlers["Server:HttpResponse"] += new Action<dynamic, string>(database.HandleResponse);
            EventHandlers["Server:Initialized"] += new Action(Initialized);
            EventHandlers["Server:LoadedPlayerdocs"] += new Action(LoadedPlayerDocs);
            EventHandlers["Server:playerConnected"] += new Action(initPlayer);
            Tick += OnTick;
        }

        private async Task OnTick()
        {
            await Task.FromResult(0);
            switch(database_state)
            {
                case Db_State.not_connected:
                    database.Connect();
                    break;
                case Db_State.connected:
                    //do some stuff
                    break;
                case Db_State.loading:
                    database.Load();
                    break;
            }
        }

        void initPlayer()
        {
            Debug.WriteLine("New Player Connected");
            Debug.WriteLine("Current Players");
            PlayerList list = new PlayerList();
            foreach(Player player in list)
            {
                Debug.WriteLine("Name = " + player.Name);
                Debug.WriteLine("Endpoint = " + player.EndPoint);
                Debug.WriteLine("Handle = " + player.Handle);
                Debug.WriteLine("Identifiers");
                foreach(string identifier in player.Identifiers)
                {
                    Debug.WriteLine(identifier);
                }
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
