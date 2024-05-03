using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient
{
private readonly Genre[] genres = 
[
    new(){
        Id = 1,
        Name = "Roleplaying",
    },
    new(){
        Id = 2,
        Name = "Racing",
    },
    new(){
        Id = 3,
        Name = "Sports",
    },
    new(){
        Id = 4,
        Name = "Kids and Family",
    },
    new(){
        Id = 5,
        Name = "Fighting",
    },
];

public Genre[] GetGenres() => genres;
}
