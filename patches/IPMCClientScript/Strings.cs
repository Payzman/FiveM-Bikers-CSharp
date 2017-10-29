namespace Client
{
    using System;
    using System.Collections.Generic;

    public static class Strings
    {
        public const string NoTextHash = "none"; // Is used for everything where just 'no' overlay shall be used.

        public static List<dynamic> Charters()
        {
            return new List<dynamic>()
            {
                CharterName.National,
                CharterName.PaletoBay,
                CharterName.Rancho,
                CharterName.DelPerro,
                CharterName.LaMesa
            };
        }

        public static List<dynamic> Titles()
        {
            return new List<dynamic>()
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

        /* Overlay Collections */
        public static class OverlayCollection
        {
            public const string Custom   = "ipmc_overlays";
            public const string BikerDlc = "mpBiker_overlays";
        }

        /* Patch text hashes for males */
        public static class BackpatchTextHash
        {
            public const string National  = "ipmc_national_M";
            public const string PaletoBay = "impc_paleto_bay_M";
            public const string Rancho    = "ipmc_ranco_M";
            public const string DelPerro  = "ipmc_del_perro_M";
            public const string LaMesa    = "ipmc_la_mesa_M";
        }

        /* Text hashes for titles (bar patch) - taken from biker DLC*/
        public static class BarPatchTextHash
        {
            public const string President     = "MP_Biker_Rank_000_M";
            public const string VicePresident = "MP_Biker_Rank_001_M";
            public const string SgtAtArms     = "MP_Biker_Rank_002_M";
            public const string RoadCaptain   = "MP_Biker_Rank_003_M";
            public const string Prospect      = "MP_Biker_Rank_004_M";
            public const string Enforcer      = "MP_Biker_Rank_015_M";
        }

        /* Charter Names */
        public static class CharterName
        {
            public const string National  = "National";
            public const string PaletoBay = "Paleto Bay";
            public const string Rancho    = "Rancho";
            public const string DelPerro  = "Del Perro";
            public const string LaMesa    = "La Mesa";
        }

        /* Titles (Officers etc.) */
        public static class Title
        {
            public const string None = "None";
            public const string President = "President";
            public const string VicePresident = "Vice President";
            public const string SeargentAtArms = "Sgt. at Arms";
            public const string RoadCaptain = "Road Captain";
            public const string Prospect = "Prospect";
            public const string Enforcer = "Enforcer";
        }

        /* Menu Titles */
        public static class MenuTitle
        {
            public const string Interaction = "Interaction Menu";
            public const string Patch       = "Apply Patches";
            public const string Recording   = "Recording Menu";
        }

        /* Menu Items */
        public static class MenuItem
        {
            public const string Charter = "Charter";
            public const string DefaultClothes = "Default Clothes";
            public const string LeaveSession = "Leave Session";
            public const string StartRecording = "Start Recording";
            public const string StopRecording = "Stop Recording";
            public const string DiscardRecording = "Discard Recording";
            public const string Titles = "Title";
            public const string Boogeyman = "Boogeyman";
            public const string Guardian = "Guardian";
            public const string Mayhem = "Mayhem";
            public const string Pow = "Prisoner of War";
            public const string Valor = "Valor";
        }

        /* Menu Subtitles */
        public static class MenuSubtitle
        {
            public const string Interaction = "";
        }

        /* Menu Descriptions */
        public static class MenuDescription
        {
            public const string SetPatch = "Options to change what patches and badges you wear";
            public const string SetCharter = "Set your charter";
            public const string Recording = "Recording options for rockstar editor";
            public const string StartRecording = "Start recording";
            public const string StopRecording = "Stop recording and save it";
            public const string DiscardRecording = "Stop recording and discard it";
            public const string SetTitle = "Set your title";
            public const string Boogeyman = "PVP Commendation Boogeyman";
            public const string Guardian = "PVP Commendation Guardian";
            public const string Mayhem = "PVP Commendation Mayhem";
            public const string Pow = "PVP Commendation Prisoner of War";
            public const string Valor = "PVP Commendation Valor";
        }

        /* Notifications */
        public static class Notification
        {
            public const string LeaveSession = "You left the session!";
            public const string SaveClip = "Your recorded clip was saved.";
            public const string DiscardClip = "Your recorded clip was discarded.";
            /* Compund Strings */
            public static string ChangeBottomRocker(string charter_name)
            {
                return "Changing bottom rocker to " + charter_name;
            }

            public static string ChangeTitle(string title_name)
            {
                return "Changing title bar patch to " + title_name;
            }
        }
    }
}
