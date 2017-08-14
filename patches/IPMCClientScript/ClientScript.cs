using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.UI;

//The following line is very helpful for debugging purposes. It prints a message to the client command line (press F8 ingame)
//CitizenFX.Core.Debug.WriteLine("debug message");

namespace Client
{
    public class ClientScript: BaseScript
    {
        Menu menus;

        public ClientScript()
        {
            Player player = LocalPlayer;
            menus = new Menu(player);
            EventHandlers["testClient"] += new Action<dynamic>(testeventclient);
            EventHandlers["playerSpawned"] += new Action<dynamic>(handlePlayerSpawn);
            // @ every tick (small time frame) the function OnTick is called.
            Tick += OnTick;
        }

        public async Task OnTick()
        {
            await Task.FromResult(0);
            menus.ProcessMenus();
            // Since FiveM does not use an interaction menu we can just override it here.
            if (Game.IsControlJustReleased(0, Control.InteractionMenu))
            {
                Debug.WriteLine("Oh you pressed M!");
                // Toggle visibility of the interaction menu
                menus.ToggleInteractionMenu();
            }
        }

        private void testeventclient(dynamic p)
        {
            Screen.ShowNotification("ay i just came from the server bro");
        }

        private void handlePlayerSpawn(dynamic spawn)
        {
            TriggerServerEvent("Server:InitPlayer");
        }
    }
}
