﻿using NativeUI;
using CitizenFX.Core.UI;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace Client
{
    class InteractionMenu
    {
        Player player;
        private MenuPool menus;
        private UIMenu interaction_menu;

        public InteractionMenu(Player p)
        {
            // Create menu pool
            menus = new MenuPool();
            AddInteractionMenu();
            player = p;
        }

        private void AddInteractionMenu()
        {
            interaction_menu = new UIMenu(Strings.MenuTitle.Interaction, 
                                          Strings.MenuSubtitle.Interaction);
            menus.Add(interaction_menu);
            AddInteractionMenuItems();

            interaction_menu.RefreshIndex();
        }

        private void AddInteractionMenuItems()
        {
            PatchesMenu patches_menu = new PatchesMenu(menus, 
                                                       interaction_menu);
            // default clothes menu is just for WIP
            UIMenuItem default_clothes = 
                new UIMenuItem(Strings.MenuItem.DefaultClothes);
            interaction_menu.AddItem(default_clothes);

            RecordingMenu recording_menu = 
                new RecordingMenu(menus, interaction_menu);

            UIMenuItem leave_session = 
                new UIMenuItem(Strings.MenuItem.LeaveSession);
            interaction_menu.AddItem(leave_session);

            interaction_menu.OnItemSelect += ItemHandler;
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
            interaction_menu.Visible = !interaction_menu.Visible;
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
