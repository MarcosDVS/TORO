using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TORO.Data.Request;
using TORO.Data.Response;

namespace TORO.Data.Model;
// Primer paso para crear la base de datos Sqlite es crear un modelo, request y response de tus tablas.

// Segundo es instalar los paketes nugest Microsoft.EntityFrameWork, Microsoft.EntityFrameWork.Sqlite,
//System.Net.Http.Json Nota estos paketes ya estan instalados luego crea las funciones Crear, 
//Modificar y ToResponse dentro de los modelos y dentro de los Response crea la funcion ToRequest.

// Tercer paso crea una carpeta llamada Context dentro de la carpeta Data en la carpeta Context crea
//un archivo llamado MyDbContext.cs

// Cuarto paso dirijete al archivo Program.cs y crea la Configuracion de la base de datos SQLite
public class Gasto
{
    #region Propiedades
    [Key]
    public int Id { get; set; }
    public string Detalle { get; set; } = null!;
    public int Cantidad { get; set; }
    [Column(TypeName ="decimal(18,2)")]
    public decimal Costo { get; set; }
    [Column(TypeName ="decimal(18,2)")]
    public decimal CostoTotal { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    #endregion
    

    #region Funciones
    public static Gasto Crear(GastoRequest user) => new()
    {
        Detalle = user.Detalle,
        Cantidad = user.Cantidad,
        Costo = user.Costo,
        CostoTotal = user.CostoTotal,
        Fecha = user.Fecha
    };
    public bool Modificar(GastoRequest user)
    {
        var cambio = false;
        if (Detalle != user.Detalle) Detalle = user.Detalle; cambio = true;
        if (Cantidad != user.Cantidad) Cantidad = user.Cantidad; cambio = true;
        if (Costo != user.Costo) Costo = user.Costo; cambio = true;
        if (CostoTotal != user.CostoTotal) CostoTotal = user.CostoTotal; cambio = true;
        if (Fecha != user.Fecha) Fecha = user.Fecha; cambio = true;

        return cambio;
    }
    public GastoResponse ToResponse() => new()
    {
        Id = Id,
        Detalle = Detalle,
        Cantidad = Cantidad,
        Costo = Costo,
        CostoTotal = CostoTotal,
        Fecha = Fecha
    };
    #endregion
}