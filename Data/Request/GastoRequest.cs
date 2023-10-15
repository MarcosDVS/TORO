namespace TORO.Data.Request;

public class GastoRequest
{
    public int Id { get; set; }
    public string Detalle { get; set; } = null!;
    public int Cantidad { get; set; }
    public decimal Costo { get; set; }
    public decimal CostoTotal { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
}