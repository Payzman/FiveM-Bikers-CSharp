using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeUI;

namespace patches
{
    class IPMCMenus
    {
        public static readonly String[] MENU_TITLES = 
        {
            "Interaction Menu",
            "Set Patch",
        };
        public static readonly String INTERACTION_MENU_SUBTITLE = "";
        public static readonly String SET_PATCHES_DESCRIPTION = "Sets your top rocker, center patch and bottom rocker";
        public static readonly String[] CHARTERS =
        {
            "National",
            "Paleto Bay",
            "Rancho",
            "Del Perro",
            "La Mesa",
        };


        private MenuPool menus;
        private UIMenu interaction_menu;
        private UIMenu set_patches;
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
            interaction_menu = new UIMenu(MENU_TITLES[0], INTERACTION_MENU_SUBTITLE);
            menus.Add(interaction_menu);
            // Add items for the interaction menu here:
            // Add the submenu "set patch"
            set_patches = menus.AddSubMenu(interaction_menu, MENU_TITLES[1], SET_PATCHES_DESCRIPTION);
            for(int i=0; i < CHARTERS.Length; i++)
            {
                UIMenuItem charter = new UIMenuItem(CHARTERS[i]);
                set_patches.AddItem(charter);
            }
            // Refresh the set patches menu
            set_patches.RefreshIndex();
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
