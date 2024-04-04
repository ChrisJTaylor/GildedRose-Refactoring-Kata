namespace csharp.ConsoleApp.Domain.Inventory.UpdateStrategies;

internal class UpdateStandardItem : IUpdateItemStrategy
{
    public void UpdateItem(Item item)
    {
        if (item.IsNot(ItemCategoryType.Standard)) return;
        
        item.LowerQualityBy(1);
        
        item.ReduceSellInDaysBy(1);

        if (item.IsPastSellByDate()) 
        {
            item.LowerQualityBy(1);
        }
    }
}