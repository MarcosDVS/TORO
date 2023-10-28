using Microsoft.EntityFrameworkCore;
using TORO.Data.Context;
using TORO.Data.Model;
using TORO.Data.Request;
using TORO.Data.Response;

namespace TORO.Data.Services;

#region Interface
public interface ILostAnimalServices
{
    Task<Result<List<LostAnimalResponse>>> Consultar(string filtro);
    Task<Result> Crear(LostAnimalRequest request);
    Task<Result> Eliminar(LostAnimalRequest request);
    Task<Result> Modificar(LostAnimalRequest request);
}
#endregion
public class LostAnimalServices : ILostAnimalServices
{
    #region Constructor y mienbro privado
    private MyDbContext _database;

    public LostAnimalServices(MyDbContext database)
    {
        _database = database;
    }
    #endregion
    #region Funciones
    public async Task<Result> Crear(LostAnimalRequest request)
    {
        try
        {
            var item = LostAnimal.Crear(request);
            _database.LostAnimals.Add(item);
            await _database.SaveChangesAsync();
            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    public async Task<Result> Modificar(LostAnimalRequest request)
    {
        try
        {
            var user = await _database.LostAnimals
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (user == null)
                return new Result() { Mensaje = "No se encontro", Exitoso = false };

            if (user.Modificar(request))
                await _database.SaveChangesAsync();

            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    public async Task<Result> Eliminar(LostAnimalRequest request)
    {
        try
        {
            var item = await _database.LostAnimals
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Mensaje = "No se encontro", Exitoso = false };

            _database.LostAnimals.Remove(item);
            await _database.SaveChangesAsync();
            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    public async Task<Result<List<LostAnimalResponse>>> Consultar(string filtro)
    {
        try
        {
            var item = await _database.LostAnimals
                .Where(u =>
                    (u.Arete + " "+ u.Raza+" "+ u.Sexo + " "+ u.CostoCompra+" "+ u.FechaNacimiento+" "+ u.FechaMuerte)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(u => u.ToResponse())
                .ToListAsync();
            return new Result<List<LostAnimalResponse>>()
            {
                Mensaje = "Ok",
                Exitoso = true,
                Datos = item
            };
        }
        catch (Exception E)
        {
            return new Result<List<LostAnimalResponse>>
            {
                Mensaje = E.Message,
                Exitoso = false
            };
        }
    }
    #endregion
}