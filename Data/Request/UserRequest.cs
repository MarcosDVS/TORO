namespace TORO.Data.Request;

public class UserRequest
{
    public UserRequest()
    { 
        
    }
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Clave { get; set; } = null!;
    public string Role { get; set; } = null!;

}