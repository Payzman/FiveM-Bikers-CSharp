using System.Dynamic;
using CitizenFX.Core;

namespace Server.CouchDB
{
    class PlayerDatabase : Database
    {
        public PlayerDatabase(dynamic obj) : base((ExpandoObject)obj)
        {
            ServerScript.TriggerEvent("Server:LoadedPlayerdocs");
        }

        public void GetPlayerInfo()
        {
            foreach (DatabaseRows document in rows)
            {
                string url = Strings.player_base + "/" + document.id.ToString();
                Debug.WriteLine("Getting entry from " + url);
                string reason = Strings.get_single_player_doc;
                ServerScript.TriggerEvent("Server:HttpGet", url, reason);
            }
        }
    }
}
