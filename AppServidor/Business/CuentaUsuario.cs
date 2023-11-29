namespace Business;

using Data;

public class CuentaUsuarios
{
    public int IdCuenta { get; }
    public string? Nombre { get; set; }
    public string? Contrasena { get; set; }
    public decimal Dinero { get; set; }

    private static int SumadorIds = 1;

    public CuentaUsuarios()
    {
        IdCuenta = SumadorIds;
        SumadorIds++;
    }

}
