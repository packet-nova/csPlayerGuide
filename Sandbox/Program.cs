var weaponOne = CraftWeapon(Weapon.Sword, ItemRarity.Epic);
Console.WriteLine("What would you like to do? ");

if (Console.ReadLine() == "craft sword".ToLower())
{
    LogCraftedWeapon(weaponOne.weapon, weaponOne.rarity);
}

static void LogCraftedWeapon(string weapon, string rarity)
{
    Console.Write("You crafted a(n) ");
    GetWeaponLogText(weapon, rarity);
    Console.WriteLine("!");
}
static void GetWeaponLogText(string weapon, string rarity)
{
    ConsoleColor origialColor = Console.ForegroundColor;

    Console.ForegroundColor = rarity switch
    {
        "common" => ConsoleColor.White,
        "uncommon" => ConsoleColor.Green,
        "rare" => ConsoleColor.Blue,
        "epic" => ConsoleColor.Magenta,
        _ => ConsoleColor.Gray
    };
       
    Console.Write($"{rarity} {weapon.ToLower()}");
    Console.ForegroundColor = origialColor;
}

static (string weapon, string rarity) CraftWeapon(Weapon weapon, ItemRarity rarity)
{
    string weaponType = weapon switch
    {
        Weapon.Dagger => "Dagger",
        Weapon.Mace => "Mace",
        Weapon.Sword => "Sword",
        Weapon.Axe => "Axe",
        _ => "unspecified"
    };

    string itemRarity = rarity switch
    {
        ItemRarity.Common => "common",
        ItemRarity.Uncommon => "uncommon",
        ItemRarity.Rare => "rare",
        ItemRarity.Epic => "epic",
        _ => "unspecifed"
    };
    return (weaponType, itemRarity);
}

enum Weapon { Axe, Sword, Mace, Dagger }
enum ArmorType { Leather, Chain, Plate }
enum ItemRarity { Common, Uncommon, Rare, Epic }