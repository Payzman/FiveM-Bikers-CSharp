namespace Client
{
    using NativeUI;
    using CitizenFX.Core.UI;
    using CitizenFX.Core;
    using CitizenFX.Core.Native;

    public class InteractionMenu
    {
        private Player player;
        private MenuPool menus;
        private UIMenu interactionMenu;

        public InteractionMenu(Player p)
        {
            menus = new MenuPool();
            AddInteractionMenu();
            player = p;
        }

        private void AddInteractionMenu()
        {
            interactionMenu = new UIMenu(Strings.MenuTitle.Interaction, 
                                          Strings.MenuSubtitle.Interaction);
            menus.Add(interactionMenu);
            AddInteractionMenuItems();

            interactionMenu.RefreshIndex();
        }

        private void AddInteractionMenuItems()
        {
            PatchesMenu patches_menu = new PatchesMenu(menus, 
                                                       interactionMenu);

            // default clothes menu is just for WIP
            UIMenuItem default_clothes = 
                new UIMenuItem(Strings.MenuItem.DefaultClothes);
            interactionMenu.AddItem(default_clothes);

            RecordingMenu recording_menu = 
                new RecordingMenu(menus, interactionMenu);

            UIMenuItem leave_session = 
                new UIMenuItem(Strings.MenuItem.LeaveSession);
            interactionMenu.AddItem(leave_session);

            interactionMenu.OnItemSelect += ItemHandler;
        }

        // Wrapper so it can easily be used in IPMCScript.cs
        public void ProcessMenus()
        {
            menus.ProcessMenus();
        }

        // TODO: A function which just does it for every menu will be created
        // eventually
        public void ToggleInteractionMenu()
        {
            interactionMenu.Visible = !interactionMenu.Visible;
        }

        public void ItemHandler(UIMenu sender, 
                                UIMenuItem selectedItem, 
                                int index)
        {
            switch(selectedItem.Text)
            {
                case Strings.MenuItem.DefaultClothes:
                    DefaultClothes();
                    break;
                case Strings.MenuItem.LeaveSession:
                    LeaveSession();
                    break;
                default:
                    break;
            }
        }

        public void DefaultClothes()
        {
            int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
            CitizenFX.Core.Ped ped = new CitizenFX.Core.Ped(player_ped_hash);
            ped.Style.SetDefaultClothes();
        }

        public void LeaveSession()
        {
            Function.Call(Hash.NETWORK_SESSION_LEAVE_SINGLE_PLAYER);
            Screen.ShowNotification(Strings.Notification.LeaveSession);
        }
    }
}
