namespace csharp.Inventory;

public sealed class InventoryItemProcessor 
{
    public void UpdateItemProperties(Item inventoryItem)
    {
        if (inventoryItem.Is(ItemCategoryType.Standard))
        {
            inventoryItem.LowerQualityBy(1);
        }
        else
        {
            inventoryItem.IncreaseQualityBy(1);

            if (inventoryItem.Is(ItemCategoryType.BackstagePass))
            {
                if (inventoryItem.SellIn < 11)
                {
                    inventoryItem.IncreaseQualityBy(1);
                }

                if (inventoryItem.SellIn < 6)
                {
                    inventoryItem.IncreaseQualityBy(1);
                }
            }
        }

        if (inventoryItem.IsNot(ItemCategoryType.Legendary))
        {
            inventoryItem.ReduceSellInDaysBy(1);
        }

        if (inventoryItem.IsPassedSellByDate())
        {
            if (inventoryItem.IsPerishable())
            {
                inventoryItem.LowerQualityBy(1);
                    
                if (inventoryItem.Is(ItemCategoryType.BackstagePass))
                {
                    inventoryItem.RemoveQuality();
                }
            }
            else
            {
                inventoryItem.IncreaseQualityBy(1);
            }
        }
    }
}