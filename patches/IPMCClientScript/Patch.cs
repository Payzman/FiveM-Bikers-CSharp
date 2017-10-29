namespace Client
{
    using CitizenFX.Core.Native;

    class Patch
    {
        private int collection_hash;
        private int name_hash;
        public bool active;

        public Patch(int collection, string name)
        {
            this.collection_hash = collection;
            this.name_hash = Function.Call<int>(Hash.GET_HASH_KEY, name);
        }

        public void Apply(int ped_hash)
        {
            if(this.active)
            {
                Function.Call(Hash._SET_PED_DECORATION, ped_hash, collection_hash, name_hash);
            }
        }
    }
}
