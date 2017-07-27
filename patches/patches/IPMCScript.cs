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
        bool wears_default = false;

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
            if(!wears_default)
            {
                int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
                Ped ped = new Ped(player_ped_hash);
                ped.Style.SetDefaultClothes();
                wears_default = true;
            }
        }
    }
}
