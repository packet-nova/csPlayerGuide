Weapon weapon = new("Axe", 5, 10, Rarity.Common, 5, WeaponType.Axe);
Character character = new("Jim", 1, 100);
character.Inventory.Add(weapon);

character.DisplayInventory();



public enum Rarity { Common, Uncommon, Rare, Epic }
public enum WeaponType { Axe, Sword }