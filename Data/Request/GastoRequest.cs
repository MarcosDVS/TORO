using System.ComponentModel.DataAnnotations;

namespace TORO.Data.Request;

public class GastoRequest
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El detalle del gasto es obligatorio")]
    public string Detalle { get; set; } = null!;
    [Required(ErrorMessage = "La cantidad del gasto es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "La Cantidad debe ser mayor que 0")]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = "El costo del gasto es obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El costo debe ser mayor que 0")]
    public decimal Costo { get; set; }
    public decimal CostoTotal { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
}