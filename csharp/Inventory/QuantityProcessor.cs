using static csharp.Inventory.ItemCategoryType;

namespace csharp.Inventory;

public sealed class QuantityProcessor
{
    public void Update(Item item)
    {
        UpdateStandardItem(item);
        UpdateAgedBrieItem(item);
        UpdateBackstagePassItem(item);
        UpdateLegendaryItem(item);
    }

    private void UpdateLegendaryItem(Item item)
    {
        if (item.IsNot(Legendary)) return;
        
        item.IncreaseQualityBy(1);
    }

    private void UpdateBackstagePassItem(Item item)
    {
        if (item.IsNot(BackstagePass)) return;
        
        item.IncreaseQualityBy(1);
        
        if (item.SellIn < 11)
        {
            item.IncreaseQualityBy(1);
        }

        if (item.SellIn < 6)
        {
            item.IncreaseQualityBy(1);
        }
        
        item.ReduceSellInDaysBy(1);
        if (item.IsPastSellByDate()) 
        {
            item.RemoveQuality();
        }
    }

    private void UpdateAgedBrieItem(Item item)
    {
        if (item.IsNot(AgedBrie)) return;
        
        item.IncreaseQualityBy(1);
        item.ReduceSellInDaysBy(1);

        if (item.IsPastSellByDate())
        {
            item.IncreaseQualityBy(1);
        }
    }

    private void UpdateStandardItem(Item item)
    {
        if (item.IsNot(Standard)) return;
        
        item.LowerQualityBy(1);
        
        item.ReduceSellInDaysBy(1);

        if (item.IsPastSellByDate()) 
        {
            item.LowerQualityBy(1);
        }
    }
}