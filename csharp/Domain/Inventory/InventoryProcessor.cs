namespace csharp.Domain.Inventory;

public class InventoryProcessor
{
    private readonly IGildedRose _gildedRose;
    private readonly IList<Item> _inventoryItems;
    private readonly ILogger<InventoryProcessor> _logger;

    public InventoryProcessor(IGildedRose gildedRose, IList<Item> inventoryItems, ILogger<InventoryProcessor> logger)
    {
        _gildedRose = gildedRose;
        _inventoryItems = inventoryItems;
        _logger = logger;
    }

    internal void ProcessDaysBetween(int startDay, int endDay)
    {
        _logger.LogInformation("OMGHAI!");
        
        for (var dayIndex = startDay; dayIndex < endDay; dayIndex++)
        {
            _logger.LogInformation($"-------- day {dayIndex} --------");
            _logger.LogInformation("name, sellIn, quality");
            
            foreach (var itemIndex in _inventoryItems)
            {
                _logger.LogInformation(itemIndex.ToString());
            }
            
            _logger.LogInformation("");
            
            _gildedRose.UpdateQuality();
        }
    }
}