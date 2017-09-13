using System;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;

namespace Client
{
    class Ped
    {
        private Tuple<string, string> charter;
        private Tuple<string, string> title;
        private string boogeyman;
        private int player_ped_hash;
        private int custom_overlay_hash;
        private int mp_biker_hash;
        private bool guardian;
        private bool mayhem;
        private bool pow;
        private bool valor;

        public Ped()
        {
            charter = new Tuple<string, string>("none", "none");
            title = new Tuple<string, string>("none", "none");
            boogeyman = "none";
            custom_overlay_hash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.Custom);
            mp_biker_hash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.BikerDlc);
        }

        private void UpdateDecorations()
        {
            player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
            this.ClearDecorations();
            this.SetBottomRocker();
            this.SetTitleBarPatch();
            SetBoogeymanBarPatch();
            ApplyGuardianBarPatch();
            ApplyMayhemBarPatch();
            ApplyPowBarPatch();
            ApplyValorBarPatch();
        }

        private void ClearDecorations()
        {
            Function.Call(Hash.CLEAR_PED_DECORATIONS, player_ped_hash);
        }

        private void SetBottomRocker()
        {
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, charter.Item1);
            Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, custom_overlay_hash, texture_hash);
            Screen.ShowNotification(Strings.ChangeBottomRocker(charter.Item2));
        }

        private void SetTitleBarPatch()
        {
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, title.Item1);
            Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, mp_biker_hash, texture_hash);
            Screen.ShowNotification(Strings.ChangeTitle(title.Item2));
        }

        private void SetBoogeymanBarPatch()
        {
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, boogeyman);
            Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, custom_overlay_hash, texture_hash);
        }

        private void ApplyGuardianBarPatch()
        {
            if (guardian==true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "guardian_M");
                Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, custom_overlay_hash, texture_hash);
            }
        }

        private void ApplyMayhemBarPatch()
        {
            if (mayhem == true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "mayhem_M");
                Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, custom_overlay_hash, texture_hash);
            }
        }

        private void ApplyPowBarPatch()
        {
            if (pow == true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "pow_M");
                Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, custom_overlay_hash, texture_hash);
            }
        }

        private void ApplyValorBarPatch()
        {
            if (valor == true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "valor_M");
                Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, custom_overlay_hash, texture_hash);
            }
        }

        public void ApplyBottomRocker(int index)
        {
            charter = GetCharterFromIndex(index);
            UpdateDecorations();
        }

        public void ApplyTitleBarPatch(int index)
        {
            title = GetTitleFromIndex(index);
            UpdateDecorations();
        }

        public void SetBoogeymanPatch(bool Checked)
        {
            boogeyman = GetBoogeymanFromIndex(Checked);
            UpdateDecorations();
        }

        public void SetGuardianPatch(bool Checked)
        {
            guardian = Checked;
            UpdateDecorations();
        }

        public void SetMayhemPatch(bool Checked)
        {
            mayhem = Checked;
            UpdateDecorations();
        }

        public void SetPowPatch(bool Checked)
        {
            pow = Checked;
            UpdateDecorations();
        }

        public void SetValorPatch(bool Checked)
        {
            valor = Checked;
            UpdateDecorations();
        }

        public Tuple<String,String> GetCharterFromIndex(int index)
        {
            switch(index)
            {
                case 0:
                    return new Tuple<string, string>(Strings.BackpatchTextHash.National,  Strings.CharterNameNational);
                case 1:
                    return new Tuple<string, string>(Strings.BackpatchTextHash.PaletoBay, Strings.CharterNamePaletoBay);
                case 2:
                    return new Tuple<string, string>(Strings.BackpatchTextHash.Rancho,    Strings.CharterNameRancho);
                case 3:
                    return new Tuple<string, string>(Strings.BackpatchTextHash.DelPerro,  Strings.CharterNameDelPerro);
                case 4:
                    return new Tuple<string, string>(Strings.BackpatchTextHash.LaMesa,    Strings.CharterNameLaMesa);
                default:
                    throw new Exception();
            }
        }

        public Tuple<String,String> GetTitleFromIndex(int index)
        {
            switch(index)
            {
                case 0:
                    return new Tuple<string, string>(Strings.BarPatchNoTitleTextHash, Strings.TitleNone);
                case 1:
                    return new Tuple<string, string>(Strings.BarPatchTextHash.President, Strings.TitlePresident);
                case 2:
                    return new Tuple<string, string>(Strings.BarPatchTextHash.VicePresident, Strings.TitleVicePresident);
                case 3:
                    return new Tuple<string, string>(Strings.BarPatchSgtAtArmsTextHash, Strings.TitleSeargentAtArms);
                case 4:
                    return new Tuple<string, string>(Strings.BarPatchRoadCaptainTextHash, Strings.TitleRoadCaptain);
                case 5:
                    return new Tuple<string, string>(Strings.BarPatchEnforcerTextHash, Strings.TitleEnforcer);
                case 6:
                    return new Tuple<string, string>(Strings.BarPatchProspectTextHash, Strings.TitleProspect);
                default:
                    throw new Exception();
            }
        }

        public string GetBoogeymanFromIndex(bool Checked)
        {
            if (Checked)
            {
                return "boogeyman_M";
            }
            else
            {
                return "none";
            }
        }

        public override string ToString()
        {
            return "Ped Instance \n" +
                "Charter = " + charter.ToString() + "\n" +
                "Title = " + title.ToString() + "\n" +
                "Player Ped Hash = " + player_ped_hash.ToString() + "\n" +
                "Custom Overlay Hash = " + custom_overlay_hash + "\n" +
                "Biker DLC hash = " + mp_biker_hash;
        }
    }
}
