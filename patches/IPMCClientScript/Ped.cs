namespace Client
{
    using System;
    using CitizenFX.Core.Native;
    using CitizenFX.Core.UI;
    using System.Collections.Generic;

    public class Ped
    {
        private Tuple<string, string> title;
        private int playerPedHash;
        private int customOverlayHash;
        private int bikerDlcHash;

        public Ped()
        {
            this.title = new Tuple<string, string>("none", "none");
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

        public void ApplyTitleBarPatch(int index)
        {
            this.title = this.GetTitleFromIndex(index);
            this.UpdateDecorations();
        }

        public Tuple<string, string> GetTitleFromIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return new Tuple<string, string>(Strings.NoTextHash, Strings.Title.None);
                case 1:
                    return new Tuple<string, string>(Strings.BarPatchTextHash.President, Strings.Title.President);
                case 2:
                    return new Tuple<string, string>(Strings.BarPatchTextHash.VicePresident, Strings.Title.VicePresident);
                case 3:
                    return new Tuple<string, string>(Strings.BarPatchTextHash.SgtAtArms, Strings.Title.SeargentAtArms);
                case 4:
                    return new Tuple<string, string>(Strings.BarPatchTextHash.RoadCaptain, Strings.Title.RoadCaptain);
                case 5:
                    return new Tuple<string, string>(Strings.BarPatchTextHash.Enforcer, Strings.Title.Enforcer);
                case 6:
                    return new Tuple<string, string>(Strings.BarPatchTextHash.Prospect, Strings.Title.Prospect);
                default:
                    throw new Exception();
            }
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
            this.SetTitleBarPatch();
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
            this.Backpatch = new List<Patch>();
            Backpatch.Add(new Patch(this.customOverlayHash, "none"));
            Backpatch.Add(new Patch(this.customOverlayHash, Strings.BackpatchTextHash.National));
            Backpatch.Add(new Patch(this.customOverlayHash, Strings.BackpatchTextHash.PaletoBay));
            Backpatch.Add(new Patch(this.customOverlayHash, Strings.BackpatchTextHash.Rancho));
            Backpatch.Add(new Patch(this.customOverlayHash, Strings.BackpatchTextHash.DelPerro));
            Backpatch.Add(new Patch(this.customOverlayHash, Strings.BackpatchTextHash.LaMesa));
        }

        private void ClearDecorations()
        {
            Function.Call(Hash.CLEAR_PED_DECORATIONS, this.playerPedHash);
        }

        private void SetTitleBarPatch()
        {
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, this.title.Item1);
            Function.Call(Hash._SET_PED_DECORATION, this.playerPedHash, this.bikerDlcHash, texture_hash);
            Screen.ShowNotification(Strings.Notification.ChangeTitle(this.title.Item2));
        }
    }
}
