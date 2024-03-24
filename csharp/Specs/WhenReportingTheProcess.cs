namespace csharp.Specs;

using _Helpers;
using static _Helpers.TestHelperExtensions;

public class WhenReportingTheProcess
{
   private Mock<ILogger<InventoryProcessor>> _logger;
   private InventoryProcessor _systemUnderTest;
   
   private static object[] _datePeriods =
   {
      new object[] { 0, 1, 1 },
      new object[] { 0, 31, 31 },
      new object[] { 5, 10, 5 },
      new object[] { 21, 27, 6 }
   };

   private IList<Item> _inventoryItems;

   [SetUp]
   public void BeforeEach()
   {
      var fixture = CreateFixture();
      _logger = fixture.Freeze<Mock<ILogger<InventoryProcessor>>>();
      _inventoryItems = fixture.Freeze<IList<Item>>();
      _systemUnderTest = fixture.Create<InventoryProcessor>();
   }

   [TestCaseSource(nameof(_datePeriods))]
   public void ItShouldLogTheWelcomeMessageOnlyOnce(int startDay, int endDay, int _)
   {
      _systemUnderTest.ProcessDaysBetween(startDay: startDay, endDay: endDay);
      
      _logger.VerifyLogWasCalled(withMessage: "OMGHAI!", Times.Once());
   }
   
   [TestCaseSource(nameof(_datePeriods))]
   public void ItShouldLogTheDayIndexLineForEachDay(int startDay, int endDay, int _)
   {
      _systemUnderTest.ProcessDaysBetween(startDay: startDay, endDay: endDay);

      for (var dayIndex = startDay; dayIndex < endDay; dayIndex++)
      {
         _logger.VerifyLogWasCalled(withMessage: $"-------- day {dayIndex} --------", Times.Once());
      }
   }
   
   [TestCaseSource(nameof(_datePeriods))]
   public void ItShouldLogTheHeaderLineForEachDay(int startDay, int endDay, int expectedCallCount)
   {
      _systemUnderTest.ProcessDaysBetween(startDay: startDay, endDay: endDay);
      
      _logger.VerifyLogWasCalled(withMessage: "name, sellIn, quality", Times.Exactly(expectedCallCount));
   }
   
   [TestCaseSource(nameof(_datePeriods))]
   public void ItShouldLogAllInventoryItemDetailsForEachDay(int startDay, int endDay, int expectedCallCount)
   {
      _systemUnderTest.ProcessDaysBetween(startDay: startDay, endDay: endDay);

      foreach (var item in _inventoryItems)
      {
         _logger.VerifyLogWasCalled(withMessage: item.ToString(), Times.Exactly(expectedCallCount));
      }
   }
   
   [TestCaseSource(nameof(_datePeriods))]
   public void ItShouldLogABlankLineForEachDay(int startDay, int endDay, int expectedCallCount)
   {
      _systemUnderTest.ProcessDaysBetween(startDay: startDay, endDay: endDay);
      
      _logger.VerifyLogWasCalled(withMessage: "", Times.Exactly(expectedCallCount));
   }
}