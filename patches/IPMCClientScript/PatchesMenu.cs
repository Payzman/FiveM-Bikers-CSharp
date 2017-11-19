namespace Client
{
    using CitizenFX;
    using CitizenFX.Core;
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

        private void AddSetPatchesMenu()
        {
            this.setPatches = this.pool.AddSubMenu(
                this.parent, 
                Strings.MenuTitle.Patch, 
                Strings.MenuDescription.SetPatch);

            this.setPatches.AddItem(MenuItems.Backpatch);

            this.setPatches.AddItem(MenuItems.BarTitle);

            this.AddPvpCommendationPatches();

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

        private void SetPatchHandler(
            UIMenu sender,
            UIMenuItem selectedItem,
            int index)
        {
            if (sender == this.setPatches)
            {
                if (selectedItem.Text == Strings.MenuItem.Charter)
                {
                    for (int i = 0; i < this.ped.Backpatch.Count; i++)
                    {
                        if (i == index)
                        {
                            this.ped.Backpatch[i].Active = true;
                        }
                        else
                        {
                            this.ped.Backpatch[i].Active = false;
                        }
                    }
                }
                else if (selectedItem.Text == Strings.MenuItem.Titles)
                {
                    for (int i = 0; i < this.ped.Title.Count; i++)
                    {
                        if (i == index)
                        {
                            this.ped.Backpatch[i].Active = true;
                        }
                        else
                        {
                            this.ped.Backpatch[i].Active = false;
                        }
                    }
                }
            }

            this.ped.UpdateDecorations();
        }

        private void CheckboxHandler(
            UIMenu sender, 
            UIMenuCheckboxItem checkboxItem, 
            bool checkboxChecked)
        {
            switch (checkboxItem.Text)
            {
                case Strings.MenuItem.Boogeyman:
                    this.ped.Boogeyman.Active = checkboxChecked;
                    break;
                case Strings.MenuItem.Guardian:
                    this.ped.Guardian.Active = checkboxChecked;
                    break;
                case Strings.MenuItem.Mayhem:
                    this.ped.Mayhem.Active = checkboxChecked;
                    break;
                case Strings.MenuItem.Pow:
                    this.ped.Pow.Active = checkboxChecked;
                    break;
                case Strings.MenuItem.Valor:
                    this.ped.Valor.Active = checkboxChecked;
                    break;
                default:
                    break;
            }
            
            this.ped.UpdateDecorations();
        }
    }
}
