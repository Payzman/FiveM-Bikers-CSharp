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
            this.setPatches.MouseEdgeEnabled = false; // might be a fix for the rotating camera bug

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
            UIMenuListItem selectedItem,
            int index)
        {
            List<Patch> patchList = this.patchCollection.List.FindAll(item => item.Group == "All" || item.Group == selectedItem.Text);
            foreach (Patch patch in patchList)
            {
                this.ped.RemovePatch(patch);
            }

            string patchname = selectedItem.IndexToItem(index);
            Patch patchToAdd = patchList.Find(item => item.Name == patchname);
            this.ped.AddPatch(patchToAdd);

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
