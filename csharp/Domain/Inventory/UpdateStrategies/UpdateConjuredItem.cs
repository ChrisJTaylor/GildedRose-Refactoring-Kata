namespace csharp.Domain.Inventory.UpdateStrategies;

internal class UpdateConjuredItem : IUpdateItemStrategy
{
    public void UpdateItem(Item item)
    {
        if (item.IsNot(ItemCategoryType.Conjured)) return;
        
        item.ReduceSellInDaysBy(1);
        
        item.LowerQualityBy(2);
        
        if (item.IsPastSellByDate())
        {
            item.LowerQualityBy(2);
        }
    }
}