namespace The_Average_Vending_Machine;

public class User
{
    public string Name { get; set; }
    public decimal WalletAmount { get; set; }

    public User(string name, decimal walletAmount)
    {
        Name = name;
        WalletAmount = walletAmount;
    }

    public bool CanAfford(decimal price)
    {
        return WalletAmount >= price;
    }

    public void DeductMoney(decimal amount)
    {
        WalletAmount -= amount;
    }
}
