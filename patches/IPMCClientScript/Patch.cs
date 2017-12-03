namespace Client
{
    using System.Collections.Generic;
    using CitizenFX.Core;
    using CitizenFX.Core.Native;
    using CitizenFX.Core.UI;
    using NativeUI;

    public class Patch
    {
        private int collectionHash;
        private int nameHash;
        private string name;

        public Patch(int collection, string hash_name, string name)
        {
            this.collectionHash = collection;
            this.nameHash = Function.Call<int>(Hash.GET_HASH_KEY, hash_name);
            this.name = name;
        }

        public bool Active { get; set; }

        public void Update(int ped_hash)
        { /* You can only delete all decorations and reset them */
            if (this.Active)
            {
                Function.Call(Hash._SET_PED_DECORATION, ped_hash, this.collectionHash, this.nameHash);
            }
        }
        
        public override string ToString()
        {
            return this.name;
        }

        public class Collection
        {
            private int customOverlayHash;
            private int bikerDlcHash;
            private List<Patch> patchCollection;

            public Collection()
            {
                this.customOverlayHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.Custom);
                this.bikerDlcHash = Function.Call<int>(Hash.GET_HASH_KEY, Strings.OverlayCollection.BikerDlc);
                /* Here will be all the preparation stuff for reading in the file */
                this.ReadFromFile();
            }

            public void ReadFromFile()
            {
                /* Currently hardcoded - later via file */
                List<Patch> patches = new List<Patch>()
                {
                    new Patch(this.customOverlayHash, "boogeyman_M", Strings.MenuItem.Boogeyman),
                    new Patch(this.customOverlayHash, "guardian_M", Strings.MenuItem.Guardian),
                    new Patch(this.customOverlayHash, "mayhem_M", Strings.MenuItem.Mayhem),
                    new Patch(this.customOverlayHash, "pow_M", Strings.MenuItem.Pow),
                    new Patch(this.customOverlayHash, "valor_M", Strings.MenuItem.Valor)
                };

                this.patchCollection = patches;
            }

            public Patch SearchPatch(string name)
            {
                foreach (Patch patch in this.patchCollection)
                {
                    if (patch.name == name)
                    {
                        return patch;
                    }
                }

                return null;
            }
        }
    }
}
