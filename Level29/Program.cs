Sword sword1 = new(Material.Iron, Gemstone.None, 100, 30);
Sword sword2 = sword1 with { material = Material.Steel, gemstone = Gemstone.Emerald };
Sword sword3 = sword1 with { material = Material.Binarium, gemstone = Gemstone.Bitstone };

Console.WriteLine(sword1);
Console.WriteLine(sword2);
Console.WriteLine(sword3);

public record Sword(Material material, Gemstone gemstone, int length, int crossguardWidth);

public enum Material { Wood, Bronze, Iron, Steel, Binarium };
public enum Gemstone { None, Emerald, Amber, Sapphire, Diamond, Bitstone };