using csharp.ConsoleApp;
using csharp.ConsoleApp.Domain.Inventory.UpdateStrategies;

namespace csharp.Tests.Specs.WhenUpdatingTheQuality;

using static _Helpers.TestHelperExtensions;

internal static class ScenarioHelper
{
    internal static IFixture CreateScenarioFixtureWith(IList<Item> items)
    {
        var fixture = CreateFixture();
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