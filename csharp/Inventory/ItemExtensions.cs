namespace csharp.Inventory;

using static ItemCategoryType;

internal static class ItemExtensions
{ 
    internal static bool IsNot(this Item item, ItemCategoryType category) 
    {
       return item.Category() != category;
    }
    
    internal static bool IsPastSellByDate(this Item item)
    {
       return item.SellIn < 0;
    }
    
    internal static void LowerQualityBy(this Item item, int amount)
    {
       if (item.Quality > 0)
       { 
           item.Quality -= amount;
       }
    }

    internal static void RemoveQuality(this Item item)
    {
       item.LowerQualityBy(item.Quality);
    }

    internal static void IncreaseQualityBy(this Item item, int amount)
    {
       if (item.Quality < 50)
       { 
           item.Quality += amount;
       }
    }

    internal static void ReduceSellInDaysBy(this Item item, int amount)
    {
       item.SellIn -= amount;
    }

    private static ItemCategoryType Category(this Item item)
    {
       if (item.Name == "Aged Brie")
       {
           return AgedBrie;
       }

       if (item.Name.StartsWith("Backstage passes "))
       {
           return BackstagePass;
       }

       if (item.Name == "Sulfuras, Hand of Ragnaros")
       {
           return Legendary;
       }

       return Standard;
    }
}