namespace csharp.ConsoleApp.Domain.Inventory;

using static Constants;
using static ItemCategoryType;

using QualityQuotient = int;
using Days = int;

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
    
    internal static void LowerQualityBy(this Item item, QualityQuotient amount)
    {
        item.Quality -= amount;

        const int minimumQualityForStandardItems = 0;
        item.EnsureQualityIsNotBelow(minimumQualityForStandardItems);
    }

    internal static void RemoveQuality(this Item item)
    {
       item.LowerQualityBy(item.Quality);
    }

    internal static void IncreaseQualityBy(this Item item, QualityQuotient amount)
    {
        item.Quality += amount;

        const QualityQuotient maximumQualityForStandardItems = 50;
        item.EnsureQualityIsNotAbove(maximumQualityForStandardItems);
    }

    internal static void ReduceSellInDaysBy(this Item item, Days amount)
    {
       item.SellIn -= amount;
    }
    
    private static void EnsureQualityIsNotBelow(this Item item, QualityQuotient amount)
    {
        item.Quality = Math.Clamp(item.Quality, amount, 50);
    }
    
    private static void EnsureQualityIsNotAbove(this Item item, QualityQuotient amount)
    {
        item.Quality = Math.Clamp(item.Quality, 0, amount);
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