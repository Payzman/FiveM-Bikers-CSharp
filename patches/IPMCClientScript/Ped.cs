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
            this.patchList = new List<Patch>();
        }

        public List<Patch> Title { get; set; }

        public void AddPatch(Patch patch)
        {
            Debug.WriteLine("Adding patch " + patch.Name);
            this.patchList.Add(patch);
            this.UpdateDecorations();
        }

        public void RemovePatch(Patch patch)
        {
            Debug.WriteLine("Removing patch " + patch.Name);
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
            foreach (Patch patch in this.patchList)
            {
                patch.Apply(this.playerPedHash);
            }
        }

        private void ClearDecorations()
        {
            Function.Call(Hash.CLEAR_PED_DECORATIONS, this.playerPedHash);
        }
    }
}
