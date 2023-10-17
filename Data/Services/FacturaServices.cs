using System;
using Microsoft.EntityFrameworkCore;
using TORO.Data.Context;
using TORO.Data.Model;
using TORO.Data.Request;
using TORO.Data.Response;

namespace TORO.Data.Services;
    public class FacturaServices : IFacturaServices
    {
        private readonly IMyDbContext dbContext;

    public FacturaServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<Result<List<FacturaRespose>>> Consultar()
    {
        try
        {
            var facturas = await dbContext.Facturas
                .Include(f => f.Detalles)
                .ThenInclude(d => d.Animal)
                .Select(f => f.ToResponse())
                .ToListAsync();
            return new Result<List<FacturaRespose>>()
            {
                Datos = facturas,
                Exitoso = true,
                Mensaje = "Ok"
            };
        }
        catch (Exception E)
        {
            return new Result<List<FacturaRespose>>()
            {
                Datos = null,
                Exitoso = false,
                Mensaje = E.Message
            };
        }
    }

    public async Task<Result<FacturaRespose>> Crear(FacturaRequest request)
    {
        try
        {
            var factura = Factura.Crear(request);
            dbContext.Facturas.Add(factura);
            await dbContext.SaveChangesAsync();
            return new Result<FacturaRespose>()
            {
                Datos = factura.ToResponse(),
                Exitoso = true,
                Mensaje = "Ok"
            };
        }
        catch (Exception E)
        {
            return new Result<FacturaRespose>()
            {
                Datos = null,
                Exitoso = false,
                Mensaje = E.Message
            };
        }
    }
    public async Task<Result> Eliminar(FacturaRequest request)
    {
        try
        {
            var contacto = await dbContext.Facturas
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (contacto == null)
                return new Result() { Mensaje = "No se encontro el usuario", Exitoso = false };

            dbContext.Facturas.Remove(contacto);
            await dbContext.SaveChangesAsync();
            return new Result() { Mensaje = "Ok", Exitoso = true };
        }
        catch (Exception E)
        {

            return new Result() { Mensaje = E.Message, Exitoso = false };
        }
    }
}

    public interface IFacturaServices
    {
        Task<Result<List<FacturaRespose>>> Consultar();
        Task<Result<FacturaRespose>> Crear(FacturaRequest request);
         Task<Result> Eliminar(FacturaRequest request);
    }
