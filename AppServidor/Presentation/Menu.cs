namespace Presentation.Menu;

using Presentation.Gestor;

class MenuUsuario : GestorOpciones
{

    public string MenuGeneral()
    {
        Console.WriteLine("1) Crear cuenta");
        Console.WriteLine("2) Iniciar Seion");
        Console.WriteLine("3) Lista de Productos");
        Console.WriteLine("0) Cerrar Programa");

        string? option = Console.ReadLine();

        return option ?? "";
    }

    public string MenuTrabajador()
    {

        Console.WriteLine($"Cuenta Trabajador : {NombreTrabajador}");
        Console.WriteLine("1) Anadir Producto");
        Console.WriteLine("2) Modificar Producto");
        Console.WriteLine("3) Eliminar Producto");

        string? opcion = Console.ReadLine();

        return opcion ?? "";
    }

    public string MenuBasicasUsuario()
    {
        Console.WriteLine($"Cuenta de :{NombreUsuario} Dinero:{DineroUsuario}");
        Console.WriteLine("1) Opciones de Cuenta");
        Console.WriteLine("2) Carrito");
        Console.WriteLine("3) Lista de Productos");
        Console.WriteLine("0) Cerrar Programa");

        string? opcion = Console.ReadLine();

        return opcion ?? "";
    }

    public string MenuAvanzadasUsuario()
    {
        Console.WriteLine($"Cuenta de :{NombreUsuario} Dinero:{DineroUsuario}");
        Console.WriteLine("1) Cambiar Nombre");
        Console.WriteLine("2) Cambiar Contraseña");
        Console.WriteLine("3) AgragarDinero");
        Console.WriteLine("4) Historial Cuenta");
        Console.WriteLine("5) Cerrar Sesion");
        Console.WriteLine("6) Eliminar Cuenta");

        string? opcion = Console.ReadLine();
        return opcion ?? "";
    }
}