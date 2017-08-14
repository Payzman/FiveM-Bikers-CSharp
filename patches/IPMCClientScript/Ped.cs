using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
