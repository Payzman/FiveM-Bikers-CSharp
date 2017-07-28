using System;
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
        public static readonly String[] MENU_TITLES =
        {
            "Interaction Menu",
            "Change Patch",
            "Charter",
        };
        public static readonly String[] MENU_SUBTITLES =
        {
            "",
            "",
        };
        public static readonly String[] MENU_DESCRIPTIONS =
        {
            "Options to change what patches and badges you wear",
            "Set your charter"
        };
        public static readonly String[] CHARTERS =
        {
            "National",
            "Paleto Bay",
            "Rancho",
            "Del Perro",
            "La Mesa",
        };

        Player player;
        private MenuPool menus;
        private UIMenu interaction_menu;
        private UIMenu set_patches;
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
            interaction_menu = new UIMenu(MENU_TITLES[0], MENU_SUBTITLES[0]);
            menus.Add(interaction_menu);
            AddInteractionMenuItems();
            // Refresh the interaction menu
            interaction_menu.RefreshIndex();
        }

        private void AddInteractionMenuItems()
        {
            // Add items for the interaction menu here:
            // Add the submenu "set patch"
            set_patches = menus.AddSubMenu(interaction_menu, MENU_TITLES[1], MENU_DESCRIPTIONS[0]);
            // Other idea: list
            List<dynamic> charters = new List<dynamic>(CHARTERS);
            UIMenuListItem set_patches2 = new UIMenuListItem(MENU_TITLES[2], charters, 1, MENU_DESCRIPTIONS[1]);
            set_patches.AddItem(set_patches2);
            // Try to use a handler to handle user input (choosing buttons etc.)
            set_patches.OnListChange += ItemListHandler;
            // Refresh the set patches menu
            set_patches.RefreshIndex();
            UIMenuItem default_clothes = new UIMenuItem("Default Clothes");
            interaction_menu.AddItem(default_clothes);
            interaction_menu.OnItemSelect += ItemHandler;
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

        public void ItemListHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if(sender == set_patches)
            {
                // Might find a better way to do this meh...
                if(selectedItem.Text == MENU_TITLES[2])
                {
                    IPMCPed ipmcped = new IPMCPed();
                    ipmcped.ApplyBottomRocker(index);
                }
            }
        }

        public void ItemHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (selectedItem.Text == "Default Clothes")
            {
                int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
                Ped ped = new Ped(player_ped_hash);
                ped.Style.SetDefaultClothes();
            }
        }
    }
}
