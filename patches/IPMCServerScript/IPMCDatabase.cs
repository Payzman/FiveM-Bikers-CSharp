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
        IPMCCouchDbRoot root;
        string url = "http://127.0.0.1:5984";

        public IPMCDatabase()
        {
            IPMCServer.TriggerEvent("IPMC:HttpGet",url,"connectivity test");
        }

        public void HandleResponse(dynamic response, string reason)
        {
            switch(reason)
            {
                case "connectivity test":
                    root = new IPMCCouchDbRoot(response);
                    Debug.WriteLine("Welcome to CouchDB Version " + root.version);
                    IPMCServer.TriggerEvent("IPMC:HttpGet", url, "get all databases");
                    break;
                case "get all databases":
                    Debug.WriteLine(response.ToString());
                    break;
            }
        }
    }
}
