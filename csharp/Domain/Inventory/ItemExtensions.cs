namespace csharp.Domain.Inventory;

using static Constants;
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
        item.Quality -= amount;

        const int minimumQualityForStandardItems = 0;
        item.EnsureQualityIsNotBelow(minimumQualityForStandardItems);
    }

    internal static void RemoveQuality(this Item item)
    {
       item.LowerQualityBy(item.Quality);
    }

    internal static void IncreaseQualityBy(this Item item, int amount)
    {
        item.Quality += amount;

        const int maximumQualityForStandardItems = 50;
        item.EnsureQualityIsNotAbove(maximumQualityForStandardItems);
    }

    internal static void ReduceSellInDaysBy(this Item item, int amount)
    {
       item.SellIn -= amount;
    }
    
    private static void EnsureQualityIsNotBelow(this Item item, int amount)
    {
        if (item.Quality <= amount)
        {
            item.Quality = amount;
        }
    }
    
    private static void EnsureQualityIsNotAbove(this Item item, int amount)
    {
        if (item.Quality >= amount)
        {
            item.Quality = amount;
        }
    }

    private static ItemCategoryType Category(this Item item)
    {
       if (item.Name.Equals(ItemIdentifiers.AgedBrie, StringComparison.InvariantCultureIgnoreCase))
       {
           return AgedBrie;
       }

       if (item.Name.StartsWith(ItemIdentifiers.BackstagePasses))
       {
           return BackstagePass;
       }

       if (item.Name.Equals(ItemIdentifiers.Sulfuras, StringComparison.InvariantCultureIgnoreCase))
       {
           return Legendary;
       }

       if (item.Name.StartsWith(ItemIdentifiers.Conjured))
       {
           return Conjured;
       }

       return Standard;
    }
}