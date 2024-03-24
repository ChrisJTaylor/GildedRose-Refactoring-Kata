using csharp.Core;

namespace csharp;

using static ContainerExtensions;
using SimpleInjector;
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
