namespace Client
{
    using System;
    using System.Collections.Generic;
    using CitizenFX.Core;
    using CitizenFX.Core.Native;
    using CitizenFX.Core.UI;

    public class Ped
    {
        private int playerPedHash;
        private int customOverlayHash;
        private int bikerDlcHash;
        private List<Patch> patchList;

        public Ped()
        {
            this.customOverlayHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.Custom);
            this.bikerDlcHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.BikerDlc);
            this.InitPatches();
            this.patchList = new List<Patch>();
        }

        public List<Patch> Backpatch { get; set; }

        public List<Patch> Title { get; set; }

        public void AddPatch(Patch patch)
        {
            Debug.WriteLine("Adding patch " + patch.ToString());
            this.patchList.Add(patch);
            this.UpdateDecorations();
        }

        public void RemovePatch(Patch patch)
        {
            Debug.WriteLine("Removing patch " + patch.ToString());
            this.patchList.Remove(patch);
            this.UpdateDecorations();
        }

        public void UpdateDecorations()
        {
            /* You cannot enable or disable single decorations. The only way
             * is to disable all decorations and reenable all decorations you
             * want on the PC */
            
            this.playerPedHash = Function.Call<int>(Hash.PLAYER_PED_ID);
            this.ClearDecorations();
            foreach (Patch patch in this.Backpatch)
            {
                patch.Update(this.playerPedHash);
            }

            foreach (Patch patch in this.Title)
            {
                patch.Update(this.playerPedHash);
            }

            foreach (Patch patch in this.patchList)
            {
                patch.Update(this.playerPedHash);
            }
        }

        private void InitPatches()
        {
            this.Backpatch = new List<Patch>()
            {
                new Patch(this.customOverlayHash, "none", "none", "All"),
                new Patch(this.customOverlayHash, Strings.BackpatchTextHash.National, Strings.CharterName.National, "Charter"),
                new Patch(this.customOverlayHash, Strings.BackpatchTextHash.PaletoBay, Strings.CharterName.PaletoBay, "Charter"),
                new Patch(this.customOverlayHash, Strings.BackpatchTextHash.Rancho, Strings.CharterName.Rancho, "Charter"),
                new Patch(this.customOverlayHash, Strings.BackpatchTextHash.DelPerro, Strings.CharterName.DelPerro, "Charter"),
                new Patch(this.customOverlayHash, Strings.BackpatchTextHash.LaMesa, Strings.CharterName.LaMesa, "Charter"),
            };
            this.Title = new List<Patch>()
            {
                new Patch(this.bikerDlcHash, "none", "none", "All"),
                new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.President, Strings.Title.President, "Title"),
                new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.VicePresident, Strings.Title.VicePresident, "Title"),
                new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.SgtAtArms, Strings.Title.SeargentAtArms, "Title"),
                new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.RoadCaptain, Strings.Title.RoadCaptain, "Title"),
                new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.Enforcer, Strings.Title.Enforcer, "Title"),
                new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.Prospect, Strings.Title.Prospect, "Title"),
            };
        }

        private void ClearDecorations()
        {
            Function.Call(Hash.CLEAR_PED_DECORATIONS, this.playerPedHash);
        }
    }
}
