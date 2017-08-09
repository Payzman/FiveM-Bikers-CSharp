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
        }

        // This is an old test from me: I just tried to trigger this event on
        // the client side ("test") which triggers a clientSideEvent with a 
        // notification - not import for the http-stuff
        void doSomething(dynamic p)
        {
            TriggerEvent("httpGet");
            PlayerList list = new PlayerList();
            foreach (Player player in list)
            {
                player.TriggerEvent("testClient");
            }
        }
    }
}
