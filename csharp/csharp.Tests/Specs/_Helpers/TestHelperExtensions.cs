namespace csharp.Tests.Specs._Helpers;

internal static class TestHelperExtensions
{
    internal static IFixture CreateFixture()
    {
        return new Fixture().Customize(new AutoMoqCustomization());
    }
    internal static void VerifyLogWasCalled<TType>(this Mock<ILogger<TType>> mockLogger, string withMessage, Times times, LogLevel level = LogLevel.Information)
    {
        mockLogger.Verify(logger => logger.Log(level,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((actualMessage, _) => actualMessage.ToString().Equals(withMessage, StringComparison.InvariantCultureIgnoreCase)),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            times);
    }

    internal static Mock<TType> CreateAndRegisterMockOf<TType>(this IFixture fixture) where TType : class
    {
        var mockObj = fixture.Create<Mock<TType>>();
        fixture.Register(() => mockObj);
        fixture.Register(() => mockObj.Object);
        return mockObj;
    }
}