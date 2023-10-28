using TORO.Data.Request;

namespace TORO.Data.Response;

public class LostAnimalResponse
{
    public int Id { get; set; }
    public string Arete { get; set; } = null!;
    public string Raza { get; set; } = null!;
    public string Sexo { get; set; } = null!;
    public decimal CostoCompra { get; set; }
    public DateTime FechaNacimiento { get; set; } = DateTime.Now;
    public DateTime FechaMuerte { get; set; } = DateTime.Now;

    public LostAnimalRequest ToRequest()
    {
        return new LostAnimalRequest
        {
            Id = Id,
            Raza = Raza,
            Sexo = Sexo,
            CostoCompra = CostoCompra,
            FechaNacimiento = FechaNacimiento,
            FechaMuerte = FechaMuerte
        };
    }
}