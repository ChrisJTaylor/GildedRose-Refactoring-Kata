namespace csharp.Specs.WhenUpdatingTheQuality;

internal static class ScenarioHelper
{
    internal static IFixture CreateScenarioFixtureWith(IList<Item> items)
    {
        var fixture = new Fixture();
        fixture.Register(() => items);
        return fixture;
    }
}