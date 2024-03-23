namespace csharp.Inventory.UpdateStrategies;

class UpdateLegendaryUpdateItem : IUpdateItemStrategy
{
    public void UpdateItem(Item item)
    {
        if (item.IsNot(ItemCategoryType.Legendary)) return;
        
        item.IncreaseQualityBy(1);
    }
}