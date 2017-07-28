using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patches
{
    static class IPMCStrings
    {
        /* PART 1: SIMPLE STRINGS */
        /* Overlay Collections */
        public const String OverlayCollection = "ipmc_overlays";
        /* Patch text hashes for males */
        public const String PatchNationalMaleTextHash     = "ipmc_national_M";
        public const String PatchPaletoBayMaleTextHash    = "ipmc_paleto_bay_M";
        public const String PatchRanchoMaleTextHash       = "ipmc_rancho_M";
        public const String PatchDelPerroMaleTextHash     = "ipmc_del_perro_M";
        public const String PatchLaMesaMaleTextHash       = "ipmc_la_mesa_M";
        /* Charter Names */
        public const String CharterNameNational   = "National";
        public const String CharterNamePaletoBay  = "Paleto Bay";
        public const String CharterNameRancho     = "Rancho";
        public const String CharterNameDelPerro   = "Del Perro";
        public const String CharterNameLaMesa     = "La Mesa";
        /* Menu Titles */
        public const String MenuTitleInteraction = "Interaction Menu";
        public const String MenuTitlePatch       = "Apply Patches";
        /* Menu Items */
        public const String MenuItemCharter        = "Charter";
        public const String MenuItemDefaultClothes = "Default Clothes";
        public const String MenuItemLeaveSession   = "Leave Session";
        /* Menu Subtitles */
        public const String MenuSubtitleInteraction = "";
        /* Menu Descriptions */
        public const String MenuDescriptionSetPatch     = "Options to change what patches and badges you wear";
        public const String MenuDescriptionSetCharter   = "Set your charter";
        /* Notifications */
        public const String NotificationLeaveSession = "You left the session!";
        /* PART 2: COMPUND STRINGS */
        /* Notifications */
        public static String ChangeBottomRocker(String charter_name)
        {
            return "Changing bottom rocker to " + charter_name;
        }
    }
}
