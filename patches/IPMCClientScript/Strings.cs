using System;
using System.Collections.Generic;

namespace Client
{
    static class Strings
    {
        /* PART 1: SIMPLE STRINGS */
        /* Overlay Collections */
        public static class OverlayCollection
        {
            public const String Custom   = "ipmc_overlays";
            public const String BikerDlc = "mpBiker_overlays";
        }
        /* Patch text hashes for males */
        public static class BackpatchTextHash
        {
            public const String National  = "ipmc_national_M";
            public const String PaletoBay = "impc_paleto_bay_M";
            public const String Rancho    = "ipmc_ranco_M";
            public const String DelPerro  = "ipmc_del_perro_M";
            public const String LaMesa    = "ipmc_la_mesa_M";
        }
        /* Text hashes for titles (bar patch) - taken from biker DLC*/
        public static class BarPatchTextHash
        {
            public const String President     = "MP_Biker_Rank_000_M";
            public const String VicePresident = "MP_Biker_Rank_001_M";
        }
        public const String BarPatchNoTitleTextHash       = "none"; //Exception - needed for having no bar patch!
        public const String BarPatchSgtAtArmsTextHash     = "MP_Biker_Rank_002_M";
        public const String BarPatchRoadCaptainTextHash   = "MP_Biker_Rank_003_M";
        public const String BarPatchProspectTextHash      = "MP_Biker_Rank_004_M";
        public const String BarPatchEnforcerTextHash      = "MP_Biker_Rank_015_M";
        /* Charter Names */
        public const String CharterNameNational   = "National";
        public const String CharterNamePaletoBay  = "Paleto Bay";
        public const String CharterNameRancho     = "Rancho";
        public const String CharterNameDelPerro   = "Del Perro";
        public const String CharterNameLaMesa     = "La Mesa";
        /* Titles (Officers etc.) */
        public const String TitleNone           = "None";
        public const String TitlePresident      = "President";
        public const String TitleVicePresident  = "Vice President";
        public const String TitleSeargentAtArms = "Sgt. at Arms";
        public const String TitleRoadCaptain    = "Road Captain";
        public const String TitleProspect       = "Prospect";
        public const String TitleEnforcer       = "Enforcer";
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
        public const String MenuItemTitles           = "Title";
        /* Menu Subtitles */
        public const String MenuSubtitleInteraction = "";
        /* Menu Descriptions */
        public const String MenuDescriptionSetPatch         = "Options to change what patches and badges you wear";
        public const String MenuDescriptionSetCharter       = "Set your charter";
        public const String MenuDescriptionRecording        = "Recording options for rockstar editor";
        public const String MenuDescriptionStartRecording   = "Start recording";
        public const String MenuDescriptionStopRecording    = "Stop recording and save it";
        public const String MenuDescriptionDiscardRecording = "Stop recording and discard it";
        public const String MenuDescriptionSetTitle         = "Set your title";
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
        public static String ChangeTitle(String title_name)
        {
            return "Changing title bar patch to " + title_name;
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

        public static List<dynamic> titles = new List<dynamic>()
        {
            TitleNone,
            TitlePresident,
            TitleVicePresident,
            TitleSeargentAtArms,
            TitleRoadCaptain,
            TitleEnforcer,
            TitleProspect,
        };
    }
}
