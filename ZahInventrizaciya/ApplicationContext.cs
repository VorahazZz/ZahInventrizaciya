using Microsoft.EntityFrameworkCore;
using ZahInventrizaciya.Entities;

namespace ZahInventrizaciya;

public sealed class ApplicationContext : DbContext
{
    /// <summary>
    /// Кабинеиы техникума
    /// </summary>
    public DbSet<Classroom> Classrooms { get; set; }
    /// <summary>
    /// МОЛ
    /// </summary>
    public DbSet<MOL> MOLs { get; set; }
    /// <summary>
    /// Учителя
    /// </summary>
    public DbSet<Teacher> Teachers { get; set; }
    /// <summary>
    /// Предметы
    /// </summary>
    public DbSet<Item> Items { get; set; }
    /// <summary>
    /// Предметы и классы
    /// </summary>
    public DbSet<ItemsAndClassrooms> ItemsAndClassrooms { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Inventory;Username=postgres;Password=root");
    }
}