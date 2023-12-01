namespace Business;


public class CuentaProductos

{
    public int IdProducto { get; }
    public string? NombreProducto { get; set; }
    public decimal PrecioProducto { get; set; }

    public DateTime Fecha { get; set; }

    private static int SumadorIds = 1;


    public CuentaProductos()
    {
        IdProducto = SumadorIds;
        SumadorIds++;
    }
    
}