using csharp.ConsoleApp.Core;
using csharp.ConsoleApp.Domain.Inventory;

namespace csharp.ConsoleApp;

using static ContainerExtensions;

public class Program
{
    private static Container _container;

    public static void Main(string[] args)
    {
        _container = InitialiseContainer()
            .RegisterItemProcessingStrategies()
            .RegisterComponents()
            .RegisterInventoryData(InventoryData.Seed());

        var inventoryProcessor = _container.GetInstance<InventoryProcessor>();
        inventoryProcessor.ProcessDaysBetween(0, 31);
    }
}
