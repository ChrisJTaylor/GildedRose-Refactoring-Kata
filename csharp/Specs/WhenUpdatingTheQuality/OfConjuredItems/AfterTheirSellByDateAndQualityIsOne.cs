namespace csharp.Specs.WhenUpdatingTheQuality.OfConjuredItems;

public class AfterTheirSellByDateAndQualityIsOne
{
    private readonly IList<Item> _items = new List<Item>();
    
    [OneTimeSetUp]
    public void BeforeAll()
    {
        _items.Add(new Item { Name = "Conjured Sword", SellIn = 0, Quality = 1 });
        _items.Add(new Item { Name = "Conjured Shield", SellIn = 0, Quality = 1 });
        _items.Add(new Item { Name = "Conjured Dagger", SellIn = 0, Quality = 1 });
        
        var fixture = ScenarioHelper.CreateScenarioFixtureWith(_items);
        var app = fixture.Create<GildedRose>();
        
        app.UpdateQuality();
    }

    [Test]
    public void TheQualityShouldNotDropBelowZero()
    {
        _items.Should().AllSatisfy(item => item.Quality.Should().Be(0));
    }
    
    [Test]
    public void TheSellInDaysShouldLowerByOne()
    {
        _items.Should().AllSatisfy(item => item.SellIn.Should().Be(-1));
    }
}