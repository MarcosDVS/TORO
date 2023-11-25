using System.ComponentModel.DataAnnotations;
using TORO.Data.Model;

namespace TORO.Data.Request;

public class FacturaRequest
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
    public string Cliente { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public virtual ICollection<FacturaDetalleRequest> Detalles { get; set; } 
        = new List<FacturaDetalleRequest>();
    public decimal SubTotal => 
        Detalles != null ? 
        Detalles.Sum(d=>d.SubTotal)
        :
        0;
    
}
public class FacturaDetalleRequest
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public string? Descripcion { get; set; }
    public int Cantidad { get; set; } = 1;
    public decimal Kilo { get; set; }
    public decimal PrecioKilo { get; set; } = 13500;
    public decimal Precio { get; set; } 
    public decimal SubTotal => Cantidad * Precio;
}