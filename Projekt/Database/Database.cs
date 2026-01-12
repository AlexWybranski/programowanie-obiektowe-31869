using Microsoft.EntityFrameworkCore;
using Projekt.Items;
using Console = Projekt.Items.Console;

namespace Projekt.Database;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options)
    {
        
    }
    
    public DbSet<Console> Consoles { get; set; }
    public DbSet<Accessory> Accessories { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Wishlist> Wishlist { get; set; }
}