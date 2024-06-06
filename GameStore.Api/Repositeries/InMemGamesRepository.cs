using System;
using System.Collections.Generic;
using System.Threading.Tasks;



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

    public async Task <IEnumerable<Game>> GetAllAsync()
    {
        return await Task.FromResult(Game);
    }

    public async Task <Game?> GetAsync(int id)
    {
        return await Task.FromResult(Game.Find(game => game.Id == id));
    }

    public async Task CreateAsync(Game games)
    {
        games.Id = Game.Max(game => game.Id ) + 1;
        Game.Add(games);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Game UpdatedGame)
    {
        var index = Game.FindIndex(game => game.Id == UpdatedGame.Id);
        Game[index] = UpdatedGame;
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var index = Game.FindIndex(game => game.Id == id);
        Game.RemoveAt(index);
        await Task.CompletedTask;
    }
}
