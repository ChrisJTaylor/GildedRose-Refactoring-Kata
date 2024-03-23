namespace csharp.Inventory.UpdateStrategies;

internal class UpdateAgedBrieUpdateItem : IUpdateItemStrategy
{
    public void UpdateItem(Item item)
    {
        if (item.IsNot(ItemCategoryType.AgedBrie)) return;
        
        item.IncreaseQualityBy(1);
        item.ReduceSellInDaysBy(1);

        if (item.IsPastSellByDate())
        {
            item.IncreaseQualityBy(1);
        }
    }
}