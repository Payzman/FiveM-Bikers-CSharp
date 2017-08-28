using System;
using System.Collections.Generic;

namespace Server
{
    class PlayerDocument
    {
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
        public string Name { get; set; }
        public string Endpoint { get; set; }
        public string database_id { get; set; }
    }
}
