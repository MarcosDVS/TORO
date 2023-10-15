using System.ComponentModel.DataAnnotations;
using TORO.Data.Request;
using TORO.Data.Response;

namespace TORO.Data.Model;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Clave { get; set; } = null!;


    

    public static User Crear(UserRequest user) => new()
    {
        Nombre = user.Nombre,
        Apellido = user.Apellido,
        Email = user.Email,
        Clave = user.Clave,
    };
    public bool Modificar(UserRequest user)
    {
        var cambio = false;
        if (Nombre != user.Nombre) Nombre = user.Nombre; cambio = true;
        if (Apellido != user.Apellido) Apellido = user.Apellido; cambio = true;
        if (Email != user.Email) Email = user.Email; cambio = true;
        if (Clave != user.Clave) Clave = user.Clave; cambio = true;

        return cambio;
    }
    public UserResponse ToResponse() => new()
    {
        Id = Id,
        Nombre = Nombre,
        Apellido = Apellido,
        Email = Email,
        Clave = Clave,
    };
}