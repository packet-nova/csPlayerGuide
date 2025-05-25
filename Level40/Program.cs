Console.WriteLine((Arrowhead)(0));
Console.WriteLine((Arrowhead)(1));
Console.WriteLine((Arrowhead)(2));

public class Arrow
{
    Arrowhead Arrowhead = Arrowhead.Flint;
}


enum Arrowhead { Flint, Bone, Poison }