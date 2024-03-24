using csharp.Inventory;

namespace csharp;
    
using ConvenienceExtensions;
using static ConvenienceExtensions.ContainerExtensions;
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

        Console.WriteLine("OMGHAI!");

        var datePeriodProcessor = _container.GetInstance<DatePeriodProcessor>();
        
        datePeriodProcessor.ProcessDaysBetween(0, 31);
    }
}
