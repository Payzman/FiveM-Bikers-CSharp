﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeUI;
using CitizenFX.Core.UI;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace patches
{
    class IPMCMenus
    {
        Player player;
        private MenuPool menus;
        private UIMenu interaction_menu;
        private UIMenu set_patches;
        private UIMenu recording;
        // Creates all the interactive menus and calls them.
        // Constructor: Initialization
        public IPMCMenus(Player p)
        {
            // Create menu pool
            menus = new MenuPool();
            AddInteractionMenu();
            player = p;
        }

        private void AddInteractionMenu()
        {
            // Add additional menus here
            interaction_menu = new UIMenu(IPMCStrings.MenuTitleInteraction, IPMCStrings.MenuSubtitleInteraction);
            menus.Add(interaction_menu);
            AddInteractionMenuItems();
            // Refresh the interaction menu
            interaction_menu.RefreshIndex();
        }

        private void AddInteractionMenuItems()
        {
            AddSetPatchesMenu();
            // default clothes menu is just for WIP
            UIMenuItem default_clothes = new UIMenuItem(IPMCStrings.MenuItemDefaultClothes);
            interaction_menu.AddItem(default_clothes);
            // Recording submenu
            AddRecordingMenu();
            // Leave Session
            UIMenuItem leave_session = new UIMenuItem(IPMCStrings.MenuItemLeaveSession);
            interaction_menu.AddItem(leave_session);
            // Simples test: Saving and Loading a file
            UIMenuItem save = new UIMenuItem("save");
            interaction_menu.AddItem(save);
            UIMenuItem load = new UIMenuItem("load");
            interaction_menu.AddItem(load);
            // Define the interaction menu item handler
            interaction_menu.OnItemSelect += ItemHandler;
        }

        private void AddSetPatchesMenu()
        {
            // Add items for the interaction menu here:
            // Add the submenu "set patch"
            set_patches = menus.AddSubMenu(interaction_menu, IPMCStrings.MenuTitlePatch, IPMCStrings.MenuDescriptionSetPatch);
            List<dynamic> charters = new List<dynamic>()
            {
                IPMCStrings.CharterNameNational,
                IPMCStrings.CharterNamePaletoBay,
                IPMCStrings.CharterNameRancho,
                IPMCStrings.CharterNameDelPerro,
                IPMCStrings.CharterNameLaMesa,
            };
            UIMenuListItem set_patches2 = new UIMenuListItem(IPMCStrings.MenuItemCharter, charters, 1, IPMCStrings.MenuDescriptionSetCharter);
            set_patches.AddItem(set_patches2);
            // Try to use a handler to handle user input (choosing buttons etc.)
            set_patches.OnListChange += SetPatchHandler;
            // Refresh the set patches menu
            set_patches.RefreshIndex();
        }

        private void AddRecordingMenu()
        {
            recording = menus.AddSubMenu(interaction_menu, IPMCStrings.MenuTitleRecording, IPMCStrings.MenuDescriptionRecording);
            UIMenuItem start_recording   = new UIMenuItem(IPMCStrings.MenuItemStartRecording,   IPMCStrings.MenuDescriptionStartRecording);
            UIMenuItem stop_recording    = new UIMenuItem(IPMCStrings.MenuItemStopRecording,    IPMCStrings.MenuDescriptionStopRecording);
            UIMenuItem discard_recording = new UIMenuItem(IPMCStrings.MenuItemDiscardRecording, IPMCStrings.MenuDescriptionDiscardRecording);
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
                if(selectedItem.Text == IPMCStrings.MenuItemCharter)
                {
                    IPMCPed ipmcped = new IPMCPed();
                    ipmcped.ApplyBottomRocker(index);
                }
            }
        }

        public void RecordingHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            switch (selectedItem.Text)
            {
                case IPMCStrings.MenuItemStartRecording:
                    Function.Call(Hash._START_RECORDING, 1);
                    break;
                case IPMCStrings.MenuItemStopRecording:
                    Function.Call(Hash._STOP_RECORDING_AND_SAVE_CLIP);
                    Screen.ShowNotification(IPMCStrings.NotificationSaveClip);
                    break;
                case IPMCStrings.MenuItemDiscardRecording:
                    Function.Call(Hash._STOP_RECORDING_AND_DISCARD_CLIP);
                    Screen.ShowNotification(IPMCStrings.NotificationDiscardClip);
                    break;
            }
        }

        public void ItemHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            switch(selectedItem.Text)
            {
                case IPMCStrings.MenuItemDefaultClothes:
                    int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
                    Ped ped = new Ped(player_ped_hash);
                    ped.Style.SetDefaultClothes();
                    break;
                case IPMCStrings.MenuItemLeaveSession:
                    Function.Call(Hash.NETWORK_SESSION_LEAVE_SINGLE_PLAYER);
                    Screen.ShowNotification(IPMCStrings.NotificationLeaveSession);
                    break;
                case "save":
                    string text = "Hello, file system!";
                    System.IO.File.WriteAllText(@"./hello.txt", text);
                    break;
                case "load":
                    string read = System.IO.File.ReadAllText(@"./hello.txt");
                    Screen.ShowNotification(read);
                    break;
                default:
                    break;
            }
        }
    }
}
