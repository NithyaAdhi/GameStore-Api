using System;

public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options)
        : base(options)
    {
        
    }

    public DbSet<Game> Games => Set<Game>();
}
