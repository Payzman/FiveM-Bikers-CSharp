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
            Screen.ShowNotification("Changing bottom rocker to " + IPMCMenus.CHARTERS[index]);
            int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
            int collection_hash = Function.Call<int>(Hash.GET_HASH_KEY, "ipmc_overlays");
            int texture_hash = 0;
            switch(index)
            {
                case 0:
                    texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "ipmc_national_M");
                    break;
                case 1:
                    texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "ipmc_paleto_bay_M");
                    break;
                case 2:
                    texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "ipmc_rancho_M");
                    break;
                case 3:
                    texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "ipmc_del_perro_M");
                    break;
                case 4:
                    texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, "ipmc_la_mesa_M");
                    break;
                default:
                    Screen.ShowNotification("This bottom rocker is not defined");
                    break;
            }
            CitizenFX.Core.Debug.WriteLine("DEBUG:\nPlayer=" + player_ped_hash + "\nCollection=" + collection_hash + "\nTexture=" + texture_hash);
            Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, collection_hash, texture_hash);
        }
    }
}
