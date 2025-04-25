using Microsoft.Extensions.Logging;
using NeonLeague.Data;
using NeonLeague.Models;

namespace NeonLeague;

public class NeonLeagueService(ILogger<NeonLeagueService> logger, ITeamsBuilder teamsBuilder)
{
    public Task Run()
    {
        DisplayIntroText();
        var (userTeam, exit) = CreateTeamOrExit();
        if (exit)
        {
            Console.WriteLine("Exiting the application.");
            return Task.CompletedTask;
        }
        Console.Clear();
        try
        {
            var sourceTeams = teamsBuilder.GenerateTeams();

            do
            {
                DisplayUserTeamDetails(userTeam);

                var selectedPlayer = DisplayClubsAndSelectPlayer(sourceTeams);
                if (selectedPlayer == null)
                {
                    Console.WriteLine("Invalid player selection. Please try again.");
                    continue;
                }

                var (success, errorMessage) = userTeam.AddPlayer(selectedPlayer);
                Console.Clear();
                Console.WriteLine(success
                    ? $"Player {selectedPlayer.Name} added to your team."
                    : $"Error: {errorMessage}");

                if (userTeam.Players.Count != UserTeam.MaxPlayers) 
                    continue;
                Console.Clear();
                Console.WriteLine($"Congratulations! You have selected {userTeam.Players.Count} players.");
                break;
            } while (true);

            Console.ReadKey();
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while running the Neon League service.");
            Console.WriteLine($"An error occurred: {e.Message}");
        }

        return Task.CompletedTask;
    }

    private Player? DisplayClubsAndSelectPlayer(List<SourceTeam> sourceTeams)
    {
        foreach (var sourceTeam in sourceTeams) Console.WriteLine($"{sourceTeam.Id}: {sourceTeam.Name}");
        Console.WriteLine();
        Console.WriteLine("### Select a club by id ###");
        var teamId = Console.ReadLine();
        if (string.IsNullOrEmpty(teamId) || !int.TryParse(teamId, out var id))
        {
            Console.WriteLine("Invalid input. Please enter a valid club ID.");
            return null;
        }

        Console.WriteLine();

        var players = teamsBuilder.GetPlayers(id);
        foreach (var player in players) Console.WriteLine($"{player.Name} - Price: {player.Price}");
        Console.WriteLine("Type the player's first name to add to your team");
        Console.WriteLine();

        var playerName = Console.ReadLine();
        if (!string.IsNullOrEmpty(playerName))
            return players.FirstOrDefault(p => p.Name.Contains(playerName, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("Invalid input. Please enter a valid player name.");
        return null;
    }

    private static void DisplayUserTeamDetails(UserTeam userTeam)
    {
        Console.WriteLine(
            $"## Team {userTeam.Name} has {userTeam.Players.Count} players and a budget of £{userTeam.Budget} Million ##");
        var playersNeeded = UserTeam.MaxPlayers - userTeam.Players.Count;
        if (playersNeeded > 0) Console.WriteLine($"You need to add {playersNeeded} players.");
    }

    private (UserTeam team, bool exit) CreateTeamOrExit()
    {
        Console.WriteLine();
        Console.WriteLine("1. Create a team");
        Console.WriteLine("2. Exit");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine("Please Enter a name for your team");
                var name = Console.ReadLine() ?? "Default";
                return (new UserTeam(name), false);
            case "2":
                break;
        }

        return (null, true)!;
    }

    private void DisplayIntroText()
    {
        Console.WriteLine("### Welcome to the Neon League ###");
        Console.WriteLine();
        Console.WriteLine(
            "Neon Premier League is a rule-based fantasy football league where a team of 15 players are\r\nselected, and points are awarded in each game based on the performance of each player.\r\nEach player belongs to a club and has a price fixed.");
        Console.WriteLine("You have a budget of 100 Million to select your players.");
    }
}