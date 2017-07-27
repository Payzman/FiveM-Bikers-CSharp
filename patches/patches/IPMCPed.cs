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
        private static readonly String[] NAME_HASHES =
        {
            "ipmc_national_M",
            "ipmc_paleto_bay_M",
            "ipmc_rancho_M",
            "ipmc_del_perro_M",
            "ipmc_la_mesa_M",
        };

        public IPMCPed()
        {
            //STUB
        }

        public void ApplyBottomRocker(int index)
        {
            Screen.ShowNotification("Changing bottom rocker to " + IPMCMenus.CHARTERS[index]);
            int player_ped_hash = Function.Call<int>(Hash.PLAYER_PED_ID);
            int collection_hash = Function.Call<int>(Hash.GET_HASH_KEY, "ipmc_overlays");
            int texture_hash = Function.Call<int>(Hash.GET_HASH_KEY, NAME_HASHES[index]);
            CitizenFX.Core.Debug.WriteLine("DEBUG:\nPlayer=" + player_ped_hash + "\nCollection=" + collection_hash + "\nTexture=" + texture_hash);
            Function.Call(Hash._SET_PED_DECORATION, player_ped_hash, collection_hash, texture_hash);
        }
    }
}
