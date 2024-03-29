using Microsoft.Extensions.Logging.Console;
using SimpleInjector;

namespace csharp.Core;

internal static class ContainerExtensions
{
    internal static Container InitialiseContainer()
    {
        var container = new Container();
        container.Options.ResolveUnregisteredConcreteTypes = true;

        return container;
    }

    internal static Container RegisterItemProcessingStrategies(this Container container)
    {
        container.Collection.Register<IUpdateItemStrategy>(
            typeof(UpdateStandardItem),
            typeof(UpdateAgedBrieItem),
            typeof(UpdateBackstagePassItem),
            typeof(UpdateConjuredItem));

        return container;
    }

    internal static Container RegisterComponents(this Container container)
    {
        var factory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole(options => options.FormatterName = PlainLogFormatter.FormatterName);
            builder.AddConsoleFormatter<PlainLogFormatter, ConsoleFormatterOptions>();
        });
        container.Register(() => factory.CreateLogger<InventoryProcessor>());
        return container;
    }
    
    internal static Container RegisterInventoryData(this Container container, IList<Item> items)
    {
        container.RegisterInstance(items);

        return container;
    }
}