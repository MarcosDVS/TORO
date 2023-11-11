using TORO.Data.Request;

namespace TORO.Data.Response;

public class RazaResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public RazaRequest ToRequest()
    {
        return new RazaRequest
        {
            Id = Id,
            Nombre = Nombre
        };
    }
}