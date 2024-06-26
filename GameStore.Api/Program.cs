//using GameStore.Api.Entities;

/* const string GetGameEndpointName = "GetGame";

List<Game> game = new()
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

}; */


using GameStore.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);
//builder.Services.AddScoped<IGamesRepository, EntityFrameworkGamesRepository>();

//read connection string
//var connString = builder.Configuration.GetConnectionString("GameStoreContext");
//builder.Services.AddSqlServer<GameStoreContext>(connString);

var app = builder.Build();

await app.Services.initializeDbAsync();

    app.MapGamesEndpoints();

/* var group = app.MapGroup("/games")
               .WithParameterValidation();

//app.MapGet("/games", () => game);

group.MapGet("/", () => game);

//app.MapGet("/games/{id}", (int id) => game.Find(game => game.Id == id));

group.MapGet("/{id}", (int id) =>
{
    Game? games = game.Find(game => game.Id == id);
    if (games is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(games);
})
.WithName(GetGameEndpointName);

group.MapPost("/", (Game games) =>
{
    games.Id = game.Max(game => game.Id) + 1;
    game.Add(games);
    return Results.CreatedAtRoute(GetGameEndpointName, new {id = games.Id}, games);
});

group.MapPut("/{id}", (int id, Game updatedGame) =>
{
    Game? existingGame = game.Find(game => game.Id == id);

    if(existingGame is null)
    {
        return Results.NotFound();
    }
    existingGame.Name = updatedGame.Name;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.Genre = updatedGame.Genre;
    existingGame.ImageUri = updatedGame.ImageUri;

    return Results.NoContent();
});

app.MapDelete("/games/{id}", (int id) =>
{
    Game? games = game.Find(game => game.Id == id);

    if (games is not  null)
    {
        game.Remove(games);
    }

    return Results.NoContent();
});
*/

app.Run();
