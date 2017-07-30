using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Watch out because there is a CitizenFX Server and CitizenFX Client version!!
using CitizenFX.Core;
using System.Data.SQLite;

namespace IPMCServerScript
{
    public class IPMCServer : BaseScript
    {
        public IPMCServer()
        {
            EventHandlers["test"] += new Action<dynamic>(doSomething);
            //Test for SQLite
            SQLiteConnection.CreateFile("ipmc5m.sqlite");
        }

        void doSomething(dynamic p)
        {
            PlayerList list = new PlayerList();
            foreach (Player player in list)
            {
                player.TriggerEvent("testClient");
            }
        }
    }
}
