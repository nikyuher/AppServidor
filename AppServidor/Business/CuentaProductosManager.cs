namespace Business;

using Data;
using System.Text;
using System.Runtime;
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
        CuentaProductos nuevaProducto = new CuentaProductos { NombreProducto = nombre, PrecioProducto = precio };

        ListaProductos.Add(nuevaProducto);
        datosProducto.SaveJson(ListaProductos);
    }


}