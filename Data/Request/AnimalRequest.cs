namespace TORO.Data.Request;

public class AnimalRequest
{
    public AnimalRequest()
    {
        
    }
    public int Id { get; set; }
    public string Arete { get; set; } = null!;
    public string Raza { get; set; } = null!;
    public string Sexo { get; set; } = null!;
    public decimal? CostoCompra { get; set; }
    public DateTime FechaNacimiento { get; set; } = DateTime.Now;
    public bool Muerto { get; set; } = false;
}