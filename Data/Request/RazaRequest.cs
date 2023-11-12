using System.ComponentModel.DataAnnotations;

namespace TORO.Data.Request;

public class RazaRequest
{
    public RazaRequest()
    {
        
    }
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre de la raza es obligatorio")]
    public string Nombre { get; set; } = "";
}