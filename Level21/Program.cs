// Level 20 Properties
// ================================

Console.Title = "Vin Fletcher's Arrows";

/*// If you want to create a set amount of arrows.
int desiredArrows = Convert.ToInt32(GetUserInput("How many arrows do you want to make? "));
for (int i = 0; i < desiredArrows; i++)
{
    CraftArrow(GetArrowheadChoice(), GetFletchChoice(), GetShaftLength());
}*/

DisplayStoreBanner();

CraftArrow(GetArrowheadChoice(), GetFletchChoice(), GetShaftLength());

Arrow eliteArrow01 = Arrow.CreateMarksmanArrow();

Arrow marksmanArrow01 = Arrow.CreateMarksmanArrow();

Arrow beginnerArrow01 = Arrow.CreateBeginnerArrow();

void CraftArrow(Arrowhead arrowhead, Fletch fletch, float shaft)
{
    Arrow arrow = new(arrowhead, fletch, shaft);
    ConsoleColor previousForeground = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"You created a(n) {GetArrowheadInfo(arrowhead).name.ToLower()}-tipped arrow with {GetFletchInfo(fletch).name.ToLower()} fletching for {GetTotalArrowCost(arrowhead, fletch, shaft)} gold.");
    Console.ForegroundColor = previousForeground;

    Console.WriteLine();

    Console.WriteLine($"The GetArrowhead() method returns: {arrow.GetArrowhead()}");
    Console.WriteLine($"The GetFletch() method returns: {arrow.GetFletch()}");
    Console.WriteLine($"The GetShaftLength() method returns: {arrow.GetShaftLength()}");
    Console.WriteLine();

    Console.WriteLine($"The property (arrowhead) from the class returns: {arrow.Arrowhead}");
    Console.WriteLine($"The property (fletch) from the class returns: {arrow.Fletch}");
    Console.WriteLine($"The property (length) from the class returns: {arrow.ShaftLength}");

}

float GetTotalArrowCost(Arrowhead arrowhead, Fletch fletch, float shaftLength)
{
    float shaftCost = GetShaftCost(shaftLength);
    int arrowheadCost = arrowhead switch
    {
        Arrowhead.Wood => GetArrowheadInfo(Arrowhead.Wood).cost,
        Arrowhead.Obsidian => GetArrowheadInfo(Arrowhead.Obsidian).cost,
        Arrowhead.Steel => GetArrowheadInfo(Arrowhead.Steel).cost,
        _ => 0,
    };

    int fletchCost = fletch switch
    {
        Fletch.GooseFeather => GetFletchInfo(Fletch.GooseFeather).cost,
        Fletch.TurkeyFeather => GetFletchInfo(Fletch.TurkeyFeather).cost,
        Fletch.Plastic => GetFletchInfo(Fletch.Plastic).cost,
        _ => 0
    };
    return shaftCost + arrowheadCost + fletchCost;
}

static Arrowhead GetArrowheadChoice()
{
    Console.WriteLine("Which arrowhead material would you like? ");
    DisplayArrowheadInfo();
    Console.Write("Choice (1-3): ");
    string arrowhead = Console.ReadLine();

    Arrowhead arrowheadChoice = arrowhead switch
    {
        "1" => Arrowhead.Wood,
        "2" => Arrowhead.Obsidian,
        "3" => Arrowhead.Steel,
        _ => Arrowhead.Wood
    };

    Console.WriteLine($"You chose {GetArrowheadInfo(arrowheadChoice).name}.");
    Console.WriteLine();

    return arrowheadChoice;
}

static Fletch GetFletchChoice()
{
    Console.WriteLine("Which fletch material would you like? ");
    DisplayFletchInfo();
    Console.Write("Choice (1-3): ");

    string fletch = Console.ReadLine().ToLower().Trim();

    Fletch fletchChoice = fletch switch
    {
        "1" => Fletch.GooseFeather,
        "2" => Fletch.TurkeyFeather,
        "3" => Fletch.Plastic,
        _ => Fletch.GooseFeather
    };

    Console.WriteLine($"You chose {GetFletchInfo(fletchChoice).name}.");
    Console.WriteLine();
    return fletchChoice;
}

