namespace Presentation;

public class MenuDiseño : MenuOpciones
{

    public int MenuGeneral()
    {
        Console.WriteLine("1. Iniciar Sesion");
        Console.WriteLine("2. Crea tu Cuenta");
        Console.WriteLine("3. Lista de Productos");
        Console.WriteLine("0. Cerrar Programa");

        string? opcion = Console.ReadLine();

        int Devolver = 0;

        while (!int.TryParse(opcion, out Devolver))
        {
            Console.WriteLine("Ese no es un numero");
            opcion = Console.ReadLine();
        }

        return Devolver;
    }

    public int MenuTrabajador()
    {

        Console.WriteLine($"Cuenta Trabajador : {NombreUsuario}");
        Console.WriteLine("1. Anadir Producto");
        Console.WriteLine("2. Modificar Producto");
        Console.WriteLine("3. Eliminar Producto");

        string? opcion = Console.ReadLine();

        int Devolver = 0;

        while (!int.TryParse(opcion, out Devolver))
        {
            Console.WriteLine("Ese no es un numero");
            opcion = Console.ReadLine();
        }

        return Devolver;
    }

    public int MenuBasicoUsuario()
    {
        Console.WriteLine($"Cuenta de :{NombreUsuario} Dinero:{DineroUsuario}");
        Console.WriteLine("1. Opciones de Cuenta");
        Console.WriteLine("2. Lista de Productos");
        Console.WriteLine("0. Cerrar Programa");

        string? opcion = Console.ReadLine();

        int Devolver = 0;

        while (!int.TryParse(opcion, out Devolver))
        {
            Console.WriteLine("Ese no es un numero");
            opcion = Console.ReadLine();
        }

        return Devolver;
    }

    public int MenuAvanzadasUsuario()
    {
        Console.WriteLine($"Cuenta de :{NombreUsuario} Dinero:{DineroUsuario}");
        Console.WriteLine("1. Cambiar Nombre");
        Console.WriteLine("2. Cambiar Contraseña");
        Console.WriteLine("3. Agregar Dinero");
        Console.WriteLine("4. Historial Cuenta");
        Console.WriteLine("5. Cerrar Sesion");
        Console.WriteLine("6. Eliminar Cuenta");

        string? opcion = Console.ReadLine();

        int Devolver = 0;

        while (!int.TryParse(opcion, out Devolver))
        {
            Console.WriteLine("Ese no es un numero");
            opcion = Console.ReadLine();
        }

        return Devolver;
    }
}