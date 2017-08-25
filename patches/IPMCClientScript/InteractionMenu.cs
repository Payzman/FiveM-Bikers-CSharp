using NativeUI;
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
        private UIMenu recording;
        // Creates all the interactive menus and calls them.
        // Constructor: Initialization
        public InteractionMenu(Player p)
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
            PatchesMenu patches_menu = new PatchesMenu(menus, interaction_menu);
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
                    DefaultClothes();
                    break;
                case Strings.MenuItemLeaveSession:
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
            Screen.ShowNotification(Strings.NotificationLeaveSession);
        }
    }
}
