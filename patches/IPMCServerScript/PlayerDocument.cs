using System.Collections.Generic;
using CitizenFX.Core;

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
                Debug.WriteLine("WARNING: Found incompatible entry. name or endpoint missing!");
            }
        }
        public string Name { get; set; }
        public string Endpoint { get; set; }
    }
}
