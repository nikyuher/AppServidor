namespace Data;

using System.Text.Json;
using System.IO;
using System.Collections.Generic;

public class DatosCuentas

{

    public string archivo = "RegistroUsuarios.json";

    public DatosCuentas()
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
            Console.WriteLine($"Error al cargar Datos Usuarios del JSON: {e.Message}");
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
            Console.WriteLine($"Error al Guardar Datos Usuarios al JSON: {e.Message}");
        }
    }
}
