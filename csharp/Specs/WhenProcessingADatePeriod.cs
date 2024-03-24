using AutoFixture.AutoMoq;
using Moq;

namespace csharp.Specs;

public class WhenProcessingADatePeriod
{
   private Mock<IGildedRose> _gildedRose;
   private DatePeriodProcessor _systemUnderTest;

   [SetUp]
   public void BeforeEach()
   {
      var fixture = new Fixture().Customize(new AutoMoqCustomization());
      _gildedRose = fixture.Freeze<Mock<IGildedRose>>();
      _systemUnderTest = fixture.Create<DatePeriodProcessor>();
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