Arrow arrow = new Arrow("steel", "plastic", 0.10f);

var arrowheadChoice = GetUserStringInput("What type of arrowhead do you want? ");
var shaftChoice = GetUserStringInput("What length of shaft do you want (.05 gold per cm)? ");
var fletchChoice = GetUserStringInput("What type of fletching do you want? ");


void CraftArrow(string arrowheadChoice, string fletchChoice, float shaftChoice)
{
    GetShaftCost(shaftChoice);
    Console.WriteLine($"You successfully crafted a {arrowheadChoice} and{fletchChoice} {shaftChoice}cm long! This costs {total} gold.");
}

float GetTotalArrowCost(int fletchCost, int arrowheadCost, float shaftCost)
{
    float totalArrowCost = fletchCost + arrowheadCost + shaftCost;
    return totalArrowCost;
}

float GetShaftCost(float shaftLength)
{
    float shaftCost = shaftLength * .05f;
    return shaftCost;
}

static string GetUserStringInput(string prompt)
{
    Console.Write(prompt);
    var input = Console.ReadLine().ToLower().Trim();
    return input;
}

static (string name, int cost) GetFletchInfo(Fletch name, Fletch cost)
{
    string fletchType = name switch
    {
        Fletch.GooseFeather => "goose feather",
        Fletch.TurkeyFeather => "turkey feather",
        Fletch.Plastic => "plastic",
        _ => "no fletch"
    };

    int fletchCost = cost switch
    {
        Fletch.GooseFeather => 3,
        Fletch.TurkeyFeather => 5,
        Fletch.Plastic => 10,
        _ => 0
    };

    return (fletchType, fletchCost);
}

// creates tuple to get string value for the name and int cost
static (string name, int cost) GetArrowheadInfo(Arrowhead name, Arrowhead cost)
{
    string arrowheadType = name switch
    {
        Arrowhead.Wood => "wood",        
        Arrowhead.Obsidian => "obsidian",
        Arrowhead.Steel => "steel",
        _ => "no arrowhead"
    };

    int arrowheadCost = cost switch
    {
        Arrowhead.Wood => 3,
        Arrowhead.Obsidian => 5,
        Arrowhead.Steel => 10,
        _ => 0
    };

    return (arrowheadType, arrowheadCost);
}

class Arrow
{
    public string _arrowhead;
    public string _fletch;
    public float _shaftLength;

    public Arrow(string arrowhead, string fletch, float shaftLength)
    {
        _arrowhead = arrowhead;
        _fletch = fletch;
        _shaftLength = shaftLength;
    }

}

enum Arrowhead { Wood, Steel, Obsidian }
enum Fletch { Plastic, TurkeyFeather, GooseFeather }