using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TORO.Data.Request;
using TORO.Data.Response;

namespace TORO.Data.Model;

public class Raza
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = "";

    public static Raza Crear(RazaRequest item) => new()
    {
        Nombre = item.Nombre
    };
    public bool Modificar(RazaRequest item)
    {
        var cambio = false;
        if (Nombre != item.Nombre) Nombre = item.Nombre; cambio = true;

        return cambio;
    }
    public RazaResponse ToResponse() => new()
    {
        Id = Id,
        Nombre = Nombre
    };
}