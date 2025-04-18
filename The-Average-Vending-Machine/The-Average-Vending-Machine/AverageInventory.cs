namespace The_Average_Vending_Machine;

public class AverageInventory
{
    public List<Product> Products { get; private set; }

    public AverageInventory()
    {
        InitializeInventory();
    }

    private void InitializeInventory()
    {
        Products = new List<Product>
        {
            new Product("Snickers", 10, "A1", 10),
            new Product("Twix", 11, "A2", 10),
            new Product("Maltesers", 18, "A3", 10),
            new Product("Kryptoniter", 15, "B1", 10),
            new Product("Turkisk peppar", 10, "B2", 10),
            new Product("Salta grodor", 12, "B3", 10),
            new Product("Sura bilar", 20, "C1", 10),
            new Product("Djungelvrål", 14, "C2", 10),
            new Product("Hallon skallar", 15, "C3", 10),
        };
    }

    public void DisplayInventory()
    {
        Console.WriteLine("====== AVAILABLE PRODUCTS ======");
        Console.WriteLine("Placement | Product Name | Price | Quantity");
        Console.WriteLine("--------------------------------------");
        
        foreach (var product in Products)
        {
            if (product.Quantity > 0)
            {
                Console.WriteLine($"{product.Placement} | {product.Name} | ${product.Price:F2} | {product.Quantity} left");
            }
        }
        Console.WriteLine("==============================");
    }

    public Product? GetProductByPlacement(string placement)
    {
        return Products.FirstOrDefault(product => product.Placement.Equals(placement, StringComparison.OrdinalIgnoreCase));
    }

    public bool PurchaseProduct(string placement)
    {
        var product = GetProductByPlacement(placement);
        
        if (product == null || product.Quantity <= 0)
        {
            return false;
        }
        
        product.Quantity--;
        return true;
    }
}