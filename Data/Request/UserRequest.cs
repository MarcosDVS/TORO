using System.ComponentModel.DataAnnotations;

namespace TORO.Data.Request;

public class UserRequest
{
    public UserRequest()
    { 
        
    }
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre del usuario es obligatorio")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "El apellido del usuario es obligatorio")]
    public string Apellido { get; set; } = null!;
    [Required(ErrorMessage = "El correo del usuario es obligatorio")]
    [EmailAddress(ErrorMessage = "El correo no es válido")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "La clave del usuario es obligatorio")]
    [StringLength(12, MinimumLength = 8, ErrorMessage = "La clave debe tener entre 8 y 12 caracteres")]
    public string Clave { get; set; } = null!;
    public string Role { get; set; } = null!;

}