namespace Client
{
    using System.Collections.Generic;
    using CitizenFX;
    using CitizenFX.Core;
    using NativeUI;

    public class PatchesMenu
    {
        private MenuPool pool;
        private UIMenu parent;
        private UIMenu setPatches;
        private Ped ped;
        private Patch.Collection patchCollection;

        public PatchesMenu(MenuPool pool, UIMenu parent)
        {
            this.pool = pool;
            this.parent = parent;
            this.ped = new Ped();
            this.AddSetPatchesMenu();
            this.patchCollection = new Patch.Collection();
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
            if (selectedItem.Text == Strings.MenuItem.Charter)
            {
                for (int i = 0; i < this.ped.Backpatch.Count; i++)
                {
                    this.ped.Backpatch[i].Active = i == index;
                }
            }
            else if (selectedItem.Text == Strings.MenuItem.Titles)
            {
                for (int i = 0; i < this.ped.Title.Count; i++)
                {
                    this.ped.Title[i].Active = i == index;
                }
            }

            this.ped.UpdateDecorations();
        }

        private void CheckboxHandler(
            UIMenu sender, 
            UIMenuCheckboxItem checkboxItem, 
            bool checkboxChecked)
        {
            Patch patch = this.patchCollection.List.Find(item => item.Name == checkboxItem.Text);
            if (checkboxChecked)
            {
                this.ped.AddPatch(patch);
            }
            else
            {
                this.ped.RemovePatch(patch);
            }
            
            this.ped.UpdateDecorations();
        }
    }
}
