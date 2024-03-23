using csharp.Inventory;

namespace csharp;

public sealed class GildedRose
{
    private readonly IList<Item> _items;
    private readonly InventoryItemProcessor _inventoryItemProcessor;

    public GildedRose(IList<Item> items, InventoryItemProcessor inventoryItemProcessor)
    {
        _items = items;
        _inventoryItemProcessor = inventoryItemProcessor;
    }

    public void UpdateQuality()
    {
        foreach (var currentItem in _items)
        {
            _inventoryItemProcessor.UpdateItemProperties(currentItem);
        }
    }
}