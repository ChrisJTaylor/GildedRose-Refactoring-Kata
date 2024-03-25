﻿namespace csharp.Domain;

public sealed class GildedRose : IGildedRose
{
    private readonly IList<Item> _items;
    private readonly IUpdateItemStrategy[] _updateItemStrategies;

    public GildedRose(IList<Item> items, IUpdateItemStrategy[] updateItemStrategies)
    {
        _items = items;
        _updateItemStrategies = updateItemStrategies;
    }

    public void UpdateQuality()
    {
        foreach (var currentItem in _items)
        {
            foreach (var updateItemStrategy in _updateItemStrategies)
            {
                updateItemStrategy.UpdateItem(currentItem);
            }
        }
    }
}