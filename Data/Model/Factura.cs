using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TORO.Data.Request;
using TORO.Data.Response;
using TORO.Data.Services;

namespace TORO.Data.Model;

// Clase para representar la entidad Factura
public class Factura
{
    public Factura()
    {
        //Contacto = new Contacto();
        Detalles = new List<FacturaDetalle>();
    }
    [Key]
    public int Id { get; set; }
    public string Cliente { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public virtual ICollection<FacturaDetalle> Detalles { get; set; }
    public static Factura Crear(FacturaRequest request)
        => new()
        {
            Cliente = request.Cliente,
            Fecha = DateTime.Now,
            Detalles = request.Detalles
            .Select(detalle=>FacturaDetalle.Crear(detalle))
            .ToList()
        };

    [NotMapped]
    public decimal SubTotal =>
        Detalles != null ? //IF
        Detalles.Sum(d => d.SubTotal) //Verdadero
        :
        0;//Falso
    public FacturaRespose ToResponse()
        => new()
        {
            Id = Id,
            Cliente = Cliente,
            Fecha = Fecha,
            Detalles = Detalles.Select(d => d.ToResponse()).ToList()
        };
}


public class FacturaDetalle
{
    public FacturaDetalle()
    {
        //Factura = new Factura();
        //Producto = new Producto();
    }

    [Key]
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public int AnimalId { get; set; }
    public int Cantidad { get; set; } = 1;
    public decimal Kilo { get; set; }
    public decimal PrecioKilo { get; set; } = 13500;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }
    [NotMapped]
    public decimal SubTotal => Cantidad * Precio;
    
    public static FacturaDetalle Crear(FacturaDetalleRequest request)
    => new()
    {
        AnimalId = request.AnimalId,
        Cantidad = request.Cantidad,
        Kilo = request.Kilo,
        PrecioKilo = request.PrecioKilo,
        Precio = request.Precio,
    };


    #region Relaciones
    [ForeignKey(nameof(FacturaId))]
    public virtual Factura Factura { get; set; }
    [ForeignKey(nameof(AnimalId))]
    public virtual Animal Animal { get; set; }
    #endregion

    public FacturaDetalleResponse ToResponse()
        => new()
        {
            Id = Id,
            Animal = Animal.ToResponse(),
            Cantidad = Cantidad,
            Kilo = Kilo,
            PrecioKilo = PrecioKilo,
            Precio = Precio,
            FacturaId = FacturaId
        };
}


