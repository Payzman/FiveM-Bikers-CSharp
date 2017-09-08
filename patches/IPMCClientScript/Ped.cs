using System;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;

namespace Client
{
    class Ped
    {
        private Tuple<string, string> charter;
        private Tuple<string, string> title;
        private int player_ped_hash;
        private int custom_overlay_hash;
        private int mp_biker_hash;

        public Ped()
        {
            player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
            custom_overlay_hash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection);
            mp_biker_hash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.BikerDlcOverlayCollection);
        }

        private void UpdateDecorations()
        {
            this.ClearDecorations();
            this.SetBottomRocker();
            this.SetTitleBarPatch();
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

        public Tuple<String,String> GetCharterFromIndex(int index)
        {
            switch(index)
            {
                case 0:
                    return new Tuple<string, string>(Strings.PatchNationalMaleTextHash,  Strings.CharterNameNational);
                case 1:
                    return new Tuple<string, string>(Strings.PatchPaletoBayMaleTextHash, Strings.CharterNamePaletoBay);
                case 2:
                    return new Tuple<string, string>(Strings.PatchRanchoMaleTextHash,    Strings.CharterNameRancho);
                case 3:
                    return new Tuple<string, string>(Strings.PatchDelPerroMaleTextHash,  Strings.CharterNameDelPerro);
                case 4:
                    return new Tuple<string, string>(Strings.PatchLaMesaMaleTextHash,    Strings.CharterNameLaMesa);
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
                    return new Tuple<string, string>(Strings.BarPatchPresidentTextHash, Strings.TitlePresident);
                case 2:
                    return new Tuple<string, string>(Strings.BarPatchVicePresidentTextHash, Strings.TitleVicePresident);
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
    }
}
