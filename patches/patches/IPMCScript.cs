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
        MenuPool menus;
        UIMenu interaction_menu;

        public IPMCScript()
        {
            menus = new MenuPool();
            // Add additional menus here
            interaction_menu = new UIMenu("Interaction Menu","");
            menus.Add(interaction_menu);
            // Add items for the interaction menu here:
            var set_patch = new UIMenuItem("Set Patch");
            interaction_menu.AddItem(set_patch);

            // Refresh the interaction menu
            interaction_menu.RefreshIndex();
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
                interaction_menu.Visible = !interaction_menu.Visible;
            }
        }
    }
}
