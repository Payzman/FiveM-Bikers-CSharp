namespace Client
{
    using NativeUI;

    public static class MenuItems
    {
        public static UIMenuListItem Backpatch
        {
            get
            {
                return new UIMenuListItem(
                    Strings.MenuItem.Charter,
                    Strings.Charters(),
                    1,
                    Strings.MenuDescription.SetCharter);
            }
        }

        public static UIMenuListItem BarTitle
        {
            get
            {
                return new UIMenuListItem(
                    Strings.MenuItem.Titles,
                    Strings.Titles(),
                    1,
                    Strings.MenuDescription.SetTitle);
            }
        }

        public static UIMenuCheckboxItem Boogeyman
        {
            get
            {
                return new UIMenuCheckboxItem(
                    Strings.MenuItem.Boogeyman,
                    false,
                    Strings.MenuDescription.Boogeyman);
            }
        }

        public static UIMenuCheckboxItem Guardian
        {
            get
            {
                return new UIMenuCheckboxItem(
                    Strings.MenuItem.Guardian,
                    false,
                    Strings.MenuDescription.Guardian);
            }
        }

        public static UIMenuCheckboxItem Mayhem
        {
            get
            {
                return new UIMenuCheckboxItem(
                    Strings.MenuItem.Mayhem,
                    false,
                    Strings.MenuDescription.Mayhem);
            }
        }

        public static UIMenuCheckboxItem Pow
        {
            get
            {
                return new UIMenuCheckboxItem(
                    Strings.MenuItem.Pow,
                    false,
                    Strings.MenuDescription.Pow);
            }
        }

        public static UIMenuCheckboxItem Valor
        {
            get
            {
                return new UIMenuCheckboxItem(
                    Strings.MenuItem.Valor,
                    false,
                    Strings.MenuDescription.Valor);
            }
        }
    }
}
