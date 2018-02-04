using System;
using System.Collections.Generic;
using CitizenFX.Core;

namespace Server.CouchDB
{
    class PlayerDocument
    {
        /* This constructor is used when reading from the database */
        public PlayerDocument(dynamic obj)
        {
            database_id = obj._id;
            if (ContainsRequiredInformation(obj))
            {
                Name = obj.Name;
                Endpoint = obj.Endpoint;
            }
            else
            {
                throw new ArgumentException("The Player Document does not contain name and endpoint", "obj");
            }
        }

        private static bool ContainsRequiredInformation(dynamic obj)
        {
            return ((IDictionary<string, object>)obj).ContainsKey("Name") &&
                            ((IDictionary<string, object>)obj).ContainsKey("Endpoint");
        }

        /* This constructor is used when updating the database. The 'id' value is unused here */
        public PlayerDocument(string name, string endpoint)
        {
            Name = name;
            Endpoint = endpoint;
        }
        public string Name { get; set; }
        public string Endpoint { get; set; }
        public string database_id { get; set; }
    }
}
