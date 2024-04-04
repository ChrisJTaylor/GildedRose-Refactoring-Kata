using csharp.ConsoleApp;
using csharp.ConsoleApp.Domain;

namespace csharp.Tests.Specs.WhenUpdatingTheQuality.OfBackstagePasses;

public class MoreThanTenDaysBeforeItsSellByDate
{
    private readonly IList<Item> _items = new List<Item>();
    
    [OneTimeSetUp]
    public void BeforeAll()
    {
        _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 });
        
        var fixture = ScenarioHelper.CreateScenarioFixtureWith(_items);
        var app = fixture.Create<GildedRose>();
        
        app.UpdateQuality();
    }

    [Test]
    public void TheQualityShouldIncreaseByOne()
    {
        _items.Should().AllSatisfy(item => item.Quality.Should().Be(11));
    }
    
    [Test]
    public void TheSellInDaysShouldLowerByOne()
    {
        _items.Should().AllSatisfy(item => item.SellIn.Should().Be(10));
    }
}