Console.Title = "Hunting the Manticore";
Console.ForegroundColor = ConsoleColor.Cyan;

const int manticoreMaxHealth = 10;
const int cityMaxHealth = 15;

int manticoreCurrentHealth;
int cityCurrentHealth;
int gameRound;
int manticoreDistance;

bool playingGame = true;

while (playingGame) // Start game
{
    StartGame();

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

    Console.WriteLine($"Press any key to start a new game...");
    Console.ReadKey();

    playingGame = true;

    Console.Clear();
}

void StartGame()
{
    cityCurrentHealth = 15;
    manticoreCurrentHealth = 10;
    gameRound = 1;

    SplashLogo();
    GameStartMusic();
    Console.Clear();

    manticoreDistance = SetManticoreDistance();

    Console.WriteLine($"Press a key to begin...");
    Console.ReadKey();

    Console.Clear();
    Console.WriteLine("Player 2, it is your turn.");
    Console.Clear();

    while (checkIfAlive(manticoreCurrentHealth) && checkIfAlive(cityCurrentHealth))
    {
        RoundStart();
    }
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

int SetManticoreDistance()
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine($"Player 1, it is your turn.");
    int distance = SetNumberInRange("How far do you want to deploy the Manticore from the city? ", 0, 100);
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine($"The Manticore is deployed a distance of {distance}.");
    return distance;
}

void RoundStart() // Primary game loop
{
    string cannonType = GetCannonType();

    Console.ForegroundColor = ConsoleColor.Cyan;
    var previousColor = Console.ForegroundColor;

    Console.WriteLine("-------------------------------------------------------------------");
    Console.WriteLine("STATUS");
    Console.WriteLine($"Round: {gameRound}");
    Console.WriteLine($"City Health: {cityCurrentHealth}/{cityMaxHealth}\t\t\tManticore Health: {manticoreCurrentHealth}/{manticoreMaxHealth}");
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
    Console.WriteLine("-------------------------------------------------------------------");
    AttackManticore(cannonType);
    
    cityCurrentHealth -= 1;
    gameRound += 1;
}

string GetCannonType() // Will update to a switch later when I know how to handle bools
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

void AttackManticore(string cannonType) // Will update to a switch later when I know how to handle ints
{
    Console.ResetColor();
    int range = SetNumberInRange("Enter cannon range (0-100): ", 0, 100);

    if (range > manticoreDistance)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("The cannon OVERSHOT the target!");
    }

    else if (range < manticoreDistance)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("The cannon is SHORT of the target!");
    }

    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Direct hit!");
        DamageManticore(cannonType);
    }
    return;
}

void DamageManticore(string cannonType) // Only occurs if AttackManticore() results in a hit.
{
    int cannonDamage = 0;
    int baseCannonDamage = 1;

    switch (cannonType)
    {
        case "Plasma Blast":
            cannonDamage = baseCannonDamage + 9;
            LogDamage(cannonType, cannonDamage);
            break;
        case "Fire":
            cannonDamage = baseCannonDamage + 2;
            LogDamage(cannonType, cannonDamage);
            break;
        case "Electric":
            cannonDamage = baseCannonDamage + 2;
            LogDamage(cannonType, cannonDamage);
            break;
        case "Normal":
            cannonDamage = baseCannonDamage;
            LogDamage(cannonType, cannonDamage);
            break;
    }

    manticoreCurrentHealth -= cannonDamage;
}

void LogDamage(string cannonType, int cannonDamage)
{
    string damageLog = ($"{cannonType} cannon hits for {cannonDamage} damage.");

    switch (cannonType)
    {
        case "Plasma Blast":
            Console.Beep(800, 50);
            Console.Beep(1200, 50);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(damageLog.ToUpper());
            break;
        case "Fire":
            Console.Beep(800, 50);
            Console.Beep(1200, 50);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(damageLog);
            break;
        case "Electric":
            Console.Beep(800, 50);
            Console.Beep(1200, 50);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(damageLog);
            break;
        default:
            Console.Beep(600, 50);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(damageLog);
            break;
    }
    Console.ResetColor();
}
int SetNumberInRange(string message, int min, int max)
{
    while (true)
    {
        Console.Write(message);
        int number = Convert.ToInt32(Console.ReadLine());

        if (number < min || number > max)
        {
            Console.WriteLine($"Invalid entry. Must be {min}-{max}: ");
            continue;
        }
        else
        {
            return number;
        }
    }
}

static void CityLose()
{
    Console.Beep(1200, 100);
    Console.Beep(1000, 100);
    Console.Beep(800, 200);
    Console.Beep(600, 400);
}

static void CityWin()
{
    Console.Beep(600, 100);
    Console.Beep(800, 100);
    Console.Beep(1000, 200);
    Console.Beep(1200, 400);
}

static void GameStartMusic() // For the memes...
{
    Console.Beep(196, 1200);
    Console.Beep(196, 300);
    Console.Beep(220, 400);
    Console.Beep(196, 400);
    Console.Beep(174, 300);
    Console.Beep(155, 1000);
    Console.Beep(146, 1000);
    Console.Beep(196, 1000);
    Console.Beep(196, 300);
    Console.Beep(220, 400);
    Console.Beep(196, 400);
    Console.Beep(174, 300);
    Console.Beep(155, 400);
    Console.Beep(174, 300);
    Console.Beep(155, 400);
    Console.Beep(146, 1000);
}

static void SplashLogo()
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(@"
                 _   _ _   _ _   _ _____ _____ _   _ _____                
                | | | | | | | \ | |_   _|_   _| \ | |  __ \               
                | |_| | | | |  \| | | |   | | |  \| | |  \/               
                |  _  | | | | . ` | | |   | | | . ` | | __                
                | | | | |_| | |\  | | |  _| |_| |\  | |_\ \               
                \_| |_/\___/\_| \_/ \_/  \___/\_| \_/\____/               
                         _____ _   _  _____                                       
                        |_   _| | | ||  ___|                                      
                          | | | |_| || |__                                        
                          | | |  _  ||  __|                                       
                          | | | | | || |___                                       
                          \_/ \_| |_/\____/                                       
                                ___  ___  ___   _   _ _____ _____ _____ ___________ _____ 
                                |  \/  | / _ \ | \ | |_   _|_   _/  __ \  _  | ___ \  ___|
                                | .  . |/ /_\ \|  \| | | |   | | | /  \/ | | | |_/ / |__  
                                | |\/| ||  _  || . ` | | |   | | | |   | | | |    /|  __| 
                                | |  | || | | || |\  | | |  _| |_| \__/\ \_/ / |\ \| |___ 
                                \_|  |_/\_| |_/\_| \_/ \_/  \___/ \____/\___/\_| \_\____/

Please wait...");
}

