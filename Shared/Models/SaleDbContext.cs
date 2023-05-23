using Microsoft.EntityFrameworkCore;

public class PrestamoDbContext : DbContext
{
    public DbSet<Prestamo> Prestamos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       
        optionsBuilder.UseSqlServer("Server=localhost;Database=Bd_prestamo;User Id=root;Password=Joseluis03");
    }
}
