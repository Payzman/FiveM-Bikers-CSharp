using System;
using System.Collections.Generic;

namespace Client
{
    public static class Strings
    {
        /* PART 1: SIMPLE STRINGS */
        public const String NoTextHash = "none"; //Is used for everything where just 'no' overlay shall be used.
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
            public const String SgtAtArms     = "MP_Biker_Rank_002_M";
            public const String RoadCaptain   = "MP_Biker_Rank_003_M";
            public const String Prospect      = "MP_Biker_Rank_004_M";
            public const String Enforcer      = "MP_Biker_Rank_015_M";
        }

        /* Charter Names */
        public static class CharterName
        {
            public const String National  = "National";
            public const String PaletoBay = "Paleto Bay";
            public const String Rancho    = "Rancho";
            public const String DelPerro  = "Del Perro";
            public const String LaMesa    = "La Mesa";
        }

        /* Titles (Officers etc.) */
        public static class Title
        {
            public const String None = "None";
            public const String President = "President";
            public const String VicePresident = "Vice President";
            public const String SeargentAtArms = "Sgt. at Arms";
            public const String RoadCaptain = "Road Captain";
            public const String Prospect = "Prospect";
            public const String Enforcer = "Enforcer";
        }

        /* Menu Titles */
        public static class MenuTitle
        {
            public const String Interaction = "Interaction Menu";
            public const String Patch       = "Apply Patches";
            public const String Recording   = "Recording Menu";
        }

        /* Menu Items */
        public static class MenuItem
        {
            public const String Charter = "Charter";
            public const String DefaultClothes = "Default Clothes";
            public const String LeaveSession = "Leave Session";
            public const String StartRecording = "Start Recording";
            public const String StopRecording = "Stop Recording";
            public const String DiscardRecording = "Discard Recording";
            public const String Titles = "Title";
        }

        /* Menu Subtitles */
        public static class MenuSubtitle
        {
            public const String Interaction = "";
        }

        /* Menu Descriptions */
        public static class MenuDescription
        {
            public const String SetPatch = "Options to change what patches and badges you wear";
            public const String SetCharter = "Set your charter";
            public const String Recording = "Recording options for rockstar editor";
            public const String StartRecording = "Start recording";
            public const String StopRecording = "Stop recording and save it";
            public const String DiscardRecording = "Stop recording and discard it";
            public const String SetTitle = "Set your title";
        }

        /* Notifications */
        public static class Notification
        {
            public const String LeaveSession = "You left the session!";
            public const String SaveClip = "Your recorded clip was saved.";
            public const String DiscardClip = "Your recorded clip was discarded.";
            /* Compund Strings */
            public static String ChangeBottomRocker(String charter_name)
            {
                return "Changing bottom rocker to " + charter_name;
            }

            public static String ChangeTitle(String title_name)
            {
                return "Changing title bar patch to " + title_name;
            }
        }

        /* PART 3: String Collections e.g. for menus etc.*/
        public static List<dynamic> charters = new List<dynamic>()
        {
            CharterName.National,
            CharterName.PaletoBay,
            CharterName.Rancho,
            CharterName.DelPerro,
            CharterName.LaMesa,
        };

        public static List<dynamic> titles = new List<dynamic>()
        {
            Title.None,
            Title.President,
            Title.VicePresident,
            Title.SeargentAtArms,
            Title.RoadCaptain,
            Title.Enforcer,
            Title.Prospect,
        };
    }
}
