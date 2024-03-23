using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Specs.WhenUpdatingTheQuality.OfSulfuras;

public class BeforeItsSellByDate
{
    private readonly IList<Item> _items = new List<Item>();
    
    [OneTimeSetUp]
    public void BeforeAll()
    {
        _items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 });
        
        var app = new GildedRose(_items);
        app.UpdateQuality();
    }

    [Test]
    public void TheQualityShouldNotChange()
    {
        _items.Should().AllSatisfy(item => item.Quality.Should().Be(80));
    }
    
    [Test]
    public void TheSellInDaysShouldNotChange()
    {
        _items.Should().AllSatisfy(item => item.SellIn.Should().Be(10));
    }
}