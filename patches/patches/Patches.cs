using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using NativeUI;

namespace patches
{
    public class Patches: BaseScript
    {
        public Patches()
        {
            // @ every tick (small time frame) the function OnTick is called.
            Tick += OnTick;
        }

        public async Task OnTick()
        {
            // Since FiveM does not use an interaction menu we can just override it here.
            if (Game.IsControlJustReleased(0, Control.InteractionMenu))
            {
                CitizenFX.Core.Debug.WriteLine("This is an example Debug message");
                Screen.ShowNotification("opening interaction menu...");
            }
        }
    }
}
