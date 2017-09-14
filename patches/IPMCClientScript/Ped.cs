using System;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;

namespace Client
{
    public class Ped
    {
        private Tuple<string, string> charter;
        private Tuple<string, string> title;
        private string boogeyman;
        private int playerPedHash;
        private int customOverlayHash;
        private int bikerDlcHash;
        private bool guardian;
        private bool mayhem;
        private bool pow;
        private bool valor;

        public Ped()
        {
            charter = new Tuple<string, string>("none", "none");
            title = new Tuple<string, string>("none", "none");
            boogeyman = "none";
            customOverlayHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.Custom);
            bikerDlcHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.BikerDlc);
        }

        private void UpdateDecorations()
        {
            playerPedHash = Function.Call<int>(Hash.PLAYER_PED_ID);
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
            Function.Call(Hash.CLEAR_PED_DECORATIONS, playerPedHash);
        }

        private void SetBottomRocker()
        {
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, charter.Item1);
            Function.Call(Hash._SET_PED_DECORATION, playerPedHash, customOverlayHash, texture_hash);
            Screen.ShowNotification(Strings.Notification.ChangeBottomRocker(charter.Item2));
        }

        private void SetTitleBarPatch()
        {
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, title.Item1);
            Function.Call(Hash._SET_PED_DECORATION, playerPedHash, bikerDlcHash, texture_hash);
            Screen.ShowNotification(Strings.Notification.ChangeTitle(title.Item2));
        }

        private void SetBoogeymanBarPatch()
        {
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, boogeyman);
            Function.Call(Hash._SET_PED_DECORATION, playerPedHash, customOverlayHash, texture_hash);
        }

        private void ApplyGuardianBarPatch()
        {
            if (guardian==true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "guardian_M");
                Function.Call(Hash._SET_PED_DECORATION, playerPedHash, customOverlayHash, texture_hash);
            }
        }

        private void ApplyMayhemBarPatch()
        {
            if (mayhem == true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "mayhem_M");
                Function.Call(Hash._SET_PED_DECORATION, playerPedHash, customOverlayHash, texture_hash);
            }
        }

        private void ApplyPowBarPatch()
        {
            if (pow == true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "pow_M");
                Function.Call(Hash._SET_PED_DECORATION, playerPedHash, customOverlayHash, texture_hash);
            }
        }

        private void ApplyValorBarPatch()
        {
            if (valor == true)
            {
                int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "valor_M");
                Function.Call(Hash._SET_PED_DECORATION, playerPedHash, customOverlayHash, texture_hash);
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

        public void SetBoogeymanPatch(bool checkboxChecked)
        {
            boogeyman = GetBoogeymanFromIndex(checkboxChecked);
            UpdateDecorations();
        }

        public void SetGuardianPatch(bool checkboxChecked)
        {
            guardian = checkboxChecked;
            UpdateDecorations();
        }

        public void SetMayhemPatch(bool checkboxChecked)
        {
            mayhem = checkboxChecked;
            UpdateDecorations();
        }

        public void SetPowPatch(bool checkboxChecked)
        {
            pow = checkboxChecked;
            UpdateDecorations();
        }

        public void SetValorPatch(bool checkboxChecked)
        {
            valor = checkboxChecked;
            UpdateDecorations();
        }

        public Tuple<String,String> GetCharterFromIndex(int index)
        {
            switch(index)
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

        public Tuple<String,String> GetTitleFromIndex(int index)
        {
            switch(index)
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

        public string GetBoogeymanFromIndex(bool checkboxChecked)
        {
            if (checkboxChecked)
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
                "Player Ped Hash = " + playerPedHash.ToString() + "\n" +
                "Custom Overlay Hash = " + customOverlayHash + "\n" +
                "Biker DLC hash = " + bikerDlcHash;
        }
    }
}
