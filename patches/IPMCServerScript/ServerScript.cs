using System;
using System.Threading.Tasks;
// Watch out because there is a CitizenFX Server and CitizenFX Client version!!
using CitizenFX.Core;
using System.Collections.Generic;

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

        public ServerScript()
        {
            database_state = Db_State.not_connected;
            database = new DatabaseCollection();
            EventHandlers["Server:HttpResponse"] += new Action<dynamic, string>(database.HandleResponse);
            EventHandlers["Server:Initialized"] += new Action(Initialized);
            EventHandlers["Server:LoadedPlayerdocs"] += new Action(LoadedPlayerDocs);
            EventHandlers["Server:playerConnected"] += new Action<int>(initPlayer);
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
                    database.GetPlayerInfo();
                    database_state = Db_State.idle;
                    break;
                case Db_State.loading:
                    database.Load();
                    break;
            }
        }

        void initPlayer(int source)
        {
            PlayerList playerlist = new PlayerList();
            foreach(Player player in playerlist)
            {
                if(player.Handle.Equals(source))
                {
                    PlayerDocument user = database.users.Find(x => (x.Name == player.Name 
                                                                    && x.Endpoint == player.EndPoint));
                    if(user != null)
                    {
                        Debug.WriteLine("We know that dude");
                    }
                    else
                    {
                        Debug.WriteLine("Who is that guy?");
                    }
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
