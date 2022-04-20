using Microsoft.EntityFrameworkCore;
public class EFDataContext : DbContext
{
    public EFDataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
    }
}