using csharp.ConsoleApp;
using csharp.ConsoleApp.Domain;

namespace csharp.Tests.Specs.WhenUpdatingTheQuality.OfAgedBrie;

public class AfterItsSellByDate
{
    private readonly IList<Item> _items = new List<Item>();
    
    [OneTimeSetUp]
    public void BeforeAll()
    {
        _items.Add(new Item { Name = "Aged Brie", SellIn = -1, Quality = 10 });
        
        var fixture = ScenarioHelper.CreateScenarioFixtureWith(_items);
        var app = fixture.Create<GildedRose>();
        
        app.UpdateQuality();
    }

    [Test]
    public void TheQualityShouldIncreaseByTwo()
    {
        _items.Should().AllSatisfy(item => item.Quality.Should().Be(12));
    }
    
    [Test]
    public void TheSellInDaysShouldLowerByOne()
    {
        _items.Should().AllSatisfy(item => item.SellIn.Should().Be(-2));
    }
}