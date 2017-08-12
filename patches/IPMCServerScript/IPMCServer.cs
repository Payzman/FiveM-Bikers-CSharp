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
        bool DB_INITIALIZED;

        IPMCDatabase database;

        public IPMCServer()
        {
            EventHandlers["test"] += new Action<dynamic>(doSomething);
            EventHandlers["IPMC:InitPlayer"] += new Action(initPlayer);
            database = new IPMCDatabase();
            EventHandlers["IPMC:HttpResponse"] += new Action<dynamic, string>(database.HandleResponse);
            EventHandlers["Server:Initialized"] += new Action(Initialized);
            Tick += OnTick;
        }

        private async Task OnTick()
        {
            await Task.FromResult(0);
            if(!DB_INITIALIZED)
            {
                Debug.WriteLine("Trying to connect to CouchDB...");
                database.Connect();
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
            Debug.WriteLine("Couch DB connection successfull!");
            DB_INITIALIZED = true;
        }
    }
}
