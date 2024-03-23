namespace csharp.Inventory.UpdateStrategies;

internal class UpdateLegendaryUpdateItem : IUpdateItemStrategy
{
    public void UpdateItem(Item item)
    {
        if (item.IsNot(ItemCategoryType.Legendary)) return;
        
        item.IncreaseQualityBy(1);
    }
}