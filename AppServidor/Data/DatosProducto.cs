namespace Data;

using System.Text.Json;
using System.IO;
using System.Collections.Generic;

public class DatosProducto
{
    // //Funciona para manera Local sin ser Usado en Docker
    // private string archivo = "../Data/dataProducto.json";

    //Sirve para docker
    private string archivo = Path.Combine("Data", "dataProducto.json");

    public void SaveJson<T>(List<T> lista)
    {
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        string jsonString = JsonSerializer.Serialize(lista, options);
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
