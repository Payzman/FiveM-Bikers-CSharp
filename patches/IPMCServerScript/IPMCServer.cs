using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Watch out because there is a CitizenFX Server and CitizenFX Client version!!
using CitizenFX.Core;

namespace IPMCServerScript
{
    public class IPMCServer : BaseScript
    {
        public IPMCServer()
        {
            Debug.WriteLine("DEBUG: add server event for 'test'");
            EventHandlers["test"] += new Action<dynamic, Player>(doSomething);
        }

        void doSomething(dynamic p, Player player)
        {
            Debug.WriteLine("DEBUG: trigger client event");
            player.TriggerEvent("test");
        }
    }
}
