var weaponOne = CraftWeapon(Weapon.Sword, ItemRarity.Uncommon);
Console.WriteLine($"{weaponOne.rarity} {weaponOne.weapon.ToLower()}");

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