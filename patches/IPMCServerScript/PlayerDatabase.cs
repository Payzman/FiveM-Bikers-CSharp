using System;
using System.Dynamic;
using System.Collections.Generic;
using CitizenFX.Core;

namespace Server.CouchDB
{
    class PlayerDatabase : Database
    {
        public List<PlayerDocument> users = new List<PlayerDocument>();

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

        public void AddPlayerDocument(dynamic response)
        {
            try
            {
                PlayerDocument player = new PlayerDocument(response);
                users.Add(player);
                Debug.WriteLine("Added new player with Endpoint = " + player.Endpoint + " and Name = " + player.Name);
            }
            catch (ArgumentException e)
            {
                Debug.WriteLine(e.Message + "\nThe database entry seems to be faulty. Please check the database");
            }
        }
    }
}
