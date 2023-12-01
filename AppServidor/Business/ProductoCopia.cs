namespace Business;

public class ProductoCopia
{


    public string? NombreCopia { get; set; }
    public decimal PrecioCopia { get; set; }

    public DateTime FechaCopia { get; set; }

    public ProductoCopia()
    {

    }

    public ProductoCopia(string? nombre, decimal precio, DateTime fecha)
    {
        NombreCopia = nombre;
        PrecioCopia = precio;
        FechaCopia = fecha;
    }

}