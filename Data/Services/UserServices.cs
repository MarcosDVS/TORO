using Microsoft.EntityFrameworkCore;
using TORO.Authentication;
using TORO.Data.Context;
using TORO.Data.Model;
using TORO.Data.Request;
using TORO.Data.Response;

namespace TORO.Data.Services;
public class UserServices : IUserServices
{
    #region Constructor y mienbro privado
    private MyDbContext _database;

    public UserServices(MyDbContext database)
    {
        _database = database;
    }
    #endregion
    //Tarea para registrar un Vehiculo nuevo en la base de datos...
    #region Funciones
    public async Task<Result> Crear(UserRequest request)
    {
        try
        {
            var contacto = User.Crear(request);

            // Hash de la contraseña antes de almacenarla
            contacto.Clave = HashPassword(request.Clave);

            _database.Users.Add(contacto);
            await _database.SaveChangesAsync();
            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {
            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    public async Task<Result> Modificar(UserRequest request)
    {
        try
        {
            var user = await _database.Users
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (user == null)
                return new Result() { Mensaje = "No se encontró el usuario", Exitoso = false };

            // Hash de la nueva contraseña antes de almacenarla
            user.Clave = HashPassword(request.Clave);

            if (user.Modificar(request))
                await _database.SaveChangesAsync();

            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {
            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    private string HashPassword(string password)
    {
        // Genera un hash seguro utilizando bcrypt
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    public async Task<Result> Eliminar(UserRequest request)
    {
        try
        {
            var contacto = await _database.Users
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Mensaje = "No se encontro el usuario", Exitoso = false };

            _database.Users.Remove(contacto);
            await _database.SaveChangesAsync();
            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    public async Task<Result<List<UserResponse>>> Consultar(string filtro)
    {
        try
        {
            var usuarios = await _database.Users
                .Where(u =>
                    (u.Nombre + " "+ u.Apellido+" "+ u.Email + " "+ u.Clave+" "+u.Role)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(u => u.ToResponse())
                .ToListAsync();
            return new Result<List<UserResponse>>()
            {
                Mensaje = "Ok",
                Exitoso = true,
                Datos = usuarios
            };
        }
        catch (Exception E)
        {
            return new Result<List<UserResponse>>
            {
                Mensaje = E.Message,
                Exitoso = false
            };
        }
    }
    public async Task CrearUsuarioAdmin()
    {
        var adminUser = await _database.Users.FirstOrDefaultAsync(u => u.Email == "admin");

        if (adminUser == null)
        {
            adminUser = new User
            {
                Nombre = "ADMIN",
                Apellido = "TORO",
                Email = "admin",
                Clave = "1234", // Recuerda realizar un hash de la contraseña en un entorno de producción
                Role = "Administrator"
            };

            _database.Users.Add(adminUser);
            await _database.SaveChangesAsync();
        }
    }
    #endregion

}


public interface IUserServices
{
    Task<Result<List<UserResponse>>> Consultar(string filtro);
    Task<Result> Crear(UserRequest request);
    Task<Result> Eliminar(UserRequest request);
    Task<Result> Modificar(UserRequest request);
    Task CrearUsuarioAdmin();
}