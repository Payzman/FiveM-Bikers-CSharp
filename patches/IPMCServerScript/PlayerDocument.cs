using System.Collections.Generic;
using CitizenFX.Core;

namespace Server
{
    class PlayerDocument
    {
        public PlayerDocument(dynamic obj)
        {
            if(((IDictionary<string,dynamic>)obj).ContainsKey("name"))
            {
                Name = obj.name;
            }
            else
            {
                Debug.WriteLine("WARNING: Found Entry without name");
            }
            Endpoint = obj.endpoint;
        }
        public string Name { get; set; }
        public string Endpoint { get; set; }
    }
}
