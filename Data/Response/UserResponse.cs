using TORO.Data.Request;

namespace TORO.Data.Response;

public class UserResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Clave { get; set; } = null!;
    public string Role { get; set; } = null!;


    public UserRequest ToRequest()
    {
        return new UserRequest
        {
            Id = Id,
            Nombre = Nombre,
            Apellido = Apellido,
            Email = Email,
            Clave = Clave,
            Role = Role
        };
    }
}