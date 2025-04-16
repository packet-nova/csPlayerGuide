ChestState state = ChestState.Locked;

while (true)
{
    Console.Write($"The chest in your hand is {state}. What do you want to do? ");
    string action = Console.ReadLine().ToLower();
    if (state == ChestState.Locked && action == "unlock") state = ChestState.Unlocked;
    else if (state == ChestState.Unlocked && action == "open") state = ChestState.Opened;
    else if (state == ChestState.Opened && action == "close") state = ChestState.Closed;
    else if (state == ChestState.Closed && action == "lock") state = ChestState.Locked;
    else Console.WriteLine($"You can't do that with the chest {state}.");
}


enum ChestState
{
    Locked,
    Opened,
    Closed,
    Unlocked
}