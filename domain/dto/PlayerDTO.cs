public class PlayerDTO : Entity<int>
{
    public int IdStudent { get; set; }
    public int IdTeam { get; set; }
    
    public PlayerDTO(){ }

    public override string ToString()
    {
        return $"{Id},{IdStudent},{IdTeam}";
    }
}