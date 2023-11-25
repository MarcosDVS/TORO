using System.ComponentModel.DataAnnotations.Schema;
using TORO.Data.Request;

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

    public FacturaRequest ToRequest()
{
    return new FacturaRequest
    {
        Id = Id,
        Cliente = Cliente,
        Fecha = Fecha,
        Detalles = Detalles.Select(d => new FacturaDetalleRequest
        {
            Id = d.Id,
            AnimalId = d.Animal.Id, // Asegúrate de que esto sea correcto
            Descripcion = d.Animal.Arete + " " + d.Animal.Raza, // Asegúrate de que esto sea correcto
            Cantidad = d.Cantidad,
            Precio = d.Precio
        }).ToList()
    };
}

}

public class FacturaDetalleResponse
{
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public AnimalResponse Animal { get; set; } = null!;
    public int Cantidad { get; set; } = 1;
    public decimal Kilo { get; set; }
    public decimal PrecioKilo { get; set; } = 13500;
    public decimal Precio { get; set; }
    [NotMapped]
    public decimal SubTotal => Cantidad * Precio;
}