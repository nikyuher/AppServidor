namespace Presentation;

using Business;

public class MenuOpciones
{

    private CuentaUsuariosManager cuentaManager = new CuentaUsuariosManager();

    public string? NombreUsuario;
    public string? NombreTrabajador;
    public decimal DineroUsuario;


    public void MostrarMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Crear cuenta");
            Console.WriteLine("2. Iniciar sesión");
            Console.WriteLine("3. Cerrar Sesion");
            Console.WriteLine("4. Añadir Dinero");
            Console.WriteLine("5. Salir");

            string? opcion = Console.ReadLine();
            int devolver = 0;

            while (!int.TryParse(opcion, out devolver))
            {
                Console.WriteLine("Ese no es un numero");
                opcion = Console.ReadLine();
            }

            switch (devolver)
            {
                case 1:
                    CrearCuenta();
                    break;

                case 2:
                    IniciarSesion();
                    break;

                case 3:
                    CerrarSesion();
                    break;

                case 4:
                    AnadirDinero();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    private void CrearCuenta()
    {
        Console.Write("Ingrese nombre de usuario: ");
        string? nombre = Console.ReadLine();

        Console.Write("Ingrese contraseña: ");
        string? contraseña = Console.ReadLine();

        cuentaManager.CrearCuenta(nombre, contraseña);

        Console.WriteLine("Cuenta creada exitosamente.");
    }

    private void IniciarSesion()
    {
        Console.Write("Ingrese nombre de usuario: ");
        string? nombre = Console.ReadLine();

        Console.Write("Ingrese contraseña: ");
        string? contraseña = Console.ReadLine();

        if (cuentaManager.IniciarSesion(nombre, contraseña))
        {

            NombreUsuario = nombre;
            Console.WriteLine("Inicio de sesión exitoso.");
        }
        else
        {
            Console.WriteLine("Inicio de sesión fallido");
        }
    }

    private void AnadirDinero()
    {

        if (NombreUsuario != null)
        {
            Console.WriteLine("Cuanto dinero quieres agregar");
            string? dinero = Console.ReadLine();

            int devolver = 0;

            while (!int.TryParse(dinero, out devolver))
            {
                Console.WriteLine("Ese no es un numero");
                dinero = Console.ReadLine();
            }

            cuentaManager.AgregarDinero(NombreUsuario, devolver);
        }
        else
        {
            Console.WriteLine("No has iniciado sesion.\n");
        }
    }

    public void CerrarSesion()
    {
        NombreUsuario = null;
        Console.WriteLine("Sesion Cerrada Correctamente \n");
    }

    private void ListaProductos()
    {

    }
}
