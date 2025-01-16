namespace service;

public class PlayerService
{
    private readonly IRepository<int, PlayerDTO> _playerRepository;
    private static readonly IValidator<Student> _playerValidator = new PlayerValidator();
    private readonly GetStudent _getStudent;
    private readonly GetTeam _getTeam;

    public PlayerService()
    {
    }

    public PlayerService(IRepository<int, PlayerDTO> playerRepository, GetStudent getStudent, GetTeam getTeam){
        _playerRepository = playerRepository;
        _getStudent = getStudent;
        _getTeam = getTeam;    
    }

    private PlayerDTO PlayerToDto(Player p)
    {
        return new PlayerDTO
        {
            Id = p.Id,
            IdStudent = p.Id,
            IdTeam = p.Team.Id
        };
    }

    private Player DtoToPlayer(PlayerDTO p)
    {
        var student = _getStudent(p.IdStudent);
        var team = _getTeam(p.IdTeam);
        if (student != null && team != null)
            return new Player
            {
                Id = student.Id,
                Name = student.Name,
                School = student.School,
                Team = team
            };
        throw new ServiceException("Incorrect data");
    }


    public Player? Add(Player player)
    {
        _playerValidator.Validate(player);
        var playerDto = PlayerToDto(player);
        var result = _playerRepository.Add(playerDto);
        return result != default ? player : default;
    }

    public Player? Update(Player player)
    {
        _playerValidator.Validate(player);
        var playerDto = PlayerToDto(player);
        var result = _playerRepository.Update(playerDto);
        return result != default ? player : default;
    }

    public Player? Delete(int id)
    {
        ArgumentNullException.ThrowIfNull(id);
        var result = _playerRepository.Delete(id);  
        return result != default ? Get(result.Id) : default;
    }

    public Player? Get(int id)
    {
        return GetAll().FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Player> GetAll()
    {
        return _playerRepository.GetAll().Select<PlayerDTO, Player>(DtoToPlayer);
    }

    public IEnumerable<Player>? GetAllPlayerOfATeam(Team? team)
    {
        return team != default ? GetAll().Where(p => p.Team == team) : default;
    }
}