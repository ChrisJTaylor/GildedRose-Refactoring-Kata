namespace csharp.ConsoleApp.Domain.Inventory.UpdateStrategies;

public interface IUpdateItemStrategy
{
    void UpdateItem(Item item);
}