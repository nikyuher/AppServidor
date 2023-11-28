namespace Business.Trabajadores;
using Data.Productos;
using Data.Cuentas;

public class CuentaTrabajadores
{
    public int IdCuenta { get; }
    public string? Cuenta { get; set; }
    protected string? Constrasena { get; set; }

    private static int SumadorIds = 1;

    public CuentaTrabajadores()
    {
        IdCuenta = SumadorIds;
        SumadorIds++;
    }

    public CuentaTrabajadores(string nombre, string contra)
    {
        Cuenta = nombre;
        Constrasena = contra;
    }
}
