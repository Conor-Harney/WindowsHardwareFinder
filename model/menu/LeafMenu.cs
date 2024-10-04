namespace WindowsHardwareFinder.model.menu
{
    public class LeafMenu
    {
        public class LeafMenuItem
        {
            public LeafMenuItem(string item)
            {
                this.Item = item;
            }
            public string Item { get; set; }
        }
    }
}
