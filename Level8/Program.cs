Console.Title = "Defense of Consolas";

Console.Write("Which row is being attacked (1-8)?: ");
var rowBeingAttacked = Convert.ToSingle(Console.ReadLine());

Console.Write("Which column is being attacked (1-8)?: ");
var columnBeingAttacked = Convert.ToSingle(Console.ReadLine());

Console.Beep(450, 250);
Console.Beep(750, 250);

Console.ForegroundColor = ConsoleColor.Red;

Console.WriteLine("Deploy to:");
Console.WriteLine($"{rowBeingAttacked - 1}, {columnBeingAttacked}");
Console.WriteLine($"{rowBeingAttacked + 1}, {columnBeingAttacked}");
Console.WriteLine($"{rowBeingAttacked}, {columnBeingAttacked - 1}");
Console.WriteLine($"{rowBeingAttacked}, {columnBeingAttacked + 1}");

Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine("Press any key to exit program...");
Console.ReadKey();
