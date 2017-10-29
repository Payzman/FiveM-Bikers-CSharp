namespace Client
{
    using CitizenFX.Core.Native;

    public class Patch
    {
        private int CollectionHash;
        private int name_hash;
        public bool Active { get; set; }

        public Patch(int collection, string name)
        {
            this.CollectionHash = collection;
            this.name_hash = Function.Call<int>(Hash.GET_HASH_KEY, name);
        }

        public void Apply(int ped_hash)
        {
            if(this.Active)
            {
                Function.Call(Hash._SET_PED_DECORATION, ped_hash, CollectionHash, name_hash);
            }
        }
    }
}
