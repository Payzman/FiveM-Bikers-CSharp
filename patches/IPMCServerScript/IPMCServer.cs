using System;
using System.Threading.Tasks;
// Watch out because there is a CitizenFX Server and CitizenFX Client version!!
using CitizenFX.Core;

namespace IPMCServerScript
{
    public class IPMCServer : BaseScript
    {
        public IPMCServer()
        {
            EventHandlers["test"] += new Action<dynamic>(doSomething);
            DbTest().Wait();
        }

        void doSomething(dynamic p)
        {
            PlayerList list = new PlayerList();
            foreach (Player player in list)
            {
                player.TriggerEvent("testClient");
            }
        }

        static async Task DbTest()
        {
            await Task.FromResult(0);
        }
    }
}
