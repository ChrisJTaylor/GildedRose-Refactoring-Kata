using csharp.ConsoleApp;
using csharp.ConsoleApp.Domain;

namespace csharp.Tests.Specs.WhenUpdatingTheQuality.OfConjuredItems;

public class AfterTheirSellByDate
{
    private readonly IList<Item> _items = new List<Item>();
    
    [OneTimeSetUp]
    public void BeforeAll()
    {
        _items.Add(new Item { Name = "Conjured Sword", SellIn = 0, Quality = 10 });
        _items.Add(new Item { Name = "Conjured Shield", SellIn = 0, Quality = 10 });
        _items.Add(new Item { Name = "Conjured Dagger", SellIn = 0, Quality = 10 });
        
        var fixture = ScenarioHelper.CreateScenarioFixtureWith(_items);
        var app = fixture.Create<GildedRose>();
        
        app.UpdateQuality();
    }

    [Test]
    public void TheQualityShouldLowerByFour()
    {
        _items.Should().AllSatisfy(item => item.Quality.Should().Be(6));
    }
    
    [Test]
    public void TheSellInDaysShouldLowerByOne()
    {
        _items.Should().AllSatisfy(item => item.SellIn.Should().Be(-1));
    }
}