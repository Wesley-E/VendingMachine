using VendingMachine.Models;
using VendingMachine.Models.StateMachine;
using VendingMachine.ValueSets;

namespace VendingMachine.Services;

public class SelectProductService : IService
{
    public Context? Process(Context? context)
    {
        Console.WriteLine("Select A Product");
        var products =
            new Products("/Users/dominiceccles/Projects/VendingMachine/VendingMachine/Repository/products.json");
        products.Display();
        
        while (!Console.KeyAvailable)
        {
            var keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Backspace)
                break;
            if (int.TryParse(keyInfo.KeyChar.ToString(), out var selection))
            {
                var (productName, productInfo) = products.Select(selection);
                Console.WriteLine(productName);
                if (productName == null) continue;
                context.VendingContext.SelectedProductName = productName;
                context.VendingContext.SelectedProductInfo = productInfo;
                break;
            }
        }
        return context;
    }
}