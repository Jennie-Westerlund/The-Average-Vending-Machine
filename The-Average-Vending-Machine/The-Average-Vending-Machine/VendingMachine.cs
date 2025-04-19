namespace The_Average_Vending_Machine;

public class VendingMachine
{
    private readonly TheAverageBank _bank;
    private readonly AverageInventory _inventory;
    private User? _currentUser;
    private Random _random;

    public List<string> Commands { get; } = new List<string>
    {
        "1",
        "2",
        "3",
        "help"
    };

    public VendingMachine()
    {
        _bank = new TheAverageBank();
        _inventory = new AverageInventory();
        _random = new Random();
    }

    public void SetUser(string name, decimal walletAmount)
    {
        _currentUser = new User(name, walletAmount);
        _bank.SetUser(_currentUser);
    }

    public void Run()
    {
        DisplayMenu();
        string commandInput;

        do
        {
            commandInput = GetCommand();
            string command = MapInputToCommand(commandInput);

            if (command == "Shop goodies")
            {
                ShopGoodies();
            }
            else if (command == "Look inside wallet")
            {
                CheckWallet();
            }
            else if (command == "help")
            {
                GetHelp();
            }

        } while (commandInput != "3");

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Thank you for using The Average Vending Machine!");
        Console.WriteLine("See you next time!");
        Console.ResetColor();
    }
    
    private void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("===== THE AVERAGE VENDING MACHINE =====");
        Console.WriteLine("1. Shop goodies");
        Console.WriteLine("2. Look inside wallet");
        Console.WriteLine("3. Leave The Average Vending Machine");
        Console.WriteLine("=====================================");
        Console.ResetColor();
    }

    private string MapInputToCommand(string input)
    {
        return input switch
        {
            "1" => "Shop goodies",
            "2" => "Look inside wallet",
            "3" => "Leave The Average Vending Machine",
            _ => input
        };
    }
    
    public string GetCommand()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Please enter a command (or type 'help'): ");
            Console.ResetColor();

            var input = Console.ReadLine()?.Trim() ?? "";

            if (Commands.Contains(input))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OK");
                Console.ResetColor();
                return input;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sorry, that is not a valid command...");
            Console.ResetColor();
            DisplayMenu();
        }
    }

    private void ShopGoodies()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("The Average Vending Machine Inventory");
        Console.ResetColor();
        
        _inventory.DisplayInventory();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Please enter the placement of the product you want (or 'back' to return to menu): ");
        Console.ResetColor();
        
        var placement = Console.ReadLine()?.Trim() ?? "";
        
        if (placement.Equals("back", StringComparison.OrdinalIgnoreCase))
        {
            DisplayMenu();
            return;
        }

        var product = _inventory.GetProductByPlacement(placement);

        if (product == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid product placement. Please try again.");
            Console.ResetColor();
            return;
        }

        if (product.Quantity <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Sorry, {product.Name} is out of stock.");
            Console.ResetColor();
            return;
        }

        if (!_currentUser.CanAfford(product.Price))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You don't have enough money!");
            Console.WriteLine($"You have ${_currentUser.WalletAmount:F2} but {product.Name} costs ${product.Price:F2}");
            Console.ResetColor();
            return;
        }

        
        if (_random.Next(1, 11) == 1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Oops... looks like {product.Name} got stuck. Do you want to slap the average vending machine?");
            Console.WriteLine("Yes or No?");
            Console.ResetColor();
            
            var response = Console.ReadLine()?.Trim().ToLower() ?? "";
            
            if (response == "Yes")
            {
                if (_random.Next(1, 3) == 1)
                {
                    _bank.ProcessPayment(product.Price);
                    _inventory.PurchaseProduct(placement);
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"*THUMP* The {product.Name} fell down! Enjoy your {product.Name}!");
                    Console.WriteLine($"You have ${_currentUser.WalletAmount:F2} left in your wallet.");
                    Console.ResetColor();
                }
                else
                {
                    _bank.ProcessPayment(product.Price);
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*THUMP* Nothing happened... You lost your money.");
                    Console.WriteLine($"You have ${_currentUser.WalletAmount:F2} left in your wallet.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You decided not to slap the machine. Wise choice, perhaps...");
                Console.ResetColor();
            }
        }
        else
        {
            _bank.ProcessPayment(product.Price);
            _inventory.PurchaseProduct(placement);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You purchased {product.Name} for ${product.Price:F2}");
            Console.WriteLine($"You have ${_currentUser.WalletAmount:F2} left in your wallet.");
            Console.ResetColor();
        }
        
        DisplayMenu();
    }

    private void CheckWallet()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Asking The Average Bank...");
        Console.ResetColor();
        
        if (_bank.IsBroke())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You are broke!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You have ${_currentUser.WalletAmount:F2} in your wallet.");
            Console.ResetColor();
        }
        
        DisplayMenu();
    }
    
    public void GetHelp()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("===== AVAILABLE COMMANDS =====");
        Console.WriteLine("1. Shop goodies");
        Console.WriteLine("2. Look inside wallet");
        Console.WriteLine("3. Leave The Average Vending Machine");
        Console.WriteLine("==============================");
        Console.ResetColor();
        
        DisplayMenu();
    }
}


