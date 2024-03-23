using static csharp.ItemCategoryType;

namespace csharp;

public class GildedRose
{
    private readonly IList<Item> _items;
    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            var currentItem = _items[i];
            
            if (currentItem.Is(Standard))
            {
                currentItem.LowerQualityBy(1);
            }
            else
            {
                currentItem.IncreaseQualityBy(1);

                if (currentItem.Is(BackstagePass))
                {
                    if (currentItem.SellIn < 11)
                    {
                        currentItem.IncreaseQualityBy(1);
                    }

                    if (currentItem.SellIn < 6)
                    {
                        currentItem.IncreaseQualityBy(1);
                    }
                }
            }

            if (currentItem.IsNot(Legendary))
            {
                currentItem.ReduceSellInDaysBy(1);
            }

            if (currentItem.IsPassedSellByDate())
            {
                if (currentItem.IsPerishable())
                {
                    currentItem.LowerQualityBy(1);
                    
                    if (currentItem.Is(BackstagePass))
                    {
                        currentItem.RemoveQuality();
                    }
                }
                else
                {
                    currentItem.IncreaseQualityBy(1);
                }
            }
        }
    }
}