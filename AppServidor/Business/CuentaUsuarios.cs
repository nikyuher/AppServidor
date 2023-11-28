namespace Business;

using Data;

public class CuentaUsuarios
{
    public int IdCuenta { get; }
    public string? Cuenta { get; set; }
    protected string? Constrasena { get; set; }
    public decimal Dinero { get; set; }
    
    private static int SumadorIds = 1;

    public CuentaUsuarios()
    {
        IdCuenta = SumadorIds;
        SumadorIds++;
    }

    public CuentaUsuarios(string nombre, string contra)
    {
        Cuenta = nombre;
        Constrasena = contra;
    }

    public void IngresarDinero()
    {

    }

    public void DescontarDinero()
    {

    }
}
