Sword sword = new();
Bow bow = new();
Axe axe = new();

ColoredItem<Sword> coloredSword = new ColoredItem<Sword>(sword);
ColoredItem<Bow> coloredBow = new ColoredItem<Bow>(bow);
ColoredItem<Axe> coloredAxe = new ColoredItem<Axe>(axe);

coloredSword.Display(ConsoleColor.Blue);
coloredBow.Display(ConsoleColor.Red);
coloredAxe.Display(ConsoleColor.Green);

public class ColoredItem<TItem>
{
    public TItem Item;
    public ColoredItem(TItem item)
    {
        Item = item;
    }

    public void Display(ConsoleColor consoleColor)
    {
        Console.ForegroundColor = consoleColor;
        Console.WriteLine(Item);
        Console.ResetColor();
    }
}

public class Sword { }
public class Bow { }
public class Axe { }