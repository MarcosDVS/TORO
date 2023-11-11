using Microsoft.EntityFrameworkCore;
using TORO.Data.Context;
using TORO.Data.Model;
using TORO.Data.Request;
using TORO.Data.Response;

namespace TORO.Data.Services;
// Para crear los servicios es generar un constructor con un mienbro privado de solo lectura
//y crear las funciones del servicio en la clase publica luego crea la interfas
//ahora ve al Program.cs e inserta los servicios de la sigte forma 
//builder.Services.AddScoped<IRazaServices,RazaServices>();
//luego inserta los mismos servicios en el archivo _Import.razor de la sigte forma
//@inject IRazaServices razaServices;

// Una vez ya hallas terminado con los Servicios ya puedes empezar a trabajar la parte visual
//del proyecto en la carpeta Pages.
public class RazaServices : IRazaServices
{
    #region Constructor y mienbro privado
    private MyDbContext _database;

    public RazaServices(MyDbContext database)
    {
        _database = database;
    }
    #endregion
    #region Funciones
    public async Task<Result> Crear(RazaRequest request)
    {
        try
        {
            var item = Raza.Crear(request);
            _database.Razas.Add(item);
            await _database.SaveChangesAsync();
            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    public async Task<Result> Modificar(RazaRequest request)
    {
        try
        {
            var item = await _database.Razas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Mensaje = "No se encontro", Exitoso = false };

            if (item.Modificar(request))
                await _database.SaveChangesAsync();

            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    public async Task<Result> Eliminar(RazaRequest request)
    {
        try
        {
            var item = await _database.Razas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (item == null)
                return new Result() { Mensaje = "No se encontro el usuario", Exitoso = false };

            _database.Razas.Remove(item);
            await _database.SaveChangesAsync();
            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    public async Task<Result<List<RazaResponse>>> Consultar(string filtro)
    {
        try
        {
            var items = await _database.Razas
                .Where(u =>
                    (u.Nombre )
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(u => u.ToResponse())
                .ToListAsync();
            return new Result<List<RazaResponse>>()
            {
                Mensaje = "Ok",
                Exitoso = true,
                Datos = items
            };
        }
        catch (Exception E)
        {
            return new Result<List<RazaResponse>>
            {
                Mensaje = E.Message,
                Exitoso = false
            };
        }
    }
    #endregion
}

public interface IRazaServices
{
    Task<Result<List<RazaResponse>>> Consultar(string filtro);
    Task<Result> Crear(RazaRequest request);
    Task<Result> Eliminar(RazaRequest request);
    Task<Result> Modificar(RazaRequest request);
}