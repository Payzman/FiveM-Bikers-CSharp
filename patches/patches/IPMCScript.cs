using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;
using NativeUI;

//The following line is very helpful for debugging purposes. It prints a message to the client command line (press F8 ingame)
//CitizenFX.Core.Debug.WriteLine("debug message");

namespace patches
{
    public class IPMCScript: BaseScript
    {
        IPMCMenus menus;

        public IPMCScript()
        {
            Player player = LocalPlayer;
            menus = new IPMCMenus(player);
            EventHandlers["testClient"] += new Action<dynamic>(testeventclient);
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
                // Toggle visibility of the interaction menu
                menus.ToggleInteractionMenu();
            }
        }

        void testeventclient(dynamic p)
        {
            Debug.WriteLine("DEBUG: testing a client event");
            Screen.ShowNotification("ay i just came from the server bro");
        }
    }
}
