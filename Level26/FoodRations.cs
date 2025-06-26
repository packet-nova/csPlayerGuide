public class FoodRations : InventoryItem
{
    public FoodRations() : base(1, 0.5) { }
    public override string ToString()
    {
        return "Food Rations";
    }
}
