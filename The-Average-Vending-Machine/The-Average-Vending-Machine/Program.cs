using The_Average_Vending_Machine;

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Welcome to The Average Vending Machine");

Console.WriteLine("Please enter your name:");

string? currentUser = Console.ReadLine();

Console.WriteLine($"Hello {currentUser}");

Console.WriteLine("How much money do you have?");

string? currentWallet = Console.ReadLine();

var application = new VendingMachine();
application.Run();








//Någon gång då och då kommer inte produkten ut men man får inte pengarna tillbaka
//$"Oops.. looks like {itemName} got stuck, do you want to slap the average vending machine?"