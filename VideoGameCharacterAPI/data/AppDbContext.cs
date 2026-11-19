

using Microsoft.EntityFrameworkCore;
using VideoGameCharacterAPI.Model;

namespace VideoGameCharacterAPI.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Character> Characters => Set<Character>();
}
