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
        var añadirDinero = ListaUsuarios.Find(u => u.Nombre == nombre);

        decimal Dinero = añadirDinero.Dinero;

        return Dinero;
    }

    public void AgregarDinero(string? nombre, decimal dinero)
    {
        var añadirDinero = ListaUsuarios.Find(u => u.Nombre == nombre);

        if (dinero <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(dinero), "No puedes agregar numero Negativos");
        }

        if (añadirDinero != null)
        {
            añadirDinero.Dinero += dinero;
            datosUsuarios.SaveJson(ListaUsuarios);
        }
    }

    public void RestarDinero(string? nombre, string? producto)
    {
        var mgProducto = new CuentaProductosManager();

        var Usuario = ListaUsuarios.Find(u => u.Nombre == nombre);

        var Producto = mgProducto.ListaProductos.Find(u => u.NombreProducto == producto);

        if (Usuario != null)
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
    }

    public void ModificarNombre()
    {

    }

    public void ModificarContraseña()
    {

    }

    public void EliminarCuenta()
    {

    }

    public string HistorialCuenta(string? nombre)
    {

        var usuario = ListaUsuarios.Find(u => u.Nombre == nombre);

        var history = new StringBuilder();


        history.AppendLine("Fecha\t\tDinero\tPrecio\tProducto\n");

        foreach (var item in usuario.HistorialCompra)
        {
            usuario.Dinero += item.PrecioCopia;
            history.AppendLine($"{item.FechaCopia.ToShortDateString()}\t${usuario.Dinero}\t-$ {item.PrecioCopia}\t{item.NombreCopia}");
        }

        return history.ToString();

    }

}