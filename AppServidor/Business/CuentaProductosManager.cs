namespace Business;

using Data;
using System.Text;
using System.Collections.Generic;

public class CuentaProductosManager
{
    private DatosProducto datosProducto = new DatosProducto();

    public List<CuentaProductos> ListaProductos = new List<CuentaProductos>();


    public CuentaProductosManager()
    {
        ListaProductos = datosProducto.LoadJson<CuentaProductos>();
    }


    public void CrearProducto(string? nombre, decimal precio)
    {
        CuentaProductos nuevaProducto = new CuentaProductos { NombreProducto = nombre, PrecioProducto = precio, Fecha = DateTime.Now };

        ListaProductos.Add(nuevaProducto);
        datosProducto.SaveJson(ListaProductos);
    }

    public string AlmacenProductos()
    {

        var history = new StringBuilder();


        history.AppendLine("Nombre\t\tPrecio");

        foreach (var item in ListaProductos)
        {
            history.AppendLine($"{item.NombreProducto}\t\t$ {item.PrecioProducto}");
        }

        return history.ToString();

    }
}