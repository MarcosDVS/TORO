using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TORO.Data.Request;
using TORO.Data.Response;

namespace TORO.Data.Model;

public class Animal
{
    [Key]
    public int Id { get; set; }
    public string Arete { get; set; } ="";
    public string Raza { get; set; } = null!;
    public string Sexo { get; set; } = "";
    [Column(TypeName ="decimal(18,2)")]
    public decimal CostoCompra { get; set; }
    public DateTime FechaNacimiento { get; set; } = DateTime.Now;
    public bool Vendido { get; set; } = false;

    public static Animal Crear(AnimalRequest item) => new()
    {
        Arete = item.Arete,
        Raza = item.Raza,
        Sexo = item.Sexo,
        CostoCompra = item.CostoCompra,
        FechaNacimiento = item.FechaNacimiento,
        Vendido = item.Vendido
    };
    public bool Modificar(AnimalRequest item)
    {
        var cambio = false;
        if (Arete != item.Arete) Arete = item.Arete; cambio = true;
        if (Raza != item.Raza) Raza = item.Raza; cambio = true;
        if (Sexo != item.Sexo) Sexo = item.Sexo; cambio = true;
        if (CostoCompra != item.CostoCompra) CostoCompra = item.CostoCompra; cambio = true;
        if (FechaNacimiento != item.FechaNacimiento) FechaNacimiento = item.FechaNacimiento; cambio = true;

        return cambio;
    }
 
    public AnimalResponse ToResponse() => new()
    {
        Id = Id,
        Arete = Arete,
        Raza = Raza,
        Sexo = Sexo,
        CostoCompra = CostoCompra,
        FechaNacimiento = FechaNacimiento,
        Vendido = Vendido
    };
}