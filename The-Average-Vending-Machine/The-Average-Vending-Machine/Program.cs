using The_Average_Vending_Machine;

bool shouldContinue = true;

while (shouldContinue)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("======================================");
    Console.WriteLine("Welcome to The Average Vending Machine");
    Console.WriteLine("======================================");
    Console.ResetColor();

    
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Please enter your name: ");
    Console.ResetColor();
    string? userName = Console.ReadLine()?.Trim();

    while (string.IsNullOrWhiteSpace(userName))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Name cannot be empty. Please try again.");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Please enter your name: ");
        Console.ResetColor();
        userName = Console.ReadLine()?.Trim();
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Hello, {userName}!");
    Console.ResetColor();

   
    decimal walletAmount = 0;
    bool validAmount = false;

    while (!validAmount)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("How much money do you have? (number only)");
        Console.ResetColor();
        
        string? input = Console.ReadLine()?.Trim();

        if (decimal.TryParse(input, out walletAmount) && walletAmount >= 0)
        {
            validAmount = true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid amount (non-negative number).");
            Console.ResetColor();
        }
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"You have ${walletAmount:F2} in your wallet.");
    Console.ResetColor();

    var vendingMachine = new VendingMachine();
    vendingMachine.SetUser(userName, walletAmount);
    vendingMachine.Run();

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Would you like to use The Average Vending Machine again?");
    Console.WriteLine("Yes or No?");
    Console.ResetColor();
    
    string? response = Console.ReadLine()?.Trim().ToLower();
    shouldContinue = response == "Yes";
}

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Thank you for using The Average Vending Machine!");
Console.WriteLine("Goodbye!");
Console.ResetColor();