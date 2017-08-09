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
        public IPMCServer()
        {
            EventHandlers["test"] += new Action<dynamic>(doSomething);
            EventHandlers["playerSpawned"] += new Action<dynamic>(initCouchDb);
        }
        
        void doSomething(dynamic p)
        {
            TriggerEvent("httpGet");
            PlayerList list = new PlayerList();
            foreach (Player player in list)
            {
                player.TriggerEvent("testClient");
            }
        }

        void initCouchDb(dynamic spawn)
        {
            Debug.WriteLine("INITCOUCHDB: Initializing Couch Database");
            Debug.WriteLine("INITCOUCHDB: Spawn information = " + spawn);
        }
    }
}
