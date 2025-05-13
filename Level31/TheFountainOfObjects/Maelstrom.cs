public class Maelstrom : Monster
{
    public Location Location { get; private set; }

    public Maelstrom(Location location)
    {
        Name = "Maelstrom";
        Description = "A swirling vortex of energy.";
        SenseDescription = "You hear faint groaning and rhythmic pulses, broken by irregular crackles of unnatural energy.";
        Location = location;
        Level = 1;
        Health = 10;

    }
}