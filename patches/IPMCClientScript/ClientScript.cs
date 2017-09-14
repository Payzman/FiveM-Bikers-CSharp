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
        private InteractionMenu menus;

        public ClientScript()
        {
            Player player = LocalPlayer;
            menus = new InteractionMenu(player);
            Tick += OnTick;
        }

        /* Every Tick this one is called */
        public async Task OnTick()
        {
            await Task.FromResult(0);
            menus.ProcessMenus();

            // Since FiveM does not use an interaction menu we can just
            // override it here.
            if (Game.IsControlJustReleased(0, Control.InteractionMenu))
            {
                menus.ToggleInteractionMenu();
            }
        }
    }
}
