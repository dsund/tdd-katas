using Microsoft.EntityFrameworkCore;
using miniapi.domain;

namespace miniapi.infrastructure;
public class MiniApiDbContext : DbContext
{
    private readonly string schema;
    public MiniApiDbContext(DbContextOptions<MiniApiDbContext> options)
        : this(options, "minidb")
    {
    }

    public MiniApiDbContext(DbContextOptions<MiniApiDbContext> options, string schema)
    : base(options)
    {
        this.schema = schema;
    }

    public DbSet<Item> Items => Set<Item>();
}
