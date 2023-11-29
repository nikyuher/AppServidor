namespace Business;

using Data;

public class CuentaUsuarios
{
    public int IdCuenta { get; }
    public string? Cuenta { get; set; }
    protected string? Constrasena { get; set; }
    public decimal Dinero { get; set; }

    private DatosCuentas datosCuenta;

    private static int SumadorIds = 1;

    public CuentaUsuarios()
    {
        datosCuenta = new DatosCuentas();
        datosCuenta.CargarJSON();
        IdCuenta = SumadorIds;
        SumadorIds++;
    }

    public CuentaUsuarios(string nombre, string contra)
    {
        datosCuenta = new DatosCuentas();
        Cuenta = nombre;
        Constrasena = contra;
        Dinero = 0;
        datosCuenta.GuardarJson();
    }

    public void IngresarDinero(decimal cantidad)
    {
        if (cantidad <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad debe ser positiva");
        }

        Dinero += cantidad;
        
        datosCuenta.GuardarJson();
    }

    public void DescontarDinero(decimal cantidad)
    {
        if (cantidad <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cantidad), "Cantidad a descontar debe ser positiva");
        }
        if (Dinero - cantidad < 0)
        {
            throw new InvalidOperationException("No tienes suficientes fondos para Comprar");
        }

        Dinero -= cantidad;

        datosCuenta.GuardarJson();
    }
}
