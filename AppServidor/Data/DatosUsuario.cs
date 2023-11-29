namespace Data;

using System.Text.Json;
using System.IO;
using System.Collections.Generic;

public class DatosCuentas

{

    public string archivo = "RegistroUsuarios.json";

    private List<Object> ListaUsuarios;
    private JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

    public DatosCuentas()
    {
        ListaUsuarios = new List<object>();
    }

    public void CargarJSON()
    {
        try
        {
            if (File.Exists(archivo))
            {
                string? contenido = File.ReadAllText(archivo);
                ListaUsuarios = JsonSerializer.Deserialize<List<Object>>(contenido, options)  ?? new List<Object>();;
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
                string jsonString = JsonSerializer.Serialize(ListaUsuarios, options);
                File.WriteAllText(archivo, jsonString);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al Guardar Datos Usuarios al JSON: {e.Message}");
        }
    }
}
