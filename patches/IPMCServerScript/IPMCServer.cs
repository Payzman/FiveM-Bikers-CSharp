using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Watch out because there is a CitizenFX Server and CitizenFX Client version!!
using CitizenFX.Core;
using System.Data.SQLite;
using System.IO;

namespace IPMCServerScript
{
    public class IPMCServer : BaseScript
    {
        SQLiteConnection dbConnection;
        public IPMCServer()
        {
            EventHandlers["test"] += new Action<dynamic>(doSomething);
            //Test for SQLite
            if(!File.Exists("database/ipmc5m.sqlite"))
            {
                SQLiteConnection.CreateFile("database/ipmc5m.sqlite");
            }
            dbConnection = new SQLiteConnection("Data Source=database/ipmc5m.sqlite;Version=3");
            dbConnection.Open();
            //Do something
            dbConnection.Close();
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
