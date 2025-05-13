public record MapData
{
    public Map Map { get; init; }
    public Location EntranceSpawn{ get; init; }
    public Location PlayerSpawn {  get; init; }
    public Location FountainSpawn { get; init; }
    public Location MaelstromSpawn { get; init; }
}