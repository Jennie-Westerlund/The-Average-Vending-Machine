namespace The_Average_Vending_Machine;

public class TheAverageBank
{
    private User? _currentUser;

    public void SetUser(User user)
    {
        _currentUser = user;
    }

    public decimal GetWalletAmount()
    {
        return _currentUser?.WalletAmount ?? 0;
    }

    public bool ProcessPayment(decimal amount)
    {
        if (_currentUser == null || !_currentUser.CanAfford(amount))
        {
            return false;
        }

        _currentUser.DeductMoney(amount);
        return true;
    }

    public bool IsBroke()
    {
        //function to determine broke-status
    }
}