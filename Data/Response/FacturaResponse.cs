using System.ComponentModel.DataAnnotations.Schema;

namespace TORO.Data.Response;

public class FacturaRespose
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public DateTime Fecha { get; set; }
    public virtual ICollection<FacturaDetalleResponse> Detalles { get; set; }
    [NotMapped]
    public decimal SubTotal =>
        Detalles != null ? //IF
        Detalles.Sum(d => d.SubTotal) //Verdadero
        :
        0;//Falso
}

public class FacturaDetalleResponse
{
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public AnimalResponse Animal { get; set; } = null!;
    public int Cantidad { get; set; } = 1;
    public decimal Precio { get; set; }
    [NotMapped]
    public decimal SubTotal => Cantidad * Precio;
}