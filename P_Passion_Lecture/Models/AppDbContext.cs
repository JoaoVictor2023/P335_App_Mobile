using Microsoft.EntityFrameworkCore;

namespace P_Passion_Lecture.Models;

public class AppDbContext : DbContext
{
    public DbSet<BookEntry> Books { get; set; }

    private string _dbPath = FileSystem.Current.AppDataDirectory + "/data.sqlite";

    public AppDbContext()
    {
        // Create the database if it doesn't exist
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={_dbPath}");

    }



}