using NativeUI;
using CitizenFX.Core.UI;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;

namespace Client
{
    public class PatchesMenu
    {
        private MenuPool pool;
        private UIMenu parent;
        private UIMenu setPatches;
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
            setPatches = pool.AddSubMenu(parent, Strings.MenuTitle.Patch, Strings.MenuDescription.SetPatch);

            UIMenuListItem set_patches2 = new UIMenuListItem(Strings.MenuItem.Charter, Strings.charters, 1, Strings.MenuDescription.SetCharter);
            setPatches.AddItem(set_patches2);

            UIMenuListItem bar_title = new UIMenuListItem(Strings.MenuItem.Titles, Strings.titles, 1, Strings.MenuDescription.SetTitle);
            setPatches.AddItem(bar_title);

            UIMenuCheckboxItem boogeyman = new UIMenuCheckboxItem("Boogeyman", false, "PVP Commendation Boogeyman");
            setPatches.AddItem(boogeyman);

            UIMenuCheckboxItem guardian = new UIMenuCheckboxItem("Guardian", false, "PVP Commendation Guardian");
            setPatches.AddItem(guardian);

            UIMenuCheckboxItem mayhem = new UIMenuCheckboxItem("Mayhem", false, "PVP Commendation Mayhem");
            setPatches.AddItem(mayhem);

            UIMenuCheckboxItem pow = new UIMenuCheckboxItem("Prisoner of War", false, "PVP Commendation Prisoner of War");
            setPatches.AddItem(pow);

            UIMenuCheckboxItem valor = new UIMenuCheckboxItem("Valor", false, "PVP Commendation Valor");
            setPatches.AddItem(valor);

            setPatches.OnListChange += SetPatchHandler;
            setPatches.OnCheckboxChange += CheckboxHandler;

            setPatches.RefreshIndex();
        }

        private void CheckboxHandler(UIMenu sender, UIMenuCheckboxItem checkboxItem, bool checkboxChecked)
        {
            if (checkboxItem.Text == "Boogeyman")
            {
                ped.SetBoogeymanPatch(checkboxChecked);
            }
            else if (checkboxItem.Text == "Guardian")
            {
                ped.SetGuardianPatch(checkboxChecked);
            }
            else if (checkboxItem.Text == "Mayhem")
            {
                ped.SetMayhemPatch(checkboxChecked);
            }
            else if (checkboxItem.Text == "Prisoner of War")
            {
                ped.SetPowPatch(checkboxChecked);
            }
            else if (checkboxItem.Text == "Valor")
            {
                ped.SetValorPatch(checkboxChecked);
            }
        }

        public void SetPatchHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (sender == setPatches)
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
