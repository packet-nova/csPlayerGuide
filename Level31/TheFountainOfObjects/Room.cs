public class Room
{
    public RoomType Type { get; private set; }
    public IInteractable? Interactable { get; private set; }

    public Room(RoomType type = RoomType.Empty)
    {
        Type = type;
    }
}




