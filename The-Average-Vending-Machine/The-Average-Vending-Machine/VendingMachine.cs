namespace The_Average_Vending_Machine;

public class VendingMachine
{
    public List<string> Database { get; } = new List<string>();
    public List<Object> Commands { get; } = new List<Object>
    {
        "1. Shop goodies",
        "2. Look inside wallet",
        "3. Leave The Average Vending Machine"
    };

    public void Run()
    {
        string command;

        do
        {
            command = GetCommand();

            if (command == "Shop goodies")
            {
                Console.WriteLine("The Average Vending Machine inventory");
                if (item.inventory > 0)
                {
                    //Loop through the inventory and write amount and price
                    Console.Write("Please enter the placement of the candy you want:");
                    var itemToPurchase = Console.ReadLine();
                    
                    // All this be a function that we call and enter itemToPurchase into?
                    //Check if the user has enough money and then pay, else say...
                    // "You don't have enough money!
                    // $"You have {walletAmout} but {itemToPurchase.name} costs {itemToPurchase.money}"
                }

            }
            else if (command == "Look inside wallet")
            {
                Console.WriteLine("Asking The Average Bank...");
                if (walletAmount = 0)
                {
                    Console.WriteLine("You are broke!");
                }
                Console.WriteLine($"You have {walletAmount} in your wallet");
            }

        } while (command != "Leave The Average Vending Machine");
    }
    
    
    public string GetCommand()
    {
        while (true)
        {
            Console.Write("Please input a command, or \"help\": ");

            var input = Console.ReadLine()!;

            if (Commands.Contains(input))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OK");
                Console.WriteLine();
                Console.ResetColor();

                return input;
            }

            Console.WriteLine("Sorry, that is not a command...");
            Console.WriteLine();
        }
    }
    
    public void AddComapny( string companyName)
    {
        if (string.IsNullOrEmpty(companyName))
        {
            Console.WriteLine("No company name entered");
        }
        else
        {
            Database.Add(companyName);
            Console.WriteLine("Company added to database!");
        }
    }

    public void ListCompanies()
    {
        int amountOfCompanies = 0;
        foreach (var data in Database)
        {
            Console.WriteLine(data);
            amountOfCompanies++;
        }
        Console.WriteLine("--");
        Console.WriteLine($"Companies in database: {amountOfCompanies}");
    }
    
    public void GetHelp()
    {
        foreach (var call in Commands)
        {
            if (call == "help")
            {
                continue;
            }
            Console.WriteLine(call);
        }
    }
}


