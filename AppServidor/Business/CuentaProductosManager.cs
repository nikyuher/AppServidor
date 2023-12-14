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
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new Exception("No puedes poner un nombre vacio");
        }

        if (ListaProductos.Any(u => u.NombreProducto == nombre))
        {
            throw new Exception("Ya existe un producto");
        }

        if (precio <= 0)
        {
            throw new Exception("No puedes poner un precio negativo.");
        }


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
                throw new Exception("No puedes dejar el nombre vacío.");
            }
        }
        else
        {
            throw new InvalidOperationException("Producto no encontrado.");
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
            throw new Exception("No puedes poner numeros negativos");
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
    public List<CuentaProductos> BuscarProductos(string busqueda)
    {
        if (string.IsNullOrWhiteSpace(busqueda))
        {
            throw new ArgumentException("No puedes poner Busqueda vacia.");
        }

        var resultados = ListaProductos
            .Where(producto => producto.NombreProducto?.StartsWith(busqueda, StringComparison.OrdinalIgnoreCase) ?? false)
            .ToList();

        return resultados;
    }

    public string ResultadosProducto(List<CuentaProductos> resultados)
    {
        var history = new StringBuilder();

        if (resultados.Any())
        {
            history.AppendLine("Resultado de la búsqueda:");
            history.AppendLine("Producto\t\tPrecio");

            foreach (var item in resultados)
            {
                history.AppendLine($"{item.NombreProducto}\t\t$ {item.PrecioProducto}\n");
            }
        }
        else
        {
            throw new Exception("No se encontraron resultados de la búsqueda.");
        }

        return history.ToString();
    }

}