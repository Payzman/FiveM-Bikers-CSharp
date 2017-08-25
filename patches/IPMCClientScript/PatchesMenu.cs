using NativeUI;
using CitizenFX.Core.UI;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace Client
{
    class PatchesMenu
    {
        private MenuPool pool;
        private UIMenu parent;
        private UIMenu set_patches;

        public PatchesMenu(MenuPool pool, UIMenu parent)
        {
            this.pool = pool;
            this.parent = parent;
            AddSetPatchesMenu();
        }

        private void AddSetPatchesMenu()
        {
            // Add items for the interaction menu here:
            // Add the submenu "set patch"
            set_patches = pool.AddSubMenu(parent, Strings.MenuTitlePatch, Strings.MenuDescriptionSetPatch);
            UIMenuListItem set_patches2 = new UIMenuListItem(Strings.MenuItemCharter, Strings.charters, 1, Strings.MenuDescriptionSetCharter);
            set_patches.AddItem(set_patches2);
            // Try to use a handler to handle user input (choosing buttons etc.)
            set_patches.OnListChange += SetPatchHandler;
            // Refresh the set patches menu
            set_patches.RefreshIndex();
        }

        public void SetPatchHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (sender == set_patches)
            {
                if (selectedItem.Text == Strings.MenuItemCharter)
                {
                    Ped ipmcped = new Ped();
                    ipmcped.ApplyBottomRocker(index);
                }
            }
        }
    }
}
