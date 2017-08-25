using System;
using System.Collections.Generic;

namespace Client
{
    static class Strings
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
        public const String MenuTitleRecording   = "Recording Menu";
        /* Menu Items */
        public const String MenuItemCharter          = "Charter";
        public const String MenuItemDefaultClothes   = "Default Clothes";
        public const String MenuItemLeaveSession     = "Leave Session";
        public const String MenuItemStartRecording   = "Start Recording";
        public const String MenuItemStopRecording    = "Stop Recording";
        public const String MenuItemDiscardRecording = "Discard Recording";
        /* Menu Subtitles */
        public const String MenuSubtitleInteraction = "";
        /* Menu Descriptions */
        public const String MenuDescriptionSetPatch         = "Options to change what patches and badges you wear";
        public const String MenuDescriptionSetCharter       = "Set your charter";
        public const String MenuDescriptionRecording        = "Recording options for rockstar editor";
        public const String MenuDescriptionStartRecording   = "Start recording";
        public const String MenuDescriptionStopRecording    = "Stop recording and save it";
        public const String MenuDescriptionDiscardRecording = "Stop recording and discard it";
        /* Notifications */
        public const String NotificationLeaveSession = "You left the session!";
        public const String NotificationSaveClip     = "Your recorded clip was saved.";
        public const String NotificationDiscardClip  = "Your recorded clip was discarded.";
        /* PART 2: COMPUND STRINGS */
        /* Notifications */
        public static String ChangeBottomRocker(String charter_name)
        {
            return "Changing bottom rocker to " + charter_name;
        }
        /* String Collections e.g. for menus etc.*/

        public static List<dynamic> charters = new List<dynamic>()
        {
            CharterNameNational,
            CharterNamePaletoBay,
            CharterNameRancho,
            CharterNameDelPerro,
            CharterNameLaMesa,
        };
    }
}
