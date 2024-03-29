using Microsoft.EntityFrameworkCore;
using TORO.Data.Context;
using TORO.Data.Model;
using TORO.Data.Request;
using TORO.Data.Response;

namespace TORO.Data.Services;

public interface IAnimalServices
{
    Task<Result<List<AnimalResponse>>> Consultar(string filtro);
    Task<Result<int>> Registrar(AnimalRequest datos);
    Task<Result> Eliminar(AnimalRequest request);
    Task<Result> Modificar(AnimalRequest request);
    Task<bool> MarcarAnimalesComoVendidos(List<int> animalIds);
}
public class AnimalServices : IAnimalServices
{
    private readonly IMyDbContext dbContext;

    public AnimalServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
	//Tarea para registrar un Vehiculo nuevo en la base de datos...
    public async Task<Result<int>> Registrar(AnimalRequest datos)
    {
        try
        {
            var vehiculo = Animal.Crear(datos);
            dbContext.Animals.Add(vehiculo);
            await dbContext.SaveChangesAsync(new());

            return Result<int>.Success(vehiculo.Id);
        }
        catch (Exception E)
        {
            return Result<int>.Fail(E.Message);
        }
    }
    //Tarea para consultar los vehiculos en la base de datos...
    public async Task<Result<List<AnimalResponse>>> Consultar(string filtro)
    {
        try
            {
                var item = await dbContext.Animals
                    .Where(u =>
                        (u.Arete + " " + u.Raza + " " + u.Sexo + " " + u.FechaNacimiento+" "+u.CostoCompra)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(u => u.ToResponse())
                    .ToListAsync();
                return new Result<List<AnimalResponse>>()
                {
                    Mensaje = "Ok",
                    Exitoso = true,
                    Datos = item
                };
            }
            catch (Exception E)
            {
                return new Result<List<AnimalResponse>>
                {
                    Mensaje = E.Message,
                    Exitoso = false
                };
            }
    }

public async Task<Result> Eliminar(AnimalRequest request)
{
    try
    {
        var item = await dbContext.Animals
            .FirstOrDefaultAsync(c => c.Id == request.Id);
        if (item == null)
            return new Result() { Mensaje = "No se encontro", Exitoso = false };

        dbContext.Animals.Remove(item);
        await dbContext.SaveChangesAsync();
        return new Result() { Mensaje = "Ok", Exitoso = true };
    }
    catch (Exception E)
    {

        return new Result() { Mensaje = E.Message, Exitoso = false };
    }
}

public async Task<Result> Modificar(AnimalRequest request)
{
    try
    {
        var user = await dbContext.Animals
            .FirstOrDefaultAsync(c => c.Id == request.Id);
        if (user == null)
            return new Result() { Mensaje = "No se encontro", Exitoso = false };

        if (user.Modificar(request))
            await dbContext.SaveChangesAsync();

        return new Result() { Mensaje = "Ok", Exitoso = true };
    }
    catch (Exception E)
    {

        return new Result() { Mensaje = E.Message, Exitoso = false };
    }
}
    public async Task<bool> MarcarAnimalesComoVendidos(List<int> animalIds)
    {
        try
        {
            var animales = await dbContext.Animals
                .Where(a => animalIds.Contains(a.Id))
                .ToListAsync();

            foreach (var animal in animales)
            {
                animal.Vendido = true;
            }

            await dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}