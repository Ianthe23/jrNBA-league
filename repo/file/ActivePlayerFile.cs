public class ActivePlayerRepo : InFileRepo<int, ActivePlayer>
{
    public ActivePlayerRepo(string filePath) : base(filePath, LineToActivePlayer, ActivePlayerToLine)
    {
        
    }

    public static ActivePlayer LineToActivePlayer(string line)
    {
        var fields = line.Split(',');
        return new ActivePlayer
        {
            Id = int.Parse(fields[0]),
            IdPlayer = int.Parse(fields[1]),
            IdMatch = int.Parse(fields[2]),
            NumberOfPointsEntered = int.Parse(fields[3]),
            Type = (Type)Enum.Parse(typeof(Type), fields[4])
        };
    }

    public static string ActivePlayerToLine(ActivePlayer activePlayer)
    {
        return
            $"{activePlayer.Id},{activePlayer.IdPlayer},{activePlayer.IdMatch},{activePlayer.NumberOfPointsEntered},{activePlayer.Type}";
    }
    
}