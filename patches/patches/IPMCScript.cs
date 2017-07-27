using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.UI;
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
            // @ every tick (small time frame) the function OnTick is called.
            Tick += OnTick;
        }

        public async Task OnTick()
        {
            menus.ProcessMenus();
            // Since FiveM does not use an interaction menu we can just override it here.
            if (Game.IsControlJustReleased(0, Control.InteractionMenu))
            {
                // Toggle visibility of the interaction menu
                menus.ToggleInteractionMenu();
            }
        }
    }
}
