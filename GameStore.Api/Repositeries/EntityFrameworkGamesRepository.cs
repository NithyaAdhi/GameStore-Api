using Microsoft.EntityFrameworkCore;
using System;

public class EntityFrameworkGamesRepository : IGamesRepository
{
	private readonly GameStoreContext dbContext;

    public EntityFrameworkGamesRepository(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task CreateAsync(Game game)
    {
       dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
       await dbContext.Games.Where(game => game.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task <Game?> Get(int id)
    {
        return await dbContext.Games.FindAsync(id);
    }

    public async Task <IEnumerable<Game>> GetAllAsync()
    {
        return await dbContext.Games.AsNoTracking().ToListAsync();
    }

    public Task<Game?> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Game UpdatedGame)
    {
        dbContext.Update(UpdatedGame);
        await dbContext.SaveChangesAsync();
    }
}
