namespace Client
{
    using System;
    using CitizenFX.Core.Native;
    using CitizenFX.Core.UI;

    public class Ped
    {
        private Tuple<string, string> charter;
        private Tuple<string, string> title;
        private int playerPedHash;
        private int customOverlayHash;
        private int bikerDlcHash;

        public Ped()
        {
            this.charter = new Tuple<string, string>("none", "none");
            this.title = new Tuple<string, string>("none", "none");
            this.customOverlayHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.Custom);
            this.bikerDlcHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.BikerDlc);
            this.InitPatches();
        }

        public Patch Boogeyman { get; set; }

        public bool Guardian
        {
            get { return this.Guardian; }
            set { this.Guardian = value; }
        }

        public bool Mayhem
        {
            get { return this.Mayhem; }
            set { this.Mayhem = value; }
        }

        public bool Pow
        {
            get { return this.Pow; }
            set { this.Pow = value; }
        }

        public bool Valor
        {
            get { return this.Valor; }
            set { this.Valor = value; }
        }

        public void ApplyBottomRocker(int index)
        {
            this.charter = this.GetCharterFromIndex(index);
            this.UpdateDecorations();
        }

        public void ApplyTitleBarPatch(int index)
        {
            this.title = this.GetTitleFromIndex(index);
            this.UpdateDecorations();
        }

        public Tuple<string, string> GetCharterFromIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return new Tuple<string, string>(Strings.BackpatchTextHash.National,  Strings.CharterName.National);
                case 1:
                    return new Tuple<string, string>(Strings.BackpatchTextHash.PaletoBay, Strings.CharterName.PaletoBay);
                case 2:
                    return new Tuple<string, string>(Strings.BackpatchTextHash.Rancho,    Strings.CharterName.Rancho);
                case 3:
                    return new Tuple<string, string>(Strings.BackpatchTextHash.DelPerro,  Strings.CharterName.DelPerro);
                case 4:
                    return new Tuple<string, string>(Strings.BackpatchTextHash.LaMesa,    Strings.CharterName.LaMesa);
                default:
                    throw new Exception();
            }
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

        public override string ToString()
        {
            return "Ped Instance \n" +
                "Charter = " + this.charter.ToString() + "\n" +
                "Title = " + this.title.ToString() + "\n" +
                "Player Ped Hash = " + this.playerPedHash.ToString() + "\n" +
                "Custom Overlay Hash = " + this.customOverlayHash + "\n" +
                "Biker DLC hash = " + this.bikerDlcHash;
        }

        public void UpdateDecorations()
        {
            /* You cannot enable or disable single decorations. The only way
             * is to disable all decorations and reenable all decorations you
             * want on the PC */
            this.playerPedHash = Function.Call<int>(Hash.PLAYER_PED_ID);
            this.ClearDecorations();
            this.SetBottomRocker();
            this.SetTitleBarPatch();
            this.Boogeyman.Apply(this.playerPedHash);
            this.ApplyGuardianBarPatch();
            this.ApplyMayhemBarPatch();
            this.ApplyPowBarPatch();
            this.ApplyValorBarPatch();
        }

        private void InitPatches()
        {
            this.Boogeyman = new Patch(this.customOverlayHash, "boogeyman_M");
        }

        private void ClearDecorations()
        {
            Function.Call(Hash.CLEAR_PED_DECORATIONS, this.playerPedHash);
        }

        private void SetBottomRocker()
        {
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, this.charter.Item1);
            Function.Call(Hash._SET_PED_DECORATION, this.playerPedHash, this.customOverlayHash, texture_hash);
            Screen.ShowNotification(Strings.Notification.ChangeBottomRocker(this.charter.Item2));
        }

        private void SetTitleBarPatch()
        {
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, this.title.Item1);
            Function.Call(Hash._SET_PED_DECORATION, this.playerPedHash, this.bikerDlcHash, texture_hash);
            Screen.ShowNotification(Strings.Notification.ChangeTitle(this.title.Item2));
        }

        private void ApplyGuardianBarPatch()
        {
            if (this.Guardian == true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "guardian_M");
                Function.Call(Hash._SET_PED_DECORATION, this.playerPedHash, this.customOverlayHash, texture_hash);
            }
        }

        private void ApplyMayhemBarPatch()
        {
            if (this.Mayhem == true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "mayhem_M");
                Function.Call(Hash._SET_PED_DECORATION, this.playerPedHash, this.customOverlayHash, texture_hash);
            }
        }

        private void ApplyPowBarPatch()
        {
            if (this.Pow == true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "pow_M");
                Function.Call(Hash._SET_PED_DECORATION, this.playerPedHash, this.customOverlayHash, texture_hash);
            }
        }

        private void ApplyValorBarPatch()
        {
            if (this.Valor == true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "valor_M");
                Function.Call(Hash._SET_PED_DECORATION, this.playerPedHash, this.customOverlayHash, texture_hash);
            }
        }
    }
}
