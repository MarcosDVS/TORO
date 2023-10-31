using System.ComponentModel.DataAnnotations;

namespace TORO.Data.Request;

public class AnimalRequest
{
    public AnimalRequest()
    {
        
    }
    public int Id { get; set; }
    [Required(ErrorMessage = "El arete del bovino es obligatorio")]
    public string Arete { get; set; } ="";
    [Required(ErrorMessage = "La raza del bovino es obligatorio")]
    public string Raza { get; set; } = null!;
    [Required(ErrorMessage = "El sexo del bovino es obligatorio")]
    public string Sexo { get; set; } = "";
    public decimal CostoCompra { get; set; }
    public DateTime FechaNacimiento { get; set; } = DateTime.Now;
    public bool Vendido { get; set; } = false;
}