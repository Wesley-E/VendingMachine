using System.Reflection.Metadata;
using Newtonsoft.Json;

namespace VendingMachine.Models;

public class Products
{
    private readonly Dictionary<string, Product>? _products;
    public Products(string productFile)
    {
        using var r = new StreamReader(productFile);
        var json = r.ReadToEnd();
        _products = JsonConvert.DeserializeObject<Dictionary<string, Product>>(json);
    }

    public void Display()
    {
        if (_products == null) return;
        for (var index = 0; index < _products.Count; index++)
        {
            var productName = _products.Keys.ElementAt(index);
            var productPrice = _products.Values.ElementAt(index).price;
            Console.WriteLine($"{index} - {productName}: {productPrice}");
        }
    }

    public Tuple<string?, Product?>? Select(int selection)
    {
        try
        {
            return new Tuple<string?, Product?>(_products?.Keys.ElementAt(selection),
                _products?.Values.ElementAt(selection));
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine($"Invalid product selection {selection}. \nPlease select from the following: ");
            Display();
        }

        return null;
    }

    public class Product
    {
        public decimal price;
        public int quantity;
    }
    
}