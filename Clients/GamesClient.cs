using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
 private readonly List<GameSummary> games = 
    [
    new() {
        Id = 1,
        Name = "Street Fighter II",
        Genre = "Fight",
        Price = 19.99M,
        ReleaseDate = new DateOnly(1992, 7, 15)
    },
    new() {
        Id = 2,
        Name = "Surbway Surf",
        Genre = "Role Playing",
        Price = 9.99M,
        ReleaseDate = new DateOnly(2001, 7, 15)
    },
    new() {
        Id = 3,
        Name = "Mortal Kombat",
        Genre = "Action",
        Price = 59.99M,
        ReleaseDate = new DateOnly(2021, 7, 15)
    },
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)

{
    ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
    var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));


    var gameSummary = new GameSummary
    {
        Id = games.Count + 1,
        Name = game.Name,
        Genre = genre.Name,
        Price = game.Price,
        ReleaseDate = game.ReleaseDate
    };

    games.Add(gameSummary);
}
}
