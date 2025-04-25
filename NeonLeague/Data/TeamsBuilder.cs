using NeonLeague.Models;

namespace NeonLeague.Data;

public class TeamsBuilder : ITeamsBuilder
{
    private readonly IDbContext _dbContext;

    public TeamsBuilder(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<SourceTeam> GenerateTeams()
    {
        return _dbContext.SourceTeams.ToList();
    }

    public List<Player> GetPlayers(int teamId)
    {
        var players = _dbContext.Players.ToList();
        return players.Where(player => player.ClubId == teamId).ToList();
    }
}

public interface ITeamsBuilder
{
    List<SourceTeam> GenerateTeams();
    List<Player> GetPlayers(int teamId);
}