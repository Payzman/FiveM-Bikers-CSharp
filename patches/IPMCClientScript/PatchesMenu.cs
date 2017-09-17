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

            UIMenuCheckboxItem boogeyman = new UIMenuCheckboxItem(
                Strings.MenuItem.Boogeyman, 
                false, 
                "PVP Commendation Boogeyman");
            this.setPatches.AddItem(boogeyman);

            UIMenuCheckboxItem guardian = new UIMenuCheckboxItem(
                "Guardian", 
                false, 
                "PVP Commendation Guardian");
            this.setPatches.AddItem(guardian);

            UIMenuCheckboxItem mayhem = new UIMenuCheckboxItem(
                "Mayhem", 
                false, 
                "PVP Commendation Mayhem");
            this.setPatches.AddItem(mayhem);

            UIMenuCheckboxItem pow = new UIMenuCheckboxItem(
                "Prisoner of War", 
                false, 
                "PVP Commendation Prisoner of War");
            this.setPatches.AddItem(pow);

            UIMenuCheckboxItem valor = new UIMenuCheckboxItem(
                "Valor", 
                false, 
                "PVP Commendation Valor");
            this.setPatches.AddItem(valor);

            this.setPatches.OnListChange += this.SetPatchHandler;
            this.setPatches.OnCheckboxChange += this.CheckboxHandler;

            this.setPatches.RefreshIndex();
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
