namespace csharp;

internal class DatePeriodProcessor
{
    private readonly IGildedRose _gildedRose;
    private readonly IList<Item> _inventoryItems;

    public DatePeriodProcessor(IGildedRose gildedRose, IList<Item> inventoryItems)
    {
        _gildedRose = gildedRose;
        _inventoryItems = inventoryItems;
    }

    public void ProcessDaysBetween(int startDay, int endDay)
    {
        for (var dayIndex = startDay; dayIndex < endDay; dayIndex++)
        {
            Console.WriteLine("-------- day " + dayIndex + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < _inventoryItems.Count; j++)
            {
                Console.WriteLine(_inventoryItems[j]);
            }
            Console.WriteLine("");
            _gildedRose.UpdateQuality();
        }
    }
}