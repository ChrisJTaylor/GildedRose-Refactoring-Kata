using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Specs.WhenUpdatingTheQuality.OfAgedBrie;

public class BeforeItsSellByDate
{
    private readonly IList<Item> _items = new List<Item>();
    
    [OneTimeSetUp]
    public void BeforeAll()
    {
        _items.Add(new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 });
        
        var app = new GildedRose(_items);
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
        _items.Should().AllSatisfy(item => item.SellIn.Should().Be(4));
    }
}