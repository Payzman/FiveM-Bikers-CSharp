using System.Dynamic;

namespace Server.CouchDB
{
    class PlayerDatabase : Database
    {
        public PlayerDatabase(dynamic obj) : base((ExpandoObject)obj)
        {
            ServerScript.TriggerEvent("Server:LoadedPlayerdocs");
        }
    }
}
