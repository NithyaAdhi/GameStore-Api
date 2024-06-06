using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using System;

public static class GamesEndpoints { 

    const string GetGameEndpointName = "GetGame";



    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
	{
       

        var group = routes.MapGroup("/games")
                       .WithParameterValidation();

        //app.MapGet("/games", () => game);

        group.MapGet("/", async (IGamesRepository repository) => 
        (await repository.GetAllAsync()).Select(game => game.AsDto()));

        //app.MapGet("/games/{id}", (int id) => game.Find(game => game.Id == id));

        group.MapGet("/{id}", async (IGamesRepository repository, int id) =>
        {
            Game? games = await repository.GetAsync(id);
            return games is not null ? Results.Ok(games.AsDto()): Results.NotFound();
            
        })
        .WithName(GetGameEndpointName);

        group.MapPost("/",async (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                ReleaseDate = gameDto.ReleaseDate,
                Price = gameDto.Price,
                ImageUri = gameDto.ImageUri
            };

            await repository.CreateAsync(game);
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", async (IGamesRepository repository,int id, UpdateGameDto updatedGameDto) =>
        {
            Game? existingGame =await repository.GetAsync(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }
            existingGame.Name = updatedGameDto.Name;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.ImageUri = updatedGameDto.ImageUri;

            await repository.UpdateAsync(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/games/{id}", async (IGamesRepository repository, int id) =>
        {
            Game? games =await repository.GetAsync(id);

            if (games is not null)
            {
               await repository.DeleteAsync(id);
            }

            return Results.NoContent();
        });

        return group;
    }
}
