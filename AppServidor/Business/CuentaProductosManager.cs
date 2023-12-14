namespace Business;

using Data;
using System.Text;
using System.Collections.Generic;
using Spectre.Console;

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
        var table = new Table();

        table.AddColumn("[u]Producto[/]");
        table.AddColumn("[u]Precio[/]");

        foreach (var item in ListaProductos)
        {
            table.AddRow($"{item.NombreProducto}", $"$ {item.PrecioProducto}");
        }

        AnsiConsole.Write(table);

        return "";
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
        var table = new Table();

        if (resultados.Any())
        {
            table.AddColumn("[u]Producto[/]");
            table.AddColumn("[u]Precio[/]");

            foreach (var item in resultados)
            {
                table.AddRow($"{item.NombreProducto}", $"$ {item.PrecioProducto}");
            }

            AnsiConsole.Write(table);
        }
        else
        {
            throw new Exception("No se encontraron resultados de la búsqueda.");
        }

        return "";
    }


}