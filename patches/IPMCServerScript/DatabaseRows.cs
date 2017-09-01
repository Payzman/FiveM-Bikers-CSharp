namespace Server.CouchDB
{
    public class DatabaseRows
    {
        public string id { get; set; }
        public string key { get; set; }
        public DatabaseRevision value { get; set; }

        public DatabaseRows(dynamic obj)
        {
            id = obj.id;
            key = obj.key;
            value = new DatabaseRevision(obj.value);
        }
    }
}
