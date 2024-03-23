using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace csharp.Specs.WhenUpdatingTheQuality.OfBackstagePasses;

public class WithMaxQualityBeforeItsSellByDate
{
    private readonly IList<Item> _items = new List<Item>();
    
    [OneTimeSetUp]
    public void BeforeAll()
    {
        _items.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 50 });
        
        var app = new GildedRose(_items);
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
        _items.Should().AllSatisfy(item => item.SellIn.Should().Be(10));
    }
}