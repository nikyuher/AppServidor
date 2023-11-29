namespace Business;

using Data;
using System.Text;
using System.Runtime;
using System.Collections.Generic;

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
        CuentaUsuarios nuevaCuenta = new CuentaUsuarios { Nombre = nombre, Contrasena = contraseña };

        ListaUsuarios.Add(nuevaCuenta);
        datosUsuarios.SaveJson(ListaUsuarios);
    }

    public bool IniciarSesion(string? nombre, string? contraseña)
    {
        CuentaUsuarios? encontrarUsuario = ListaUsuarios.Find(u => u.Nombre == nombre && u.Contrasena == contraseña);

        if (encontrarUsuario != null)
        {
            return true;
        }
        return false;
    }

    public void AgregarDinero(string? nombre, decimal dinero)
    {
        CuentaUsuarios? añadirDinero = ListaUsuarios.Find(u => u.Nombre == nombre);

        if (añadirDinero != null)
        {
            añadirDinero.Dinero += dinero;
            datosUsuarios.SaveJson(ListaUsuarios);
        }
    }

    public void HistorialCuenta(string? nombre)
    {
        var history = new StringBuilder();

        
    }

}