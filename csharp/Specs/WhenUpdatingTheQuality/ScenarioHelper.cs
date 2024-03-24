using csharp.Inventory.UpdateStrategies;

namespace csharp.Specs.WhenUpdatingTheQuality;

internal static class ScenarioHelper
{
    internal static IFixture CreateScenarioFixtureWith(IList<Item> items)
    {
        var fixture = new Fixture();
        fixture.Register(() => items);
        fixture.Register<IUpdateItemStrategy[]>(() => [
            fixture.Create<UpdateStandardItem>(),
            fixture.Create<UpdateBackstagePassItem>(),
            fixture.Create<UpdateAgedBrieItem>(),
            fixture.Create<UpdateConjuredItem>()
        ]);
        return fixture;
    }
}