using repo.file;
using service;

public class Program
{
    public static void Main(string[] args)
    {
        IRepository<int,Team> teamRepository = new TeamRepo("C:\\Users\\Ivona\\Facultate\\MAP\\jrNBA-league\\data\\Teams");
        IRepository<int,Student> studentRepository = new StudentRepo("C:\\Users\\Ivona\\Facultate\\MAP\\jrNBA-league\\data\\Students");
        IRepository<int,PlayerDTO> playerRepository = new PlayerRepo("C:\\Users\\Ivona\\Facultate\\MAP\\jrNBA-league\\data\\Players");
        IRepository<int,MatchDTO> matchRepository = new MatchRepo("C:\\Users\\Ivona\\Facultate\\MAP\\jrNBA-league\\data\\Matches");
        IRepository<int,ActivePlayer> activePlayerRepository = new ActivePlayerRepo("C:\\Users\\Ivona\\Facultate\\MAP\\jrNBA-league\\data\\ActivePlayers");

        var teamService = new TeamService(teamRepository);
        var studentService = new StudentService(studentRepository);
        var playerService = new PlayerService(playerRepository, studentService.Get, teamService.Get);
        var matchService = new MatchService(matchRepository, teamService.Get);
        var activePlayerService = new ActivePlayerService(activePlayerRepository);
        var service = new Service(teamService, studentService, playerService, matchService, activePlayerService);

        var console = new Console(service);

        console.Start();
    }
}