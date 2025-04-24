Color purple = new(128, 0, 128);
Color purpleProperty = Color.ColorPurple;

Console.WriteLine($"The (r, g, b) values of purple are ({Color.ColorPurple.Red}, {Color.ColorPurple.Green}, {Color.ColorPurple.Blue})");
Console.WriteLine($"The (r, g, b) values of purpleProperty are ({purpleProperty.Red}, {purpleProperty.Green}, {purpleProperty.Blue})");

class Color
{
    public int Red { get; }
    public int Green { get; }
    public int Blue { get; }

    public Color(int red, int green, int blue)
    {
        Red = red;
        Blue = blue;
        Green = green;
    }

    public static Color ColorWhite => new(255, 255, 255);
    public static Color ColorBlack => new(0, 0, 0);
    public static Color ColorRed => new(255, 0, 0);
    public static Color ColorOrange => new(255, 165, 0);
    public static Color ColorYellow => new(255, 255, 0);
    public static Color ColorGreen => new(0, 128, 0);
    public static Color ColorBlue => new(0, 0, 255);
    public static Color ColorPurple => new(128, 0, 128);
}