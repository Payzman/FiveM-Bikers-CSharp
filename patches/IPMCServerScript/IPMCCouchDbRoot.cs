using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPMCServerScript
{
    public class Vendor
    {
        public string name { get; set; }
    }

    public class IPMCCouchDbRoot
    {
        public IPMCCouchDbRoot(dynamic obj)
        {
            this.couchdb = obj.couchdb;
            this.version = obj.version;
            this.vendor = obj.vendor;
        }
        public string couchdb { get; set; }
        public string version { get; set; }
        public Vendor vendor { get; set; }
    }
}
