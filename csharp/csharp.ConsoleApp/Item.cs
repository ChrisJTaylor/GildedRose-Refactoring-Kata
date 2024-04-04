namespace csharp.ConsoleApp;

using QualityQuotient = int;
using Days = int;

public class Item
{
    public string Name { get; set; }
    public Days SellIn { get; set; }
    public QualityQuotient Quality { get; set; }

    public override string ToString()
    {
        return $"{Name}, {SellIn}, {Quality}";
    }  
}