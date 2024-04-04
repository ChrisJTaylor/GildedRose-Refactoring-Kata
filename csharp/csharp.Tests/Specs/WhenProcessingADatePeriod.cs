using csharp.ConsoleApp.Domain;
using csharp.ConsoleApp.Domain.Inventory;

namespace csharp.Tests.Specs;

using static _Helpers.TestHelperExtensions;

public class WhenProcessingADatePeriod
{
   private Mock<GildedRose> _gildedRose;
   private InventoryProcessor _systemUnderTest;

   [SetUp]
   public void BeforeEach()
   {
      var fixture = CreateFixture();
      _gildedRose = fixture.CreateAndRegisterMockOf<GildedRose>();
      _systemUnderTest = fixture.Create<InventoryProcessor>();
   }

   [TestCase(0, 1, 1)]
   [TestCase(0, 31, 31)]
   [TestCase(5, 10, 5)]
   [TestCase(21, 27, 6)]
   public void ItShouldCallTheGildedRoseForEachDayInThePeriod(int startDay, int endDay, int expectedCallCount)
   {
      _systemUnderTest.ProcessDaysBetween(startDay: startDay, endDay: endDay);
      _gildedRose.Verify(gildedRose => gildedRose.UpdateQuality(), Times.Exactly(expectedCallCount));
   }
}