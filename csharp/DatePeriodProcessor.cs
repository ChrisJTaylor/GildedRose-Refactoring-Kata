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

    internal void ProcessDaysBetween(int startDay, int endDay)
    {
        for (var dayIndex = startDay; dayIndex < endDay; dayIndex++)
        {
            Console.WriteLine("-------- day " + dayIndex + " --------");
            Console.WriteLine("name, sellIn, quality");
            foreach (var itemIndex in _inventoryItems)
            {
                Console.WriteLine(itemIndex);
            }
            Console.WriteLine("");
            _gildedRose.UpdateQuality();
        }
    }
}