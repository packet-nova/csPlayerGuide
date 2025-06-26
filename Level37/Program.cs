/*
 Objectives:
• Make a new project that includes the above code.
• Add a Ripened event to the CharberryTree class that is raised when the tree ripens.
• Make a Notifier class that knows about the tree (Hint: perhaps pass it in as a constructor
parameter) and subscribes to its Ripened event. Attach a handler that displays something like “A
charberry fruit has ripened!” to the console window.
• Make a Harvester class that knows about the tree (Hint: like the notifier, this could be passed as
a constructor parameter) and subscribes to its Ripened event. Attach a handler that sets the tree’s
Ripe property back to false.
• Update your main method to create a tree, notifier, and harvester, and get them to work together
to grow, notify, and harvest forever.
*/


CharberryTree tree = new();
Notifier notifier = new(tree);
Harvester harvester = new(tree);

while (true)
{
    tree.MaybeGrow();
}

public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }
    public event Action? Ripened;

    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}

public class Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnFruitRipened;
    }
    private void OnFruitRipened() => Console.WriteLine("A charberry fruit has ripened!");
}

public class Harvester
{
    private CharberryTree _tree;
    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        tree.Ripened += OnFruitRipened;
    }
    private void OnFruitRipened() => _tree.Ripe = false;
}