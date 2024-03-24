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
            .RegisterInventoryData(InventoryData.Seed());

        var items = _container.GetInstance<IList<Item>>();
        
        Console.WriteLine("OMGHAI!");

        var app = _container.GetInstance<GildedRose>();

        for (var i = 0; i < 31; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j]);
            }
            Console.WriteLine("");
            app.UpdateQuality();
        }
    }
    
}
