﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeUI;

namespace patches
{
    class IPMCMenus
    {
        MenuPool menus;
        UIMenu interaction_menu;
        UIMenu set_patches;
        // Creates all the interactive menus and calls them.
        // Constructor: Initialization
        public IPMCMenus()
        {
            // Create menu pool
            menus = new MenuPool();
            AddInteractionMenu();
        }

        private void AddInteractionMenu()
        {
            // Add additional menus here
            interaction_menu = new UIMenu("Interaction Menu", "");
            menus.Add(interaction_menu);
            // Add items for the interaction menu here:
            var set_patch = new UIMenuItem("Set Patch", "Sets your Top Rocker, Center Patch and Bottom Rocker");
            interaction_menu.AddItem(set_patch);
            // Add the submenu "set patch"
            menus.AddSubMenu(interaction_menu, "Set Patch", "Sets your top rocker, center patch and bottom rocker");
            // Refresh the interaction menu
            interaction_menu.RefreshIndex();
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
    }
}
