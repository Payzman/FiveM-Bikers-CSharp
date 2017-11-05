namespace Client
{
    using CitizenFX.Core;
    using CitizenFX.Core.Native;

    public class Patch
    {
        private int collectionHash;
        private int nameHash;

        public Patch(int collection, string name)
        {
            this.collectionHash = collection;
            this.nameHash = Function.Call<int>(Hash.GET_HASH_KEY, name);
        }

        public bool Active { get; set; }

        public void Apply(int ped_hash)
        {
            if (this.Active)
            {
                Function.Call(Hash._SET_PED_DECORATION, ped_hash, this.collectionHash, this.nameHash);
            }
        }
    }
}
