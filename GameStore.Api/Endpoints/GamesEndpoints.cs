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

        group.MapGet("/", (IGamesRepository repository) => 
        repository.GetAll().Select(game => game.AsDto()));

        //app.MapGet("/games/{id}", (int id) => game.Find(game => game.Id == id));

        group.MapGet("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? games = repository.Get(id);
            return games is not null ? Results.Ok(games.AsDto()): Results.NotFound();
            
        })
        .WithName(GetGameEndpointName);

        group.MapPost("/", (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                ReleaseDate = gameDto.ReleaseDate,
                Price = gameDto.Price,
                ImageUri = gameDto.ImageUri
            };

            repository.Create(game);
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (IGamesRepository repository,int id, UpdateGameDto updatedGameDto) =>
        {
            Game? existingGame = repository.Get(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }
            existingGame.Name = updatedGameDto.Name;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.ImageUri = updatedGameDto.ImageUri;

            repository.Update(existingGame);

            return Results.NoContent();
        });

        group.MapDelete("/games/{id}", (IGamesRepository repository, int id) =>
        {
            Game? games = repository.Get(id);

            if (games is not null)
            {
                repository.Delete(id);
            }

            return Results.NoContent();
        });

        return group;
    }
}
