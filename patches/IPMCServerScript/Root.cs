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
        public Root()
        {
            //stub
        }
        public string couchdb { get; set; }
        public string version { get; set; }
        public Vendor vendor { get; set; }

        public void RequestConnnectivity()
        {
            ServerScript.TriggerEvent("Server:HttpGet", Strings.couchdb_url, Strings.reason_connectivity);
        }

        public void CheckConnectivity(dynamic obj)
        {
            this.couchdb = obj.couchdb;
            this.version = obj.version;
            this.vendor = new Vendor(obj.vendor);
            ServerScript.TriggerEvent("Server:HttpGet", Strings.all_dbs_url, Strings.get_all_dbs);
            ServerScript.TriggerEvent("Server:Initialized");
        }
    }
}
