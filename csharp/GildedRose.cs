namespace csharp;
using Inventory.UpdateStrategies;

public sealed class GildedRose : IGildedRose
{
    IList<Item> Items;
    private readonly IUpdateItemStrategy[] _updateItemStrategies;

    public GildedRose(IList<Item> items, IUpdateItemStrategy[] updateItemStrategies)
    {
        Items = items;
        _updateItemStrategies = updateItemStrategies;
    }

    public void UpdateQuality()
    {
        foreach (var currentItem in Items)
        {
            foreach (var updateItemStrategy in _updateItemStrategies)
            {
                updateItemStrategy.UpdateItem(currentItem);
            }
        }
    }
}