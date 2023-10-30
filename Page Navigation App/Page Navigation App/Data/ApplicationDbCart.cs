using Microsoft.EntityFrameworkCore;

public class ApplicationDbCart : DbContext
{
    public DbSet<CartP> Carts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=\"C:\\Users\\diana\\OneDrive\\Рабочий стол\\GitHub\\C-WPF\\Page Navigation App\\Page Navigation App\\Data\\data.db\"");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Определите сущность CartP как keyless entity
        modelBuilder.Entity<CartP>().HasNoKey();
    }
}
