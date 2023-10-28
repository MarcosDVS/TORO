using Microsoft.EntityFrameworkCore;
using TORO.Data.Model;

namespace TORO.Data.Context;
// Cuarto paso inserta el constructor en la clase publica e inserta las tablas de la sigte forma
//public DbSet<Gasto> Gastos { get; set; } y la funcion SaveChangesAsync tanbien inserta las 
//tablas en la interface de la siguiente forma public DbSet<Gasto> Gastos { get; set; }
//Ahora dirijete a la clase Program.cs
public interface IMyDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<LostAnimal> LostAnimals { get; set; }
    public DbSet<Gasto> Gastos { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
public class MyDbContext : DbContext, IMyDbContext
{
    #region Constructor
    public MyDbContext(DbContextOptions options): base(options)
    {
        
    }
    #endregion
    
    #region Tablas
    public DbSet<User> Users { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<LostAnimal> LostAnimals { get; set; }
    public DbSet<Gasto> Gastos { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
    #endregion

    #region Funciones
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
    #endregion
}