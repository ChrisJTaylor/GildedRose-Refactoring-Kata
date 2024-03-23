namespace csharp.Specs.WhenUpdatingTheQuality.OfAgedBrie;

public class WithMaxQualityBeforeItsSellByDate
{
    private readonly IList<Item> _items = new List<Item>();
    
    [OneTimeSetUp]
    public void BeforeAll()
    {
        _items.Add(new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 });
        
        var fixture = ScenarioHelper.CreateScenarioFixtureWith(_items);
        var app = fixture.Create<GildedRose>();
        
        app.UpdateQuality();
    }

    [Test]
    public void TheQualityShouldNotChange()
    {
        _items.Should().AllSatisfy(item => item.Quality.Should().Be(50));
    }
    
    [Test]
    public void TheSellInDaysShouldLowerByOne()
    {
        _items.Should().AllSatisfy(item => item.SellIn.Should().Be(4));
    }
}