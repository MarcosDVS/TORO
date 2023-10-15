using Microsoft.EntityFrameworkCore;
using TORO.Data.Context;
using TORO.Data.Model;
using TORO.Data.Request;
using TORO.Data.Response;

namespace TORO.Data.Services;
// Para crear los servicios es generar un constructor con un mienbro privado de solo lectura
//y crear las funciones del servicio en la clase publica luego crea la interfas
//ahora ve al Program.cs e inserta los servicios de la sigte forma 
//builder.Services.AddScoped<IGastoServices,GastoServices>();
//luego inserta los mismos servicios en el archivo _Import.razor de la sigte forma
//@inject IGastoServices gastoServices;

// Una vez ya hallas terminado con los Servicios ya puedes empezar a trabajar la parte visual
//del proyecto en la carpeta Pages.
public class GastoServices : IGastoServices
{
    #region Constructor y mienbro privado
    private MyDbContext _database;

    public GastoServices(MyDbContext database)
    {
        _database = database;
    }
    #endregion
    #region Funciones
    public async Task<Result> Crear(GastoRequest request)
    {
        try
        {
            var contacto = Gasto.Crear(request);
            contacto.CostoTotal = contacto.Cantidad * contacto.Costo;
            _database.Gastos.Add(contacto);
            await _database.SaveChangesAsync();
            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    public async Task<Result> Modificar(GastoRequest request)
    {
        try
        {
            var user = await _database.Gastos
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (user == null)
                return new Result() { Mensaje = "No se encontro el gasto", Exitoso = false };

            if (user.Modificar(request))
                user.CostoTotal = user.Cantidad * user.Costo;
                await _database.SaveChangesAsync();

            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    public async Task<Result> Eliminar(GastoRequest request)
    {
        try
        {
            var contacto = await _database.Gastos
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Mensaje = "No se encontro el usuario", Exitoso = false };

            _database.Gastos.Remove(contacto);
            await _database.SaveChangesAsync();
            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
    public async Task<Result<List<GastoResponse>>> Consultar(string filtro)
    {
        try
        {
            var usuarios = await _database.Gastos
                .Where(u =>
                    (u.Detalle + " "+ u.Cantidad+" "+ u.Costo + " "+ u.CostoTotal+" "+ u.Fecha)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                )
                .Select(u => u.ToResponse())
                .ToListAsync();
            return new Result<List<GastoResponse>>()
            {
                Mensaje = "Ok",
                Exitoso = true,
                Datos = usuarios
            };
        }
        catch (Exception E)
        {
            return new Result<List<GastoResponse>>
            {
                Mensaje = E.Message,
                Exitoso = false
            };
        }
    }
    #endregion
}

public interface IGastoServices
{
    Task<Result<List<GastoResponse>>> Consultar(string filtro);
    Task<Result> Crear(GastoRequest request);
    Task<Result> Eliminar(GastoRequest request);
    Task<Result> Modificar(GastoRequest request);
}