namespace TORO.Data.Services;

public class Result : IResult
{
    public bool Exitoso { get; set; } = true;
    public string Mensaje { get; set; } = string.Empty;

    public static Result Success() => new Result() { Exitoso = true, Mensaje = string.Empty };
    public static Result Success(string mensaje) => new Result() { Exitoso = true, Mensaje = mensaje };
    public static Result Fail() => new Result() { Exitoso = false, Mensaje = string.Empty };
    public static Result Fail(string mensaje) => new Result() { Exitoso = false, Mensaje = mensaje };

}
 
public class Result<TData> : Result, IResult<TData>
{
    public TData? Datos { get; set; }
    public static Result<TData> Success(TData datos)=>new Result<TData>(){ Exitoso = true, Mensaje = string.Empty, Datos = datos};
    public static Result<TData> Success(TData datos,string mensaje = "")=>new Result<TData>(){ Exitoso = true, Mensaje = mensaje, Datos = datos};
    public static new Result<TData> Fail(string mensaje = "")=>new Result<TData>(){ Exitoso = false, Mensaje = mensaje};
} 

public interface IResult
{
    bool Exitoso {get; set;}
    string Mensaje {get; set;}
}

public interface IResult<TData>:IResult
{
    public TData? Datos {get; set;}
} 