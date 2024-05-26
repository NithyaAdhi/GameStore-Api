using System;
using System.Collections.Generic;



public class InMemGamesRepository : IGamesRepository
{


    private readonly List<Game> game = new()
{
    new Game ()
    {
        Id = 1,
        Name = "Street Fighter II",
        Genre = "Fighting",
        Price = 19.99M,
        ReleaseDate = new DateTime (1991 , 2 ,1),
        ImageUri = "https://placehold.co/100"
    },
    new Game ()
    {
        Id = 2,
        Name = "Final Fantasy XIV",
        Genre = "Roleplaying",
        Price = 59.99M,
        ReleaseDate = new DateTime (2010 , 9 ,30),
        ImageUri = "https://placehold.co/100"
    },
    new Game ()
    {
        Id = 3,
        Name = "FIFA 23",
        Genre = "Sports",
        Price = 69.99M,
        ReleaseDate = new DateTime (1991 , 2 ,1),
        ImageUri = "https://placehold.co/100"
    }

};

    public List<Game> Game => game;

    public IEnumerable<Game> GetAll()
    {
        return Game;
    }

    public Game? Get(int id)
    {
        return Game.Find(game => game.Id == id);
    }

    public void Create(Game games)
    {
        games.Id = Game.Max(game => game.Id ) + 1;
        Game.Add(games);
    }

    public void Update(Game UpdatedGame)
    {
        var index = Game.FindIndex(game => game.Id == UpdatedGame.Id);
        Game[index] = UpdatedGame;
    }

    public void Delete(int id)
    {
        var index = Game.FindIndex(game => game.Id == id);
        Game.RemoveAt(index);
    }
}
