using System;
using System.Threading.Tasks;
// Watch out because there is a CitizenFX Server and CitizenFX Client version!!
using CitizenFX.Core;
using System.Net;
using System.IO;

namespace IPMCServerScript
{
    public class IPMCServer : BaseScript
    {
        enum Db_State
        {
            not_connected,
            connected,
            loading,
            updating,
        };
        Db_State database_state;

        IPMCDatabase database;

        public IPMCServer()
        {
            database_state = Db_State.not_connected;
            EventHandlers["test"] += new Action<dynamic>(doSomething);
            EventHandlers["IPMC:InitPlayer"] += new Action(initPlayer);
            database = new IPMCDatabase();
            EventHandlers["IPMC:HttpResponse"] += new Action<dynamic, string>(database.HandleResponse);
            EventHandlers["Server:Initialized"] += new Action(Initialized);
            EventHandlers["Server:LoadedPlayerdocs"] += new Action(LoadedPlayerDocs);
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

        void doSomething(dynamic p)
        {
            PlayerList list = new PlayerList();
            foreach (Player player in list)
            {
                player.TriggerEvent("testClient");
            }
        }

        void initPlayer()
        {
            // do stuff
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
