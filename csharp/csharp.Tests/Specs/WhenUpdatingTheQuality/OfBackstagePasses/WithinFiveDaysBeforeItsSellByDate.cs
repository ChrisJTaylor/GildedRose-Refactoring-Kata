using csharp.ConsoleApp;
using csharp.ConsoleApp.Domain;

namespace csharp.Tests.Specs.WhenUpdatingTheQuality.OfBackstagePasses;

public class WithinFiveDaysBeforeItsSellByDate
{
    private readonly IList<Item> _items = new List<Item>();
    
    [OneTimeSetUp]
    public void BeforeAll()
    {
        _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 10 });
        
        var fixture = ScenarioHelper.CreateScenarioFixtureWith(_items);
        var app = fixture.Create<GildedRose>();
        
        app.UpdateQuality();
    }

    [Test]
    public void TheQualityShouldIncreaseByThree()
    {
        _items.Should().AllSatisfy(item => item.Quality.Should().Be(13));
    }
    
    [Test]
    public void TheSellInDaysShouldLowerByOne()
    {
        _items.Should().AllSatisfy(item => item.SellIn.Should().Be(3));
    }
}