static void DisplayArrowheadInfo()
{
    Console.WriteLine($"1. {GetArrowheadInfo(Arrowhead.Wood).name} - {GetArrowheadInfo(Arrowhead.Wood).cost}g");
    Console.WriteLine($"2. {GetArrowheadInfo(Arrowhead.Obsidian).name} - {GetArrowheadInfo(Arrowhead.Obsidian).cost}g");
    Console.WriteLine($"3. {GetArrowheadInfo(Arrowhead.Steel).name} - {GetArrowheadInfo(Arrowhead.Steel).cost}g");
}

static void DisplayFletchInfo()
{
    Console.WriteLine($"1. {GetFletchInfo(Fletch.GooseFeather).name} - {GetFletchInfo(Fletch.GooseFeather).cost}g");
    Console.WriteLine($"2. {GetFletchInfo(Fletch.TurkeyFeather).name} - {GetFletchInfo(Fletch.TurkeyFeather).cost}g");
    Console.WriteLine($"3. {GetFletchInfo(Fletch.Plastic).name} - {GetFletchInfo(Fletch.Plastic).cost}g");
}

static float GetShaftLength()
{
    float shaftLength = Convert.ToSingle(GetUserInput("How long should the arrow shaft be (in cm)? "));
    return shaftLength;
}

float GetShaftCost(float shaftLength)
{
    float shaftCost = shaftLength * .05f;
    return shaftCost;
}

static (string name, int cost) GetFletchInfo(Fletch fletch)
{
    string fletchType = fletch switch
    {
        Fletch.GooseFeather => "Goose Feather",
        Fletch.TurkeyFeather => "Turkey Feather",
        Fletch.Plastic => "Plastic",
        _ => "no fletch"
    };

    int fletchCost = fletch switch
    {
        Fletch.GooseFeather => 3,
        Fletch.TurkeyFeather => 5,
        Fletch.Plastic => 10,
        _ => 0
    };

    return (fletchType, fletchCost);
}

static (string name, int cost) GetArrowheadInfo(Arrowhead arrowhead)
{
    string arrowheadType = arrowhead switch
    {
        Arrowhead.Wood => "Wood",
        Arrowhead.Obsidian => "Obsidian",
        Arrowhead.Steel => "Steel",
        _ => "no arrowhead"
    };

    int arrowheadCost = arrowhead switch
    {
        Arrowhead.Wood => 3,
        Arrowhead.Obsidian => 5,
        Arrowhead.Steel => 10,
        _ => 0
    };

    return (arrowheadType, arrowheadCost);
}

static string GetUserInput(string prompt)
{
    Console.Write(prompt);
    var input = Console.ReadLine().ToLower().Trim();

    return input;
}

static void DisplayStoreBanner()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(@"
===========================================
           Vin Fletcher's Arrows
===========================================");
    Console.WriteLine();
    Console.ResetColor();
}

class Arrow
{
    private Arrowhead _arrowhead;
    private Fletch _fletch;
    private float _shaftLength;

    public Arrow(Arrowhead arrowhead, Fletch fletch, float shaftLength)
    {
        _arrowhead = arrowhead;
        _fletch = fletch;
        _shaftLength = shaftLength;
    }

    public Arrowhead Arrowhead => _arrowhead;
    public Fletch Fletch => _fletch;
    public float ShaftLength => _shaftLength;

    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Steel, Fletch.Plastic, 95);
    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Wood, Fletch.GooseFeather, 75);
    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, Fletch.GooseFeather, 65);

}

enum Arrowhead { Wood, Steel, Obsidian }
enum Fletch { Plastic, TurkeyFeather, GooseFeather }