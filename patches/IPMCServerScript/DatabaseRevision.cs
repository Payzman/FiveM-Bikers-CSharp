namespace Server
{
    public class DatabaseRevision
    {
        public string rev { get; set; }

        public DatabaseRevision(dynamic obj)
        {
            rev = obj.rev;
        }
    }
}
