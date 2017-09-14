using NativeUI;
using CitizenFX.Core.UI;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;

namespace Client
{
    class PatchesMenu
    {
        private MenuPool pool;
        private UIMenu parent;
        private UIMenu set_patches;
        private Ped ped;

        public PatchesMenu(MenuPool pool, UIMenu parent)
        {
            this.pool = pool;
            this.parent = parent;
            ped = new Ped();
            AddSetPatchesMenu();
        }

        private void AddSetPatchesMenu()
        {
            // Add items for the interaction menu here:
            // Add the submenu "set patch"
            set_patches = pool.AddSubMenu(parent, Strings.MenuTitle.Patch, Strings.MenuDescriptionSetPatch);
            // Set Patch on back
            UIMenuListItem set_patches2 = new UIMenuListItem(Strings.MenuItem.Charter, Strings.charters, 1, Strings.MenuDescriptionSetCharter);
            set_patches.AddItem(set_patches2);
            // Set title bar patch
            UIMenuListItem bar_title = new UIMenuListItem(Strings.MenuItem.Titles, Strings.titles, 1, Strings.MenuDescriptionSetTitle);
            set_patches.AddItem(bar_title);

            UIMenuCheckboxItem boogeyman = new UIMenuCheckboxItem("Boogeyman", false, "PVP Commendation Boogeyman");
            set_patches.AddItem(boogeyman);

            UIMenuCheckboxItem guardian = new UIMenuCheckboxItem("Guardian", false, "PVP Commendation Guardian");
            set_patches.AddItem(guardian);

            UIMenuCheckboxItem mayhem = new UIMenuCheckboxItem("Mayhem", false, "PVP Commendation Mayhem");
            set_patches.AddItem(mayhem);

            UIMenuCheckboxItem pow = new UIMenuCheckboxItem("Prisoner of War", false, "PVP Commendation Prisoner of War");
            set_patches.AddItem(pow);

            UIMenuCheckboxItem valor = new UIMenuCheckboxItem("Valor", false, "PVP Commendation Valor");
            set_patches.AddItem(valor);
            // Use a handler to handle user input (choosing buttons etc.)
            set_patches.OnListChange += SetPatchHandler;
            set_patches.OnCheckboxChange += CheckboxHandler;
            // Refresh the set patches menu
            set_patches.RefreshIndex();
        }

        private void CheckboxHandler(UIMenu sender, UIMenuCheckboxItem checkboxItem, bool Checked)
        {
            if (checkboxItem.Text == "Boogeyman")
            {
                ped.SetBoogeymanPatch(Checked);
            }
            else if (checkboxItem.Text == "Guardian")
            {
                ped.SetGuardianPatch(Checked);
            }
            else if (checkboxItem.Text == "Mayhem")
            {
                ped.SetMayhemPatch(Checked);
            }
            else if (checkboxItem.Text == "Prisoner of War")
            {
                ped.SetPowPatch(Checked);
            }
            else if (checkboxItem.Text == "Valor")
            {
                ped.SetValorPatch(Checked);
            }
        }

        public void SetPatchHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (sender == set_patches)
            {
                if (selectedItem.Text == Strings.MenuItem.Charter)
                {
                    ped.ApplyBottomRocker(index);
                }
                else if (selectedItem.Text == Strings.MenuItem.Titles)
                {
                    ped.ApplyTitleBarPatch(index);
                }
            }
        }
    }
}
