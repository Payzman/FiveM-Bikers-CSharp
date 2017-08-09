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
        string url = "http://127.0.0.1:5984";

        public IPMCDatabase()
        {
            IPMCServer.TriggerEvent("IPMC:HttpGet",url);
        }

        public static void HandleResponse(dynamic response)
        {
            IPMCCouchDbRoot root = new IPMCCouchDbRoot(response);
            Debug.WriteLine("Welcome to CouchDB Version " + response.version);
        }
    }
}
