using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TORO.Data.Request;
using TORO.Data.Response;

namespace TORO.Data.Model;

public class Animal
{
    [Key]
    public int Id { get; set; }
    public string Arete { get; set; } = null!;
    public string Raza { get; set; } = null!;
    public string Sexo { get; set; } = null!;
    [Column(TypeName ="decimal(18,2)")]
    public decimal CostoCompra { get; set; }
    public DateTime FechaNacimiento { get; set; } = DateTime.Now;
    public DateTime FechaMuerte { get; set; } = DateTime.Now;
    public bool Muerto { get; set; } = false;
    public bool Vendido { get; set; } = false;

    public static Animal Crear(AnimalRequest item) => new()
    {
        Arete = item.Arete,
        Raza = item.Raza,
        Sexo = item.Sexo,
        CostoCompra = item.CostoCompra,
        FechaNacimiento = item.FechaNacimiento,
        Muerto = item.Muerto,
        FechaMuerte = item.FechaMuerte,
        Vendido = item.Vendido
    };
    public bool Modificar(AnimalRequest user)
    {
        var cambio = false;
        if (Arete != user.Arete) Arete = user.Arete; cambio = true;
        if (Raza != user.Raza) Raza = user.Raza; cambio = true;
        if (Sexo != user.Sexo) Sexo = user.Sexo; cambio = true;
        if (CostoCompra != user.CostoCompra) CostoCompra = user.CostoCompra; cambio = true;
        if (FechaNacimiento != user.FechaNacimiento) FechaNacimiento = user.FechaNacimiento; cambio = true;
        if (FechaMuerte != user.FechaMuerte) FechaMuerte = user.FechaMuerte; cambio = true;

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
        Muerto = Muerto,
        FechaMuerte = FechaMuerte,
        Vendido = Vendido
    };
}