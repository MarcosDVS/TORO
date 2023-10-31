using TORO.Data.Model;
using TORO.Data.Request;

namespace TORO.Data.Response;

public class AnimalResponse
{
    public int Id { get; set; }
    public string Arete { get; set; } ="";
    public string Raza { get; set; } = null!;
    public string Sexo { get; set; } = "";
    public decimal CostoCompra { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public bool Vendido { get; set; } = false;

    public AnimalRequest ToRequest()
    {
        return new AnimalRequest
        {
            Id = Id,
            Raza = Raza,
            Sexo = Sexo,
            CostoCompra = CostoCompra,
            FechaNacimiento = FechaNacimiento,
            Vendido = Vendido
        };
    }
}