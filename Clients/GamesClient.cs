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
        Genre genre = GetGenreById(game.GenreId);

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

  
    public GameDetails GetGame(int id)
    {
        GameSummary? game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(
            genre.Name,
            game.Genre,
            StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updatedGame) 
    {
        var genre = GetGenreById(updatedGame.GenreId);
GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

existingGame.Name = updatedGame.Name;
existingGame.Price = updatedGame.Price;
existingGame.ReleaseDate = updatedGame.ReleaseDate;
existingGame.Genre = genre.Name;
    }

    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.Single(genre => genre.Id == int.Parse(id));
       
    }

}
