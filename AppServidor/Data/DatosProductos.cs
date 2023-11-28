namespace Data.Productos;

using System.Text.Json;
using System.IO;
using System.Collections.Generic;

public class DatosProducto

{

    public string archivo = "RegistroProdutos.json";

    public DatosProducto()
    {
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
    }

    public void CargarJSON()
    {
        try
        {
            if (File.Exists(archivo))
            {

            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al cargar Datos Productos del JSON: {e.Message}");
        }
    }

    public void GuardarJson()
    {
        try
        {
            if (File.Exists(archivo))
            {

            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al Guardar Datos Productos al JSON: {e.Message}");
        }
    }
}