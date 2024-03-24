namespace csharp.ConvenienceExtensions;

using Inventory.UpdateStrategies;
using SimpleInjector;

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
    
    internal static Container RegisterInventoryData(this Container container, IList<Item> items)
    {
        container.RegisterInstance(items);

        return container;
    }
}