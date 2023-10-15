using Microsoft.EntityFrameworkCore;
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
                return new Result() { Mensaje = "No se encontro el gasto", Exitoso = false };

            if (user.Modificar(request))
                await _database.SaveChangesAsync();

            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
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
                    (u.Nombre + " "+ u.Apellido+" "+ u.Email + " "+ u.Clave)
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
    #endregion

    public async Task<Result<User>> Login(string username, string password)
    {
        try
        {
            var user = await _database.Users
                .FirstOrDefaultAsync(u => u.Email == username && u.Clave == password);

            if (user != null)
            {
                return new Result<User>
                {
                    Exitoso = true,
                    Datos = user,
                    Mensaje = "Inicio de sesión exitoso"
                };
            }
            else
            {
                return new Result<User>
                {
                    Exitoso = false,
                    Mensaje = "Credenciales de inicio de sesión incorrectas"
                };
            }
        }
        catch (Exception ex)
        {
            return new Result<User>
            {
                Exitoso = false,
                Mensaje = $"Error en el inicio de sesión: {ex.Message}"
            };
        }
    }
}


public interface IUserServices
{
    Task<Result<List<UserResponse>>> Consultar(string filtro);
    Task<Result> Crear(UserRequest request);
    Task<Result> Eliminar(UserRequest request);
    Task<Result> Modificar(UserRequest request);
    Task<Result<User>> Login(string username, string password);
}