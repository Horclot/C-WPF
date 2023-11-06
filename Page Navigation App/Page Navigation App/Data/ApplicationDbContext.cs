using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=C:\\Users\\horcl\\OneDrive\\Рабочий стол\\GitHub\\C-WPF\\Page Navigation App\\Page Navigation App\\Data\\data.db");
    }

}
