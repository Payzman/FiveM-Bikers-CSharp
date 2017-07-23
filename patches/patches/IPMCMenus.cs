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
            // Add the submenu "set patch"
            set_patches = menus.AddSubMenu(interaction_menu, "Set Patch", "Sets your top rocker, center patch and bottom rocker");
            UIMenuItem national = new UIMenuItem("National");
            UIMenuItem del_perro = new UIMenuItem("Del Perro");
            UIMenuItem la_mesa = new UIMenuItem("La Mesa");
            UIMenuItem rancho = new UIMenuItem("Rancho");
            UIMenuItem paleto_bay = new UIMenuItem("Paleto Bay");
            set_patches.AddItem(national);
            set_patches.AddItem(del_perro);
            set_patches.AddItem(la_mesa);
            set_patches.AddItem(rancho);
            set_patches.AddItem(paleto_bay);
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
