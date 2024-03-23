namespace csharp.Inventory;

public sealed class InventoryItemProcessor 
{
    private readonly QuantityProcessor _quantityProcessor;

    public InventoryItemProcessor(QuantityProcessor quantityProcessor)
    {
        _quantityProcessor = quantityProcessor;
    }
    public void UpdateItemProperties(Item inventoryItem)
    {
        _quantityProcessor.Update(inventoryItem);
    }
}