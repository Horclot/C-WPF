using Microsoft.EntityFrameworkCore;

public class ApplicationDbItem : DbContext
{
    public DbSet<Items> Item { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=\"C:\\Users\\diana\\OneDrive\\Рабочий стол\\GitHub\\C-WPF\\Page Navigation App\\Page Navigation App\\Data\\data.db\"");
    }
}
