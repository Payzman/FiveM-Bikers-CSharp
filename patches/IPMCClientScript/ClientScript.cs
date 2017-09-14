/* 
 * The following line is very helpful for debugging purposes. It prints a 
 * message to the client command line (press F8 ingame)
 * CitizenFX.Core.Debug.WriteLine("debug message");
 */
namespace Client
{
    using System.Threading.Tasks;
    using CitizenFX.Core;

    public class ClientScript: BaseScript
    {
        private InteractionMenu menus;

        public ClientScript()
        {
            Player player = LocalPlayer;
            this.menus = new InteractionMenu(player);
            this.Tick += this.OnTick;
        }

        /* Every Tick this one is called */
        public async Task OnTick()
        {
            await Task.FromResult(0);
            this.menus.ProcessMenus();

            // Since FiveM does not use an interaction menu we can just
            // override it here.
            if (Game.IsControlJustReleased(0, Control.InteractionMenu))
            {
                this.menus.ToggleInteractionMenu();
            }
        }
    }
}
