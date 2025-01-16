
public class TeamValidator : IValidator<Team>
{
    public bool ValidateName(TeamNames name)
    {
        if (string.IsNullOrEmpty(name.ToString()))
            throw new ValidationException("Team name cannot be empty");
        return true;
    }

    public bool Validate(Team team)
    {
        var error = new List<string>();

        try
        {
            ValidateName(team.Name);
        }
        catch (ValidationException e)
        {
            error.Add(e.Message);
        }

        if (error.Count != 0)
        {
            error.Insert(0, "Team is invalid!");
            throw new ValidationException(string.Join("\n", error));

        }
        return true;
    }
}