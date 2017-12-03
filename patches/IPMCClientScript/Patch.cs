namespace Client
{
    using System.Collections.Generic;
    using CitizenFX.Core;
    using CitizenFX.Core.Native;
    using NativeUI;

    public class Patch
    {
        private int collectionHash;
        private int nameHash;

        public Patch(int collection, string hash_name, string name)
        {
            this.collectionHash = collection;
            this.nameHash = Function.Call<int>(Hash.GET_HASH_KEY, hash_name);
        }

        public bool Active { get; set; }

        public void Update(int ped_hash)
        { /* You can only delete all decorations and reset them */
            if (this.Active)
            {
                Function.Call(Hash._SET_PED_DECORATION, ped_hash, this.collectionHash, this.nameHash);
            }
        }

        public class Collection
        {
            private int customOverlayHash;
            private int bikerDlcHash;

            public Collection()
            {
                this.customOverlayHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.Custom);
                this.bikerDlcHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.BikerDlc);
                /* Here will be all the preparation stuff for reading in the file */
            }

            public List<List<Patch>> ReadFromFile()
            {
                /* Currently hardcoded - later via file */
                List<List<Patch>> patches = new List<List<Patch>>()
                {
                    new List<Patch>()
                    {
                        new Patch(4, "bla", "bla"),
                    },
                };

                return patches;
            }
        }
    }
}
