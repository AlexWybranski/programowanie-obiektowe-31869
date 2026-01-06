using Microsoft.EntityFrameworkCore;

namespace Lab3_komis.Database;

public class CarsDb : DbContext
{
    public string DbPath { get; }
    
    public CarsDb()
    {
        var folder = Environment.SpecialFolder.MyDocuments;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "vehicles.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Bike> Bikes { get; set; }

    public List<Vehicle> Vehicles
    {
        get
        {
            var list = new  List<Vehicle>();
            list.AddRange(Bikes.ToList());
            list.AddRange(Cars.ToList());
            return list;
        }
    }
}