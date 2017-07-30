using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.UI;

namespace IPMCServerScript
{
    public class IPMCServer : BaseScript
    {
        public IPMCServer()
        {
            Debug.WriteLine("DEBUG: add server event for 'test'");
            EventHandlers["test"] += new Action<dynamic>(doSomething);
        }

        void doSomething(dynamic p)
        {
            Debug.WriteLine("DEBUG: trigger client event");
            TriggerEvent("testClient");
        }
    }
}
