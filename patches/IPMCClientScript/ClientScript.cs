using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.UI;

/* 
 * The following line is very helpful for debugging purposes. It prints a 
 * message to the client command line (press F8 ingame)
 * CitizenFX.Core.Debug.WriteLine("debug message");
 */

namespace Client
{
    public class ClientScript: BaseScript
    {
        InteractionMenu menus;

        public ClientScript()
        {
            Player player = LocalPlayer;
            menus = new InteractionMenu(player);
            // @ every tick (small time frame) the function OnTick is called.
            Tick += OnTick;
        }

        public async Task OnTick()
        {
            await Task.FromResult(0);
            menus.ProcessMenus();
            // Since FiveM does not use an interaction menu we can just
            // override it here.
            if (Game.IsControlJustReleased(0, Control.InteractionMenu))
            {
                // Toggle visibility of the interaction menu
                menus.ToggleInteractionMenu();
            }
        }
    }
}
