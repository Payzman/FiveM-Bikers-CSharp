using System;
using System.Collections.Generic;

namespace Server
{
    class PlayerDocument
    {
        public PlayerDocument(dynamic obj)
        {
            // the following is more readable th
            if(((IDictionary<string,dynamic>)obj).ContainsKey("name") &&
                ((IDictionary<string, dynamic>)obj).ContainsKey("endpoint"))
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
    }
}
