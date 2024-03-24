namespace csharp.Domain.Inventory.UpdateStrategies;

internal class UpdateAgedBrieItem : IUpdateItemStrategy
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