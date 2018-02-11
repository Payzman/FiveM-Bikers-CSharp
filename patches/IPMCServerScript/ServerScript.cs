using System;
using System.Threading.Tasks;
// Watch out because there is a CitizenFX Server and CitizenFX Client version!!
using CitizenFX.Core;
using Server.CouchDB;

namespace Server
{
    public class ServerScript : BaseScript
    {        
        Connection connection;

        public ServerScript()
        {
            this.connection = new Connection();
            EventHandlers["Server:HttpResponse"] += new Action<dynamic, string, dynamic>(connection.HandleResponse);
            EventHandlers["Server:playerConnected"] += new Action<int>(initPlayer);
            Tick += OnTick;
        }

        private async Task OnTick()
        {
            await Task.FromResult(0);
            connection.Request();
        }

        void initPlayer(int source)
        {
            Player player = new PlayerList()[source];
            PlayerDocument user = connection.Players.PlayerInDatabase(source);
            if(user != null)
            {
                // Load player information
                Debug.WriteLine("We know that dude");
            }
            else
            {
                connection.Players.AddNewUser(player);
            }
        }
    }
}
