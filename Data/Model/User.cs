using System.ComponentModel.DataAnnotations;
using TORO.Data.Request;
using TORO.Data.Response;
using TORO.Authentication;
using BCrypt.Net;

namespace TORO.Data.Model;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Clave { get; set; } = null!;
    public string Role { get; set; } = null!;


    private static string HashPassword(string password)
    {
        // Genera un hash seguro utilizando bcrypt
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    public static User Crear(UserRequest user) => new()
    {
        Nombre = user.Nombre,
        Apellido = user.Apellido,
        Email = user.Email,
        Clave = user.Clave,
        Role = user.Role
    };
    public bool Modificar(UserRequest user)
    {
        var cambio = false;
        if (Nombre != user.Nombre) Nombre = user.Nombre; cambio = true;
        if (Apellido != user.Apellido) Apellido = user.Apellido; cambio = true;
        if (Email != user.Email) Email = user.Email; cambio = true;
        if (Clave != HashPassword(user.Clave)) Clave = HashPassword(user.Clave); cambio = true;
        if (Role != user.Role) Role = user.Role; cambio = true;

        return cambio;
    }
    public UserResponse ToResponse() => new()
    {
        Id = Id,
        Nombre = Nombre,
        Apellido = Apellido,
        Email = Email,
        Clave = Clave,
        Role = Role
    };
}