using System.Globalization;

public class MatchRepo : InFileRepo<int, MatchDTO>
{
    public MatchRepo(string filePath) : base(filePath, LineToMatchDto, MatchDtoToLine)
    {
        
    }
    
    public static MatchDTO LineToMatchDto(string line)
    {
        var fields = line.Split(',');
        return new MatchDTO
        {
            Id = int.Parse(fields[0]),
            IdFirstTeam = int.Parse(fields[1]),
            IdSecondTeam = int.Parse(fields[2]),
            MatchDate = DateTime.ParseExact(fields[3], Match.Date_Format, CultureInfo.InvariantCulture)
        };
    }

    public static string MatchDtoToLine(MatchDTO matchDTO)
    {
        return matchDTO.ToString();
    }
}