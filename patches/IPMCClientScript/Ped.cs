namespace Client
{
    using System;
    using System.Collections.Generic;
    using CitizenFX.Core.Native;
    using CitizenFX.Core.UI;

    public class Ped
    {
        private int playerPedHash;
        private int customOverlayHash;
        private int bikerDlcHash;

        public Ped()
        {
            this.customOverlayHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.Custom);
            this.bikerDlcHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.BikerDlc);
            this.InitPatches();
        }

        public Patch Boogeyman { get; set; }

        public Patch Guardian { get; set; }

        public Patch Mayhem { get; set; }

        public Patch Pow { get; set; }

        public Patch Valor { get; set; }

        public List<Patch> Backpatch { get; set; }

        public List<Patch> Title { get; set; }

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
            this.Boogeyman.Update(this.playerPedHash);
            this.Guardian.Update(this.playerPedHash);
            this.Mayhem.Update(this.playerPedHash);
            this.Pow.Update(this.playerPedHash);
            this.Valor.Update(this.playerPedHash);
        }

        private void InitPatches()
        {
            this.Boogeyman = new Patch(this.customOverlayHash, "boogeyman_M");
            this.Guardian = new Patch(this.customOverlayHash, "guardian_M");
            this.Mayhem = new Patch(this.customOverlayHash, "mayhem_M");
            this.Pow = new Patch(this.customOverlayHash, "pow_M");
            this.Valor = new Patch(this.customOverlayHash, "valor_M");
            this.Backpatch = new List<Patch>()
            {
                new Patch(this.customOverlayHash, "none"),
                new Patch(this.customOverlayHash, Strings.BackpatchTextHash.National),
                new Patch(this.customOverlayHash, Strings.BackpatchTextHash.PaletoBay),
                new Patch(this.customOverlayHash, Strings.BackpatchTextHash.Rancho),
                new Patch(this.customOverlayHash, Strings.BackpatchTextHash.DelPerro),
                new Patch(this.customOverlayHash, Strings.BackpatchTextHash.LaMesa),
            };
            this.Title = new List<Patch>()
            {
                new Patch(this.customOverlayHash, Strings.Title.None),
                new Patch(this.customOverlayHash, Strings.Title.President),
                new Patch(this.customOverlayHash, Strings.Title.VicePresident),
                new Patch(this.customOverlayHash, Strings.Title.SeargentAtArms),
                new Patch(this.customOverlayHash, Strings.Title.RoadCaptain),
                new Patch(this.customOverlayHash, Strings.Title.Enforcer),
                new Patch(this.customOverlayHash, Strings.Title.Prospect),
            };
        }

        private void ClearDecorations()
        {
            Function.Call(Hash.CLEAR_PED_DECORATIONS, this.playerPedHash);
        }
    }
}
