namespace csharp.Inventory.UpdateStrategies;

internal class UpdateBackstagePassUpdateItem : IUpdateItemStrategy
{
    public void UpdateItem(Item item)
    {
        if (item.IsNot(ItemCategoryType.BackstagePass)) return;
        
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
}