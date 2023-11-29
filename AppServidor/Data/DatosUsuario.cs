namespace Data;

using System.Text.Json;
using System.IO;
using System.Collections.Generic;

public class DatosUsuarios
{
    private string archivo = "../Data/dataUsuarios.json";
    private JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

    public void SaveJson<T>(List<T> listaUsuariosDTO)
    {
        string jsonString = JsonSerializer.Serialize(listaUsuariosDTO,options);
        File.WriteAllText(archivo, jsonString);
    }

    public List<T> LoadJson<T>()
    {
        if (File.Exists(archivo))
        {
            string contenido = File.ReadAllText(archivo);
            return JsonSerializer.Deserialize<List<T>>(contenido) ?? new List<T>();
        }
        return new List<T>();
    }
}
