using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Specs.WhenUpdatingTheQuality.OfStandardItems;

public class AfterTheirSellByDate
{
    private readonly IList<Item> _items = new List<Item>();
    
    [OneTimeSetUp]
    public void BeforeAll()
    {
        _items.Add(new Item { Name = "Sword", SellIn = 0, Quality = 10 });
        _items.Add(new Item { Name = "Shield", SellIn = 0, Quality = 10 });
        _items.Add(new Item { Name = "Dagger", SellIn = 0, Quality = 10 });
        
        var app = new GildedRose(_items);
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
        _items.Should().AllSatisfy(item => item.SellIn.Should().Be(-1));
    }
}