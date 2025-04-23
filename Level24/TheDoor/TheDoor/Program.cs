Door door1 = new Door(DoorState.Locked);

while (true)
{
    Console.Write($"The door is {door1.DoorState.ToString().ToLower()}. What do you want to do? (lock, unlock, open, close, change passcode): ");
    string action = Console.ReadLine();
    if (door1.DoorState == DoorState.Locked && action.ToLower().Trim() == "unlock")
    {
        door1.UnlockDoor();
    }
    else if (door1.DoorState == DoorState.Closed && action.ToLower().Trim() == "open")
    {
        door1.OpenDoor();
    }
    else if (door1.DoorState == DoorState.Opened && action.ToLower().Trim() == "close")
    {
        door1.CloseDoor();
    }
    else if (door1.DoorState == DoorState.Closed && action.ToLower().Trim() == "lock")
    {
        door1.LockDoor();
    }
    else if (action.ToLower().Trim() == "change passcode")
    {
        door1.ChangePasscode();
    }
    else
    {
        Console.WriteLine($"That action is either invalid or not possible while the door is {door1.DoorState.ToString().ToLower()}.");
    }
}


public class Door
{
    private int _passcode;
    public DoorState DoorState { get; set; }

    public Door(DoorState doorState)
    {
        Console.Write("Please enter a passcode for the door: ");
        _passcode = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The passcode has been set.");
        DoorState = doorState;
    }

    public void UnlockDoor()
    {
        Console.Write("Please enter the passcode: ");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input == _passcode)
        {
            DoorState = DoorState.Closed;
        }
        else
        {
            Console.WriteLine("Passcode is incorrect. The door is locked.");
        }
    }

    public void OpenDoor()
    {
        DoorState = DoorState.Opened;
    }

    public void LockDoor()
    {
        Console.Write("Please enter the passcode: ");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input == _passcode)
        {
            DoorState = DoorState.Locked;
        }
        else
        {
            Console.WriteLine("Passcode is incorrect. The door is unlocked.");
        }
    }

    public void CloseDoor()
    {
        DoorState = DoorState.Closed;
    }

    public void ChangePasscode()
    {
        Console.Write("Please enter the current passcode: ");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input == _passcode)
        {
            Console.Write("Please enter a new passcode:");
            int newPasscode = Convert.ToInt32(Console.ReadLine());
            _passcode = newPasscode;
            Console.WriteLine("The passcode has been changed.");
        }
        else
        {
            Console.WriteLine("The passcode is not correct.");
        }
    }
}

public enum DoorState { Opened, Closed, Locked }