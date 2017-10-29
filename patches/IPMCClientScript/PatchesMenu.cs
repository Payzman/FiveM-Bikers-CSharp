namespace Client
{
    using NativeUI;

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
            this.ped = new Ped();
            this.AddSetPatchesMenu();
        }

        public void SetPatchHandler(
            UIMenu sender, 
            UIMenuItem selectedItem, 
            int index)
        {
            if (sender == this.setPatches)
            {
                if (selectedItem.Text == Strings.MenuItem.Charter)
                {
                    this.ped.ApplyBottomRocker(index);
                }
                else if (selectedItem.Text == Strings.MenuItem.Titles)
                {
                    this.ped.ApplyTitleBarPatch(index);
                }
            }
        }

        private void AddSetPatchesMenu()
        {
            this.setPatches = this.pool.AddSubMenu(
                this.parent, 
                Strings.MenuTitle.Patch, 
                Strings.MenuDescription.SetPatch);

            this.setPatches.AddItem(MenuItems.Backpatch);

            this.setPatches.AddItem(MenuItems.BarTitle);

            this.setPatches.OnListChange += this.SetPatchHandler;
            this.setPatches.OnCheckboxChange += this.CheckboxHandler;

            this.setPatches.RefreshIndex();
        }

        private void AddPvpCommendationPatches()
        {
            this.setPatches.AddItem(MenuItems.Pow);
            this.setPatches.AddItem(MenuItems.Mayhem);
            this.setPatches.AddItem(MenuItems.Guardian);
            this.setPatches.AddItem(MenuItems.Boogeyman);
            this.setPatches.AddItem(MenuItems.Valor);
        }

        private void CheckboxHandler(
            UIMenu sender, 
            UIMenuCheckboxItem checkboxItem, 
            bool checkboxChecked)
        {
            if (checkboxItem.Text == "Boogeyman")
            {
                this.ped.SetBoogeymanPatch(checkboxChecked);
            }
            else if (checkboxItem.Text == "Guardian")
            {
                this.ped.SetGuardianPatch(checkboxChecked);
            }
            else if (checkboxItem.Text == "Mayhem")
            {
                this.ped.SetMayhemPatch(checkboxChecked);
            }
            else if (checkboxItem.Text == "Prisoner of War")
            {
                this.ped.SetPowPatch(checkboxChecked);
            }
            else if (checkboxItem.Text == "Valor")
            {
                this.ped.SetValorPatch(checkboxChecked);
            }
        }
    }
}
