using System;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;

namespace Client
{
    class Ped
    {

        public Ped()
        {
            //STUB
        }

        public void ApplyBottomRocker(int index)
        {
            Tuple<string, string> name_hash = GetCharterFromIndex(index);
            String hash = name_hash.Item1;
            String charter_name = name_hash.Item2;
            int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
            int collection_hash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection);
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, hash);
            Function.Call(Hash.CLEAR_PED_DECORATIONS, player_ped_hash);
            Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, collection_hash, texture_hash);
            Screen.ShowNotification(Strings.ChangeBottomRocker(charter_name));
        }

        public void ApplyTitleBarPatch(int index)
        {
            Tuple<string, string> name_hash = GetTitleFromIndex(index);
            String hash = name_hash.Item1;
            String title_name = name_hash.Item2;
            int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
            int collection_hash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.BikerDlcOverlayCollection);
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, hash);
            Function.Call(Hash.CLEAR_PED_DECORATIONS, player_ped_hash);
            Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, collection_hash, texture_hash);
            Screen.ShowNotification(Strings.ChangeTitle(title_name));
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
