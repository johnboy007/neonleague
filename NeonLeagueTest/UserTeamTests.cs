using NeonLeague;
using NeonLeague.Models;

namespace NeonLeagueTest;

public class UserTeamTests
{
    [Fact]
    public void UserTeam_WillNotAdd_WhenOverMaxPlayers()
    {
        // Arrange
        var userTeam = new UserTeam("Test Team");
        for (var i = 0; i < UserTeam.MaxPlayers; i++)
            userTeam.AddPlayer(new Player { Name = $"Test Player {i}", ClubId = i, Price = 1 });

        // Act
        var result = userTeam.AddPlayer(new Player { Name = "Test Player", ClubId = 1, Price = 1 });

        // Assert
        Assert.False(result.success);
        Assert.Equal("Cannot add player. Team limit reached.", result.errorMessage);
    }

    [Fact]
    public void UserTeam_WillNotAdd_WhenOverBudget()
    {
        // Arrange
        var userTeam = new UserTeam("Test Team");

        // Act
        var result = userTeam.AddPlayer(new Player { Name = "Test Player", ClubId = 1, Price = 101 });

        // Assert
        Assert.False(result.success);
        Assert.Equal("Cannot add player. Budget exceeded.", result.errorMessage);
    }

    [Fact]
    public void UserTeam_WillNotAdd_WhenLimitOfPlayersFromSameClubAdded()
    {
        // Arrange
        var userTeam = new UserTeam("Test Team");

        const int maxPlayersPerClub = 3;
        for (var i = 0; i < maxPlayersPerClub; i++) userTeam.AddPlayer(new Player { Name = $"Test Player {i}", ClubId = 1, Price = 1 });

        // Act
        var result = userTeam.AddPlayer(new Player { Name = "Test Player", ClubId = 1, Price = 1 });

        // Assert
        Assert.False(result.success);
        Assert.Equal("Cannot add player. You already have 3 players from this club.", result.errorMessage);
    }
}