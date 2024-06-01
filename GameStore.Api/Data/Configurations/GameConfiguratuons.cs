using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Api.Data.Configurations;

public class GameConfiguratuons : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.Property(game => game.Price)
            .HasPrecision(5,2);
    }
}
