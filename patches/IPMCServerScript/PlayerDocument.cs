namespace Server
{
    class PlayerDocument
    {
        public PlayerDocument(dynamic obj)
        {
            Name = obj.name;
            Endpoint = obj.endpoint;
        }
        public string Name { get; set; }
        public string Endpoint { get; set; }
    }
}
