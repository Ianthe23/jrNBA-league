namespace repo.file;

public class TeamRepo : InFileRepo<int, Team>
{
    public TeamRepo(string filePath) : base(filePath, LineToTeam, TeamToLine)
    {
        
    }

    public static Team LineToTeam(string line)
    {
        var fields = line.Split(',');
        return new Team
        {
            Id = int.Parse(fields[0]),
            Name = (TeamNames)Enum.Parse(typeof(TeamNames), fields[1])
        };
    }

    public static string TeamToLine(Team team)
    {
        return $"{team.Id},{team.Name}";
    }
}