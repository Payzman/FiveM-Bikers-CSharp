using System.Collections.Generic;
using NativeUI;
using CitizenFX.Core.UI;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace Client
{
    class Menu
    {
        Player player;
        private MenuPool menus;
        private UIMenu interaction_menu;
        private UIMenu set_patches;
        private UIMenu recording;
        // Creates all the interactive menus and calls them.
        // Constructor: Initialization
        public Menu(Player p)
        {
            // Create menu pool
            menus = new MenuPool();
            AddInteractionMenu();
            player = p;
        }

        private void AddInteractionMenu()
        {
            // Add additional menus here
            interaction_menu = new UIMenu(Strings.MenuTitleInteraction, Strings.MenuSubtitleInteraction);
            menus.Add(interaction_menu);
            AddInteractionMenuItems();
            // Refresh the interaction menu
            interaction_menu.RefreshIndex();
        }

        private void AddInteractionMenuItems()
        {
            AddSetPatchesMenu();
            // default clothes menu is just for WIP
            UIMenuItem default_clothes = new UIMenuItem(Strings.MenuItemDefaultClothes);
            interaction_menu.AddItem(default_clothes);
            // Recording submenu
            AddRecordingMenu();
            // Leave Session
            UIMenuItem leave_session = new UIMenuItem(Strings.MenuItemLeaveSession);
            interaction_menu.AddItem(leave_session);
            // Define the interaction menu item handler
            interaction_menu.OnItemSelect += ItemHandler;
        }

        private void AddSetPatchesMenu()
        {
            // Add items for the interaction menu here:
            // Add the submenu "set patch"
            set_patches = menus.AddSubMenu(interaction_menu, Strings.MenuTitlePatch, Strings.MenuDescriptionSetPatch);
            List<dynamic> charters = new List<dynamic>()
            {
                Strings.CharterNameNational,
                Strings.CharterNamePaletoBay,
                Strings.CharterNameRancho,
                Strings.CharterNameDelPerro,
                Strings.CharterNameLaMesa,
            };
            UIMenuListItem set_patches2 = new UIMenuListItem(Strings.MenuItemCharter, charters, 1, Strings.MenuDescriptionSetCharter);
            set_patches.AddItem(set_patches2);
            // Try to use a handler to handle user input (choosing buttons etc.)
            set_patches.OnListChange += SetPatchHandler;
            // Refresh the set patches menu
            set_patches.RefreshIndex();
        }

        private void AddRecordingMenu()
        {
            recording = menus.AddSubMenu(interaction_menu, Strings.MenuTitleRecording, Strings.MenuDescriptionRecording);
            UIMenuItem start_recording   = new UIMenuItem(Strings.MenuItemStartRecording,   Strings.MenuDescriptionStartRecording);
            UIMenuItem stop_recording    = new UIMenuItem(Strings.MenuItemStopRecording,    Strings.MenuDescriptionStopRecording);
            UIMenuItem discard_recording = new UIMenuItem(Strings.MenuItemDiscardRecording, Strings.MenuDescriptionDiscardRecording);
            recording.AddItem(start_recording);
            recording.AddItem(stop_recording);
            recording.AddItem(discard_recording);
            recording.OnItemSelect += RecordingHandler;
        }

        // Wrapper so it can easily be used in IPMCScript.cs
        public void ProcessMenus()
        {
            menus.ProcessMenus();
        }

        // TODO: A function which just does it for every menu will be created eventually
        public void ToggleInteractionMenu()
        {
            interaction_menu.Visible = !interaction_menu.Visible;
        }

        public void SetPatchHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if(sender == set_patches)
            {
                if(selectedItem.Text == Strings.MenuItemCharter)
                {
                    Ped ipmcped = new Ped();
                    ipmcped.ApplyBottomRocker(index);
                }
            }
        }

        public void RecordingHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            switch (selectedItem.Text)
            {
                case Strings.MenuItemStartRecording:
                    Function.Call(Hash._START_RECORDING, 1);
                    break;
                case Strings.MenuItemStopRecording:
                    Function.Call(Hash._STOP_RECORDING_AND_SAVE_CLIP);
                    Screen.ShowNotification(Strings.NotificationSaveClip);
                    break;
                case Strings.MenuItemDiscardRecording:
                    Function.Call(Hash._STOP_RECORDING_AND_DISCARD_CLIP);
                    Screen.ShowNotification(Strings.NotificationDiscardClip);
                    break;
            }
        }

        public void ItemHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            switch(selectedItem.Text)
            {
                case Strings.MenuItemDefaultClothes:
                    int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
                    CitizenFX.Core.Ped ped = new CitizenFX.Core.Ped(player_ped_hash);
                    ped.Style.SetDefaultClothes();
                    break;
                case Strings.MenuItemLeaveSession:
                    Function.Call(Hash.NETWORK_SESSION_LEAVE_SINGLE_PLAYER);
                    Screen.ShowNotification(Strings.NotificationLeaveSession);
                    break;
                default:
                    break;
            }
        }
    }
}
