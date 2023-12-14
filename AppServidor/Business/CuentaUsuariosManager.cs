namespace Business;

using Data;
using System.Text;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Text.RegularExpressions;
using Spectre.Console;

public class CuentaUsuariosManager
{
    private DatosUsuarios datosUsuarios = new DatosUsuarios();

    private List<CuentaUsuarios> ListaUsuarios = new List<CuentaUsuarios>();

    public CuentaUsuariosManager()
    {
        ListaUsuarios = datosUsuarios.LoadJson<CuentaUsuarios>();
    }


    public void CrearCuenta(string? nombre, string? contraseña)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new Exception("No puedes poner un nombre vacío");

        if (ListaUsuarios.Any(u => u.Nombre == nombre))
            throw new Exception("Este nombre ya está en uso.");

        if (string.IsNullOrWhiteSpace(contraseña))
            throw new Exception("No puedes contraseña vacía");

        if (ListaUsuarios.Any(u => u.Contrasena == contraseña))
            throw new Exception("Esta contraseña ya está en uso.");

        Match matchNumero = Regex.Match(contraseña, @"\d");
        Match matchMayusculas = Regex.Match(contraseña, @"[A-Z]");
        Match matchMinuscula = Regex.Match(contraseña, @"[a-z]");

        if (!matchMayusculas.Success)
            throw new Exception("No contiene Mayusculas.");

        if (!matchMinuscula.Success)
            throw new Exception("No contiene Minusculas.");

        if (!matchNumero.Success)
            throw new Exception("No contiene Numeros.");

        var nuevaCuenta = new CuentaUsuarios { Nombre = nombre, Contrasena = contraseña };

        ListaUsuarios.Add(nuevaCuenta);
        datosUsuarios.SaveJson(ListaUsuarios);
    }

    public bool IniciarSesion(string? nombre, string? contraseña)
    {
        var encontrarUsuario = ListaUsuarios.Find(u => u.Nombre == nombre && u.Contrasena == contraseña);

        if (encontrarUsuario != null)
        {
            return true;
        }
        return false;
    }

    public decimal ObtenerDineroUsuario(string? nombre)
    {
        var usuario = ListaUsuarios.Find(u => u.Nombre == nombre);
        decimal Dinero = 0;
        if (usuario != null)
        {
            Dinero = usuario.Dinero;

            return Dinero;
        }
        return Dinero;
    }

    public void AgregarDinero(string? nombre, decimal dinero)
    {
        var usuario = ListaUsuarios.Find(u => u.Nombre == nombre);

        if (dinero <= 0)
        {
            throw new Exception("No puedes agregar numero Negativos");
        }

        if (usuario != null)
        {
            usuario.Dinero += dinero;
            datosUsuarios.SaveJson(ListaUsuarios);
        }
        else
        {
            throw new Exception("No se encontro al usuario");
        }
    }

    public void RestarDinero(string? nombre, string? producto)
    {
        var mgProducto = new CuentaProductosManager();

        var Usuario = ListaUsuarios.Find(u => u.Nombre == nombre);

        var Producto = mgProducto.ListaProductos.Find(u => u.NombreProducto == producto);

        if (Usuario != null && Producto != null)
        {
            if (Usuario.Dinero - Producto.PrecioProducto < 0)
            {
                throw new InvalidOperationException("Dinero Insuficiente en tu Cuenta");
            }
            else
            {
                var copia = new ProductoCopia(Producto.NombreProducto, Producto.PrecioProducto, DateTime.Now);

                Usuario.Dinero -= Producto.PrecioProducto;
                Usuario.HistorialCompra.Add(copia);

                datosUsuarios.SaveJson(ListaUsuarios);
            }
        }
        else
        {
            throw new Exception("Producto no Encontrado");
        }
    }

    public void ModificarNombre(string? cuenta, string? nuevoNombre)
    {
        if (!string.IsNullOrWhiteSpace(nuevoNombre))
        {
            var usuario = ListaUsuarios.Find(u => u.Nombre == cuenta);

            if (usuario != null)
            {
                usuario.Nombre = nuevoNombre;
                datosUsuarios.SaveJson(ListaUsuarios);
            }
        }
        else
        {
            throw new Exception("No puedes poner un nombre vacío.");
        }
    }

    public void ModificarContraseña(string? cuenta, string? nuevContrasena)
    {
        if (!string.IsNullOrWhiteSpace(nuevContrasena))
        {
            var usuario = ListaUsuarios.Find(u => u.Nombre == cuenta);

            if (usuario != null)
            {
                usuario.Contrasena = nuevContrasena;
                datosUsuarios.SaveJson(ListaUsuarios);
            }
        }
        else
        {
            throw new Exception("No puedes poner una contrasena vacia");
        }
    }

    public void EliminarCuenta(string? cuenta)
    {
        var Usuario = ListaUsuarios.Find(u => u.Nombre == cuenta);

        if (Usuario != null)
        {
            ListaUsuarios.Remove(Usuario);
            datosUsuarios.SaveJson(ListaUsuarios);
        }
        else
        {
            throw new Exception("No se encontro al Usuario");
        }
    }

    public string HistorialCuenta(string? nombre)
    {
        var usuario = ListaUsuarios.Find(u => u.Nombre == nombre);
        var table = new Table();

        if (usuario != null)
        {
            table.AddColumn("[u]Fecha[/]");
            table.AddColumn("[u]Dinero[/]");
            table.AddColumn("[u]Precio[/]");
            table.AddColumn("[u]Producto[/]");

            foreach (var item in usuario.HistorialCompra)
            {
                usuario.Dinero += item.PrecioCopia;
                table.AddRow(
                    $"{item.FechaCopia.ToShortDateString()}",
                    $"${usuario.Dinero}",
                    $"-$ {item.PrecioCopia}",
                    $"{item.NombreCopia}"
                );
            }

            AnsiConsole.Write(table);
        }

        return "";
    }


    public string AlmacenUsuarios()
    {
        var table = new Table();

        table.AddColumn("[u]Usuarios[/]");
        table.AddColumn("[u]Contraseñas[/]");
        table.AddColumn("[u]Dinero[/]");

        foreach (var item in ListaUsuarios)
        {
            table.AddRow($"{item.Nombre}", $"{item.Contrasena}", item.Dinero.ToString());
        }

        AnsiConsole.Write(table);

        return "";
    }


    public List<CuentaUsuarios> BuscarUsuarios(string busqueda)
    {
        if (string.IsNullOrWhiteSpace(busqueda))
        {
            throw new ArgumentException("No puedes poner Busqueda vacia.");
        }

        var resultados = ListaUsuarios
            .Where(nombre => nombre.Nombre?.StartsWith(busqueda, StringComparison.OrdinalIgnoreCase) ?? false)
            .ToList();

        return resultados;
    }

    public string ResultadosUsuario(List<CuentaUsuarios> resultados)
    {
        var table = new Table();

        if (resultados.Any())
        {
            table.AddColumn("[u]Usuarios[/]");
            table.AddColumn("[u]Contraseñas[/]");
            table.AddColumn("[u]Dinero[/]");

            foreach (var item in resultados)
            {
                table.AddRow($"{item.Nombre}", $"{item.Contrasena}", item.Dinero.ToString());
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