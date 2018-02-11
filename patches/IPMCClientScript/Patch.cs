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

        public Patch(int collection, string hash_name, string name, string group)
        {
            this.collectionHash = collection;
            this.nameHash = Function.Call<int>(Hash.GET_HASH_KEY, hash_name);
            this.Name = name;
            this.Group = group;
        }

        public string Name { get; set; }

        public string Group { get; set; }

        public bool Active { get; set; }

        public void Apply(int ped_hash)
        { /* You can only delete all decorations and reset them */
            Function.Call(Hash._SET_PED_DECORATION, ped_hash, this.collectionHash, this.nameHash);
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
                this.ReadFromFile();
            }

            public List<Patch> List { get; set; }

            public void ReadFromFile()
            {
                /* Currently hardcoded - later via file */
                List<Patch> patches = new List<Patch>()
                {
                    new Patch(this.customOverlayHash, "none", "none", "All"),
                    new Patch(this.customOverlayHash, "boogeyman_M", Strings.MenuItem.Boogeyman, "pvp"),
                    new Patch(this.customOverlayHash, "guardian_M", Strings.MenuItem.Guardian, "pvp"),
                    new Patch(this.customOverlayHash, "mayhem_M", Strings.MenuItem.Mayhem, "pvp"),
                    new Patch(this.customOverlayHash, "pow_M", Strings.MenuItem.Pow, "pvp"),
                    new Patch(this.customOverlayHash, "valor_M", Strings.MenuItem.Valor, "pvp"),
                    new Patch(this.customOverlayHash, Strings.BackpatchTextHash.National, Strings.CharterName.National, "Charter"),
                    new Patch(this.customOverlayHash, Strings.BackpatchTextHash.PaletoBay, Strings.CharterName.PaletoBay, "Charter"),
                    new Patch(this.customOverlayHash, Strings.BackpatchTextHash.Rancho, Strings.CharterName.Rancho, "Charter"),
                    new Patch(this.customOverlayHash, Strings.BackpatchTextHash.DelPerro, Strings.CharterName.DelPerro, "Charter"),
                    new Patch(this.customOverlayHash, Strings.BackpatchTextHash.LaMesa, Strings.CharterName.LaMesa, "Charter"),
                    new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.President, Strings.Title.President, "Title"),
                    new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.VicePresident, Strings.Title.VicePresident, "Title"),
                    new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.SgtAtArms, Strings.Title.SeargentAtArms, "Title"),
                    new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.RoadCaptain, Strings.Title.RoadCaptain, "Title"),
                    new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.Enforcer, Strings.Title.Enforcer, "Title"),
                    new Patch(this.bikerDlcHash, Strings.BarPatchTextHash.Prospect, Strings.Title.Prospect, "Title"),
                };

                this.List = patches;
            }
        }
    }
}
