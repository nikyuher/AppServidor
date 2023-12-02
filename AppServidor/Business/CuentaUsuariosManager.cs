namespace Business;

using Data;
using System.Text;
using System.Collections.Generic;
using System.Configuration.Assemblies;

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
    }

    public string HistorialCuenta(string? nombre)
    {

        var usuario = ListaUsuarios.Find(u => u.Nombre == nombre);

        var history = new StringBuilder();


        if (usuario != null)
        {
            history.AppendLine("Fecha\t\tDinero\tPrecio\tProducto\n");

            foreach (var item in usuario.HistorialCompra)
            {
                usuario.Dinero += item.PrecioCopia;
                history.AppendLine($"{item.FechaCopia.ToShortDateString()}\t${usuario.Dinero}\t-$ {item.PrecioCopia}\t{item.NombreCopia}");
            }
        }

        return history.ToString();

    }

}