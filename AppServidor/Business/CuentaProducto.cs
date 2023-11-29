namespace Business;

using Data;
public class CuentaProductos
{
    public int idProducto { get; set; }
    public string? NombreProducto { get; set; }
    public decimal PrecioProducto { get; set; }

    private static int SumadorIds = 1;

    public CuentaProductos()
    {

        idProducto = SumadorIds;
        SumadorIds++;

    }
}