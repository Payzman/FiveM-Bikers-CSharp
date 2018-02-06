using System.Collections.Generic;

namespace Server.CouchDB
{
    public class Vendor
    {
        public Vendor(dynamic obj)
        {
            obj.name = obj.name;
        }
        public string name { get; set; }
    }

    public class Root
    {
        public Root(dynamic obj)
        {
            if (((IDictionary<string, object>)obj).ContainsKey("couchdb"))
            {
                this.couchdb = obj.couchdb;
                this.version = obj.version;
                this.vendor = new Vendor(obj.vendor);
                ServerScript.TriggerEvent("Server:Initialized");
            }
        }
        public string couchdb { get; set; }
        public string version { get; set; }
        public Vendor vendor { get; set; }
    }
}
