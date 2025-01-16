public class Team : Entity<int> {
    public TeamNames Name { get; set; }

    public Team() { }

    public Team(TeamNames name)
    {
        Name = name;
    }

    public override string ToString() {
        return $"{this.Name}";
    }

    public override bool Equals(object obj) {
        if (obj == null || GetType() != obj.GetType()) {
            return false;
        }

        Team team = (Team)obj;
        return this.Id.Equals(team.Id) && this.Name.Equals(team.Name);
    }

    public override int GetHashCode() {
        return HashCode.Combine(this.Id, this.Name);
    }
}