using csharp.Core.ConvenienceExtensions;
using csharp.Domain.Inventory;

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

        var datePeriodProcessor = _container.GetInstance<InventoryProcessor>();
        
        datePeriodProcessor.ProcessDaysBetween(0, 31);
    }
}
