Rectangle rectangle = new(2, 2, 4);
Console.WriteLine($"{rectangle.Height} h, {rectangle.Width} w, {rectangle.Area} a");

Dog dog = new("brown", 30);

Cat cat = new("Kitty", "calico", "green");

dog.Bark();
Console.ReadLine();
cat.Meow();

class Cat
{
    public string Name;
    public string Breed;
    public string EyeColor;

    public Cat(string name, string breed, string eyeColor)
    {
        Name = name;
        Breed = breed;
        EyeColor = eyeColor;
    }

    public void Meow()
    {
        Console.WriteLine($"The {Breed} cat named {Name} with {EyeColor} eyes meows.");
        Console.Beep(1200, 200);
    }

}

class Dog
{
    public string FurColor;
    public int Weight;

    public Dog(string furColor, int weight)
    {
        FurColor = furColor;
        Weight = weight;
    }

    public void Bark()
    {
        Console.WriteLine($"The {FurColor} dog that weighs {Weight} pounds barks.");
        Console.Beep(400, 100);
    }
   
}

class Rectangle
{
    public float Width;
    public float Height;
    public float Area;

    public Rectangle(float width, float height, float area)
    {
        Width = width;
        Height = height;
        Area = area;
    }
}