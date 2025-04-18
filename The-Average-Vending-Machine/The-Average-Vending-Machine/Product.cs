namespace The_Average_Vending_Machine;

public class Product
{
    public string Name { get; }
    public decimal Price { get; }
    public string Placement { get; }
    public int Quantity { get; set; }

    public Product(string name, decimal price, string placement, int quantity)
    {
        Name = name;
        Price = price;
        Placement = placement;
        Quantity = quantity;
    }
}