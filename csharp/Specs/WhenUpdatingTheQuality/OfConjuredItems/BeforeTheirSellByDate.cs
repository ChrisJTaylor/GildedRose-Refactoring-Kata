namespace csharp.Specs.WhenUpdatingTheQuality.OfConjuredItems;

public class BeforeTheirSellByDate
{
    private readonly IList<Item> _items = new List<Item>();
    
    [OneTimeSetUp]
    public void BeforeAll()
    {
        _items.Add(new Item { Name = "Conjured Sword", SellIn = 5, Quality = 10 });
        _items.Add(new Item { Name = "Conjured Shield", SellIn = 5, Quality = 10 });
        _items.Add(new Item { Name = "Conjured Dagger", SellIn = 5, Quality = 10 });
        
        var fixture = ScenarioHelper.CreateScenarioFixtureWith(_items);
        var app = fixture.Create<GildedRose>();
        
        app.UpdateQuality();
    }

    [Test]
    public void TheQualityShouldLowerByTwo()
    {
        _items.Should().AllSatisfy(item => item.Quality.Should().Be(8));
    }
    
    [Test]
    public void TheSellInDaysShouldLowerByOne()
    {
        _items.Should().AllSatisfy(item => item.SellIn.Should().Be(4));
    }
}