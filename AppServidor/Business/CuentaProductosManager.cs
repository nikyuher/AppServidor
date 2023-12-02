namespace Business;

using Data;
using System.Text;
using System.Collections.Generic;

public class CuentaProductosManager : CuentaUsuariosManager
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

    public void ModificarNombreProducto(string? nombreProducto, string? nuevoNombreProducto)
    {
        var producto = ListaProductos.Find(u => u.NombreProducto == nombreProducto);

        if (producto != null)
        {
            if (!string.IsNullOrWhiteSpace(nuevoNombreProducto))
            {
                producto.NombreProducto = nuevoNombreProducto;
                datosProducto.SaveJson(ListaProductos);
            }
            else
            {
                Console.WriteLine("\nNo puedes dejar el nombre vacío.\n");
            }
        }
        else
        {
            throw new InvalidOperationException("Producto no encontrado");
        }
    }

    public void ModificarPrecioProducto(string? producto, decimal nuevoPrecio)
    {
        if (nuevoPrecio > 0)
        {
            var Producto = ListaProductos.Find(u => u.NombreProducto == producto);

            if (Producto != null)
            {
                Producto.PrecioProducto = nuevoPrecio;
                datosProducto.SaveJson(ListaProductos);
            }
        }
        else
        {
            Console.WriteLine("\nNo puedes poner numeros negativos\n");
        }
    }

    public void EliminarProducto(string? producto)
    {
        var Producto = ListaProductos.Find(u => u.NombreProducto == producto);

        if (Producto != null)
        {
            ListaProductos.Remove(Producto);
            datosProducto.SaveJson(ListaProductos);
        }
        else
        {
            throw new InvalidOperationException("Producto no encontrado");
        }
    }

    public string AlmacenProductos()
    {

        var history = new StringBuilder();


        history.AppendLine("Producto\t\tPrecio");

        foreach (var item in ListaProductos)
        {
            history.AppendLine($"{item.NombreProducto}\t\t$ {item.PrecioProducto}\n");
        }

        return history.ToString();

    }
}