using System;
using System.Collections.Generic;

namespace Server.CouchDB
{
    class PlayerDocument
    {
        /* This constructor is used when reading from the database */
        public PlayerDocument(dynamic obj)
        {
            database_id = obj._id;
            if (((IDictionary<string,object>)obj).ContainsKey("name") &&
                ((IDictionary<string,object>)obj).ContainsKey("endpoint"))
            {
                Name = obj.name;
                Endpoint = obj.endpoint;
            }
            else
            {
                throw new ArgumentException("The Player Document does not contain name and endpoint", "obj");
            }
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
