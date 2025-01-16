public class PlayerRepo : InFileRepo<int, PlayerDTO>
{
    public PlayerRepo(string filePath) : base(filePath, LineToPlayerDto, PlayerDtoToLine)
    {
        
    }

    public static PlayerDTO LineToPlayerDto(string line)
    {
        var fields = line.Split(',');
        return new PlayerDTO
        {
            Id = int.Parse(fields[0]),
            IdStudent = int.Parse(fields[1]),
            IdTeam = int.Parse(fields[2])
        };
    }

    public static string PlayerDtoToLine(PlayerDTO playerDTO)
    {
        return playerDTO.ToString();
    }
}