namespace WIMS.Models.Module.DefaultItems
{
    public enum MenuItemType
    {
        Browse,
        About,
        Beacons,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
