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

            UIMenuListItem backpatch = new UIMenuListItem(
                Strings.MenuItem.Charter, 
                Strings.Charters(), 
                1, 
                Strings.MenuDescription.SetCharter);
            this.setPatches.AddItem(backpatch);

            UIMenuListItem bar_title = new UIMenuListItem(
                Strings.MenuItem.Titles, 
                Strings.Titles(), 
                1, 
                Strings.MenuDescription.SetTitle);
            this.setPatches.AddItem(bar_title);

            this.setPatches.OnListChange += this.SetPatchHandler;
            this.setPatches.OnCheckboxChange += this.CheckboxHandler;

            this.setPatches.RefreshIndex();
        }

        private void AddPvpCommendationPatches()
        {
            UIMenuCheckboxItem boogeyman = new UIMenuCheckboxItem( 
                Strings.MenuItem.Boogeyman, false, 
                Strings.MenuDescription.Boogeyman);
            UIMenuCheckboxItem guardian = new UIMenuCheckboxItem(
                Strings.MenuItem.Guardian, false,
                Strings.MenuDescription.Guardian);
            UIMenuCheckboxItem mayhem = new UIMenuCheckboxItem(
                Strings.MenuItem.Mayhem, false,
                Strings.MenuDescription.Mayhem);
            UIMenuCheckboxItem pow = new UIMenuCheckboxItem(
                Strings.MenuItem.Pow, false,
                Strings.MenuDescription.Pow);
            UIMenuCheckboxItem valor = new UIMenuCheckboxItem(
                Strings.MenuItem.Valor, false,
                Strings.MenuDescription.Valor);

            this.setPatches.AddItem(pow);
            this.setPatches.AddItem(mayhem);
            this.setPatches.AddItem(guardian);
            this.setPatches.AddItem(boogeyman);
            this.setPatches.AddItem(valor);
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
