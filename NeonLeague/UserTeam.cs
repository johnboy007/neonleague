using NeonLeague.Models;

namespace NeonLeague;

public class UserTeam
{
    public const int MaxPlayers = 15;
    public const int MaxBudget = 100;
    private const int MaxPlayersPerClub = 3;

    public UserTeam(string name)
    {
        Name = name;
        Budget = MaxBudget;
        Players = new List<Player>();
    }

    public string Name { get; set; }
    public List<Player> Players { get; set; }
    public int Budget { get; set; }

    public (bool success, string errorMessage) AddPlayer(Player player)
    {
        if (!PlayersNeeded()) return (false, "Cannot add player. Team limit reached.");

        if (!WeHaveBudget(player)) return (false, "Cannot add player. Budget exceeded.");

        if (PlayersFromSameClubLimitReached(player.ClubId))
            return (false, "Cannot add player. You already have 3 players from this club.");

        Players.Add(player);
        Budget -= player.Price;
        return (true, string.Empty);
    }

    private bool PlayersFromSameClubLimitReached(int clubId)
    {
        var count = Players.Count(player => player.ClubId == clubId);
        return count == MaxPlayersPerClub;
    }

    private bool WeHaveBudget(Player player)
    {
        return Budget >= player.Price;
    }

    private bool PlayersNeeded()
    {
        return Players.Count < MaxPlayers;
    }
}
