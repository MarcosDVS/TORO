using TORO.Data.Request;

namespace TORO.Data.Response;

public class GastoResponse
{
    public int Id { get; set; }
    public string Detalle { get; set; } = null!;
    public int Cantidad { get; set; }
    public decimal Costo { get; set; }
    public decimal CostoTotal { get; set; }
    public DateTime Fecha { get; set; }

    public GastoRequest ToRequest()
    {
        return new GastoRequest
        {
            Id = Id,
            Detalle = Detalle,
            Cantidad = Cantidad,
            Costo = Costo,
            CostoTotal = CostoTotal,
            Fecha = Fecha
        };
    }
}