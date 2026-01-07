using AutoKomis.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoKomis.Database;

public class VehicleDb : DbContext
{
    public VehicleDb(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Car> Cars { get; set; }
}