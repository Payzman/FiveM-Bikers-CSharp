using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using System.Web;

namespace IPMCServerScript
{
    // The actual HTTP Requests and Responses are done by a lua script!
    class IPMCDatabase
    {
        // static stuff
        static string url = "http://127.0.0.1:5984";
        static string all_dbs = url + "/_all_dbs";
        // dynamic stuff
        IPMCCouchDbRoot root;
        List<string> databases;

        public void HandleResponse(dynamic response, string reason)
        {
            switch(reason)
            {
                case "connectivity test":
                    root = new IPMCCouchDbRoot(response);
                    IPMCServer.TriggerEvent("IPMC:HttpGet", all_dbs, "get all databases");
                    Debug.WriteLine("Couch DB initialized (Version " + root.version + ")");
                    IPMCServer.TriggerEvent("Server:Initialized");
                    break;
                case "get all databases":
                    databases = new List<string>();
                    foreach(object obj in response)
                    {
                        databases.Add(response.ToString());
                    }
                    break;
            }
        }

        public void Connect()
        {
            IPMCServer.TriggerEvent("IPMC:HttpGet", url, "connectivity test");
        }
    }
}
