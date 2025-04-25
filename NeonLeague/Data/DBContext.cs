using NeonLeague.Models;

namespace NeonLeague.Data;

public interface IDbContext
{
    IQueryable<SourceTeam> SourceTeams { get; }

    IQueryable<Player> Players { get; }
}

public class DbContext : IDbContext
{
    public IQueryable<SourceTeam> SourceTeams =>
        new List<SourceTeam>
            {
                new()
                {
                    Name = "Manchester United",
                    Id = 1
                },
                new()
                {
                    Name = "Manchester City",
                    Id = 2
                },
                new()
                {
                    Name = "Liverpool",
                    Id = 3
                },
                new()
                {
                    Name = "Chelsea",
                    Id = 4
                },
                new()
                {
                    Name = "Arsenal",
                    Id = 5
                },
                new()
                {
                    Name = "Tottenham",
                    Id = 6
                },
                new()
                {
                    Name = "Newcastle",
                    Id = 7
                },
                new()
                {
                    Name = "Aston Villa",
                    Id = 8
                },
                new()
                {
                    Name = "Everton",
                    Id = 9
                },
                new()
                {
                    Name = "Leeds United",
                    Id = 10
                }
            }
            .AsQueryable();

    public IQueryable<Player> Players =>
        new List<Player>
            {
                new() { Name = "Bruno Fernandes", Price = 10, ClubId = 1 },
                new() { Name = "Marcus Rashford", Price = 9, ClubId = 1 },
                new() { Name = "Cristiano Ronaldo", Price = 12, ClubId = 1 },
                new() { Name = "Jadon Sancho", Price = 8, ClubId = 1 },
                new() { Name = "Harry Maguire", Price = 7, ClubId = 1 },
                new() { Name = "David De Gea", Price = 6, ClubId = 1 },
                new() { Name = "Paul Pogba", Price = 11, ClubId = 1 },
                new() { Name = "Brandon Williams", Price = 5, ClubId = 1 },
                new() { Name = "Luke Shaw", Price = 7, ClubId = 1 },
                new() { Name = "Victor Lindelof", Price = 6, ClubId = 1 },
                new() { Name = "Kevin De Bruyne", Price = 11, ClubId = 2 },
                new() { Name = "Erling Haaland", Price = 13, ClubId = 2 },
                new() { Name = "Phil Foden", Price = 8, ClubId = 2 },
                new() { Name = "Ruben Dias", Price = 7, ClubId = 2 },
                new() { Name = "Joao Cancelo", Price = 8, ClubId = 2 },
                new() { Name = "Rodri", Price = 6, ClubId = 2 },
                new() { Name = "Bernardo Silva", Price = 9, ClubId = 2 },
                new() { Name = "Ilkay Gundogan", Price = 7, ClubId = 2 },
                new() { Name = "Kyle Walker", Price = 6, ClubId = 2 },
                new() { Name = "Ederson", Price = 5, ClubId = 2 },
                new() { Name = "Mohamed Salah", Price = 12, ClubId = 3 },
                new() { Name = "Sadio Mane", Price = 10, ClubId = 3 },
                new() { Name = "Virgil van Dijk", Price = 9, ClubId = 3 },
                new() { Name = "Alisson Becker", Price = 8, ClubId = 3 },
                new() { Name = "Trent Alexander-Arnold", Price = 7, ClubId = 3 },
                new() { Name = "Andrew Robertson", Price = 7, ClubId = 3 },
                new() { Name = "Fabinho", Price = 6, ClubId = 3 },
                new() { Name = "Jordan Henderson", Price = 6, ClubId = 3 },
                new() { Name = "Thiago Alcantara", Price = 8, ClubId = 3 },
                new() { Name = "Diogo Jota", Price = 9, ClubId = 3 },
                new() { Name = "N'Golo Kante", Price = 10, ClubId = 4 },
                new() { Name = "Mason Mount", Price = 9, ClubId = 4 },
                new() { Name = "Kai Havertz", Price = 8, ClubId = 4 },
                new() { Name = "Reece James", Price = 7, ClubId = 4 },
                new() { Name = "Ben Chilwell", Price = 7, ClubId = 4 },
                new() { Name = "Thiago Silva", Price = 6, ClubId = 4 },
                new() { Name = "Edouard Mendy", Price = 5, ClubId = 4 },
                new() { Name = "Hakim Ziyech", Price = 4, ClubId = 4 },
                new() { Name = "Timo Werner", Price = 9, ClubId = 4 },
                new() { Name = "Christian Pulisic", Price = 8, ClubId = 4 },
                new() { Name = "Bukayo Saka", Price = 9, ClubId = 5 },
                new() { Name = "Martin Odegaard", Price = 8, ClubId = 5 },
                new() { Name = "Gabriel Jesus", Price = 2, ClubId = 5 },
                new() { Name = "Thomas Partey", Price = 9, ClubId = 5 },
                new() { Name = "Kieran Tierney", Price = 7, ClubId = 5 },
                new() { Name = "Aaron Ramsdale", Price = 6, ClubId = 5 },
                new() { Name = "Ben White", Price = 7, ClubId = 5 },
                new() { Name = "Gabriel Magalhaes", Price = 6, ClubId = 5 },
                new() { Name = "Emile Smith Rowe", Price = 8, ClubId = 5 },
                new() { Name = "Oleksandr Zinchenko", Price = 7, ClubId = 5 },
                new() { Name = "Harry Kane", Price = 12, ClubId = 6 },
                new() { Name = "Son Heung-min", Price = 4, ClubId = 6 },
                new() { Name = "Dejan Kulusevski", Price = 9, ClubId = 6 },
                new() { Name = "Pierre-Emile Hojbjerg", Price = 8, ClubId = 6 },
                new() { Name = "Cristian Romero", Price = 7, ClubId = 6 },
                new() { Name = "Hugo Lloris", Price = 6, ClubId = 6 },
                new() { Name = "Clement Lenglet", Price = 7, ClubId = 6 },
                new() { Name = "Ivan Perisic", Price = 8, ClubId = 6 },
                new() { Name = "Emerson Royal", Price = 7, ClubId = 6 },
                new() { Name = "Yves Bissouma", Price = 6, ClubId = 6 },
                new() { Name = "Bruno Guimaraes", Price = 9, ClubId = 7 },
                new() { Name = "Callum Wilson", Price = 10, ClubId = 7 },
                new() { Name = "Kieran Trippier", Price = 8, ClubId = 7 },
                new() { Name = "Miguel Almiron", Price = 7, ClubId = 7 },
                new() { Name = "Sven Botman", Price = 6, ClubId = 7 },
                new() { Name = "Nick Pope", Price = 5, ClubId = 7 },
                new() { Name = "Alexander Isak", Price = 9, ClubId = 7 },
                new() { Name = "Dan Burn", Price = 6, ClubId = 7 },
                new() { Name = "Joelinton", Price = 3, ClubId = 7 },
                new() { Name = "Fabian Schar", Price = 6, ClubId = 7 },
                new() { Name = "Ollie Watkins", Price = 2, ClubId = 8 },
                new() { Name = "Philippe Coutinho", Price = 10, ClubId = 8 },
                new() { Name = "Douglas Luiz", Price = 7, ClubId = 8 },
                new() { Name = "Emiliano Martinez", Price = 6, ClubId = 8 },
                new() { Name = "Tyrone Mings", Price = 7, ClubId = 8 },
                new() { Name = "Leon Bailey", Price = 8, ClubId = 8 },
                new() { Name = "John McGinn", Price = 7, ClubId = 8 },
                new() { Name = "Matty Cash", Price = 6, ClubId = 8 },
                new() { Name = "Lucas Digne", Price = 7, ClubId = 8 },
                new() { Name = "Jacob Ramsey", Price = 6, ClubId = 8 },
                new() { Name = "Dominic Calvert-Lewin", Price = 9, ClubId = 9 },
                new() { Name = "Jordan Pickford", Price = 6, ClubId = 9 },
                new() { Name = "Richarlison", Price = 1, ClubId = 9 },
                new() { Name = "Anthony Gordon", Price = 8, ClubId = 9 },
                new() { Name = "Yerry Mina", Price = 3, ClubId = 9 },
                new() { Name = "Allan", Price = 6, ClubId = 9 },
                new() { Name = "Abdoulaye Doucoure", Price = 7, ClubId = 9 },
                new() { Name = "Vitaliy Mykolenko", Price = 6, ClubId = 9 },
                new() { Name = "Ben Godfrey", Price = 6, ClubId = 9 },
                new() { Name = "Mason Holgate", Price = 5, ClubId = 9 },
                new() { Name = "Patrick Bamford", Price = 9, ClubId = 10 },
                new() { Name = "Raphinha", Price = 10, ClubId = 10 },
                new() { Name = "Kalvin Phillips", Price = 8, ClubId = 10 },
                new() { Name = "Illan Meslier", Price = 6, ClubId = 10 },
                new() { Name = "Liam Cooper", Price = 7, ClubId = 10 },
                new() { Name = "Jack Harrison", Price = 7, ClubId = 10 },
                new() { Name = "Stuart Dallas", Price = 6, ClubId = 10 },
                new() { Name = "Tyler Adams", Price = 3, ClubId = 10 },
                new() { Name = "Marc Roca", Price = 5, ClubId = 10 },
                new() { Name = "Pascal Struijk", Price = 5, ClubId = 10 }
            }
            .AsQueryable();
}