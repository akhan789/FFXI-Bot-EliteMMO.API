namespace EliteMMO.Scripted.Embedded
{
    using System.Collections.Generic;
    using EliteMMO.Scripted.Utilities;

    public class InventoryItems
    {
        public static Dictionary<string, string> items = new Dictionary<string, string>();
        public static void PopulateItems()
        {
            items.Clear();

            for (var x = 0; x < 32767; x++)
            {
                var i = EliteMMOApiUtils.GetItem((uint)x);
                foreach (string name in i.Name)
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        items.Add(i.ItemID.ToString(), name);
                    }
                }
            }
        }
    }
}