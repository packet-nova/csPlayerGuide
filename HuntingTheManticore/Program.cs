using System;

Console.Title = "Hunting the Manticore";
Console.ForegroundColor = ConsoleColor.Cyan;

int manticoreCurrentHealth = 10;
int manticoreMaxHealth = 10;
int cityCurrentHealth = 15;
int cityMaxHealth = 15;
int gameRound = 1;
int manticoreDistance = SetManticoreDistance();

Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Player 2, it is your turn.");

// Game start
while (checkIfAlive(manticoreCurrentHealth) && checkIfAlive(cityCurrentHealth))
{
    RoundStart();
}

// Game ending conditions
if (!checkIfAlive(manticoreCurrentHealth))
{
    CityWin();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("The Manticore has been destroyed. Consolas is saved!");
    Console.ResetColor();
}
else if (!checkIfAlive(cityCurrentHealth))
{
    CityLose();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("The city has been destroyed. Game over.");
    Console.ResetColor();
}

bool checkIfAlive(int health)
{
    if (health > 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

static int SetManticoreDistance()
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Player 1, it is your turn.");
        Console.Write("Choose the distance from the city to deploy the Manticore (0-100): ");
        int distance = Convert.ToInt32(Console.ReadLine());

        if (distance >= 0 && distance <= 100)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"The Manticore is deployed a distance of {distance}.");
            Console.WriteLine($"Press a key to begin...");
            Console.ReadKey();
            return distance;
        }
        else
        {
            Console.WriteLine("Invalid entry. Distance must be 0-100: ");
        }
    }
}

void RoundStart()
{
    string cannonType = GetCannonType();

    Console.ForegroundColor = ConsoleColor.Cyan;
    var previousColor = Console.ForegroundColor;
    Console.WriteLine("-------------------------------------------------------------------");
    Console.WriteLine("STATUS");
    Console.WriteLine($"Round: {gameRound}");
    //Console.WriteLine($"Cannon Type: {cannonType}");
    Console.Write($"Cannon Type: ");
    switch (cannonType)
    {
        case "Plasma Blast":
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(cannonType.ToUpper());
            break;
        case "Fire":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(cannonType);
            break;
        case "Electric":
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(cannonType);
            break;
        default:
            Console.ForegroundColor = previousColor;
            Console.WriteLine(cannonType);
            break;
    }
    Console.ForegroundColor = previousColor;
    Console.WriteLine($"City Health: {cityCurrentHealth}/{cityMaxHealth}\t\t\tManticore Health: {manticoreCurrentHealth}/{manticoreMaxHealth}");
    AttackManticore(cannonType);
    cityCurrentHealth -= 1;
    gameRound += 1;
}

string GetCannonType()
{
    string cannonType = "";

    if ((gameRound % 3 == 0) && (gameRound % 5 == 0))
    {
        cannonType = "Plasma Blast";
    }
    else if (gameRound % 3 == 0)
    {
        cannonType = "Fire";
    }
    else if (gameRound % 5 == 0)
    {
        cannonType = "Electric";
    }
    else
    {
        cannonType = "Normal";
    }
    return cannonType;
}

void AttackManticore(string cannonType)
{
    while (true)
    {
        Console.Write("Enter cannon range (0-100): ");
        int range = Convert.ToInt32(Console.ReadLine());

        if (range < 0 || range > 100)
        {
            Console.WriteLine("Invalid entry. Distance must be 0-100: ");
            continue;
        }

        else if (range > manticoreDistance)
        {
            Console.WriteLine("The cannon OVERSHOT the target!");
        }

        else if (range < manticoreDistance)
        {
            Console.WriteLine("The cannon is SHORT of the target!");
        }

        else
        {
            Console.WriteLine("Direct hit!");
            DamageManticore(cannonType);
        }
        return;
    }
}

void DamageManticore(string cannonType)
{
    int cannonDamage = 0;
    int baseCannonDamage = 1;

    if (cannonType == "Plasma Blast")
    {
        cannonDamage = baseCannonDamage + 9;
        LogDamage(cannonType, cannonDamage);
    }
    else if (cannonType == "Fire")
    {
        cannonDamage = baseCannonDamage + 2;
        LogDamage(cannonType, cannonDamage);
    }
    else if (cannonType == "Electric")
    {
        cannonDamage = baseCannonDamage + 2;
        LogDamage(cannonType, cannonDamage);
    }
    else
    {
        cannonDamage = baseCannonDamage;
        LogDamage(cannonType, cannonDamage);
    }

    manticoreCurrentHealth -= cannonDamage;
}

void LogDamage(string cannonType, int cannonDamage)
{
    string damageLog = ($"{cannonType} cannon hits for {cannonDamage} damage.");
    if (cannonType == "Plasma Blast")
    {
        Console.Beep(800, 50);
        Console.Beep(1200, 50);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(damageLog.ToUpper());
    }
    else if (cannonType == "Fire")
    {
        Console.Beep(800, 50);
        Console.Beep(1200, 50);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(damageLog);
    }
    else if (cannonType == "Electric")
    {
        Console.Beep(800, 50);
        Console.Beep(1200, 50);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(damageLog);
    }
    else
    {
        Console.Beep(600, 50);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(damageLog);
    }
}

void CityLose()
{
    Console.Beep(1200, 100);
    Console.Beep(1000, 100);
    Console.Beep(800, 200);
    Console.Beep(600, 400);
}

void CityWin()
{
    Console.Beep(600, 100);
    Console.Beep(800, 100);
    Console.Beep(1000, 200);
    Console.Beep(1200, 400);
}

//void ColoredText(string word, ConsoleColor color)
//{
//    var previousColor = Console.ForegroundColor;
//    Console.ForegroundColor = color;
//    Console.Write(word);
//    Console.ForegroundColor = previousColor;
//}