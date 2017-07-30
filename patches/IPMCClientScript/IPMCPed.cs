using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;

namespace patches
{
    class IPMCPed
    {

        public IPMCPed()
        {
            //STUB
        }

        public void ApplyBottomRocker(int index)
        {
            Tuple<string, string> name_hash = GetCharterFromIndex(index);
            String hash = name_hash.Item1;
            String charter_name = name_hash.Item2;
            int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
            int collection_hash = Function.Call<int>(Hash.GET_HASH_KEY, IPMCStrings.OverlayCollection);
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, hash);
            Function.Call(Hash.CLEAR_PED_DECORATIONS, player_ped_hash);
            Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, collection_hash, texture_hash);
            Screen.ShowNotification(IPMCStrings.ChangeBottomRocker(charter_name));
        }

        public Tuple<String,String> GetCharterFromIndex(int index)
        {
            switch(index)
            {
                case 0:
                    return new Tuple<string, string>(IPMCStrings.PatchNationalMaleTextHash,  IPMCStrings.CharterNameNational);
                case 1:
                    return new Tuple<string, string>(IPMCStrings.PatchPaletoBayMaleTextHash, IPMCStrings.CharterNamePaletoBay);
                case 2:
                    return new Tuple<string, string>(IPMCStrings.PatchRanchoMaleTextHash,    IPMCStrings.CharterNameRancho);
                case 3:
                    return new Tuple<string, string>(IPMCStrings.PatchDelPerroMaleTextHash,  IPMCStrings.CharterNameDelPerro);
                case 4:
                    return new Tuple<string, string>(IPMCStrings.PatchLaMesaMaleTextHash,    IPMCStrings.CharterNameLaMesa);
                default:
                    throw new Exception();
            }
        }
    }
}
