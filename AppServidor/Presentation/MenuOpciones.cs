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
            Console.WriteLine("5. Restar Dinero");
            Console.WriteLine("6. Salir");

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
                    RestarDinero();
                    break;

                case 6:
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

        Console.WriteLine("Cuenta creada exitosamente.\n");
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
            Console.WriteLine("Inicio de sesión exitoso.\n");
        }
        else
        {
            Console.WriteLine("Inicio de sesión fallido.\n");
        }
    }

    public void CerrarSesion()
    {
        NombreUsuario = null;
        Console.WriteLine("Sesion Cerrada Correctamente \n");
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
                Console.WriteLine("Ese no es un numero.\n");
                dinero = Console.ReadLine();
            }

            try
            {
                cuentaManager.AgregarDinero(NombreUsuario, devolver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        else
        {
            Console.WriteLine("No has iniciado sesion.\n");
        }
    }

    private void RestarDinero()
    {

        if (NombreUsuario != null)
        {
            Console.WriteLine("Cuanto dinero quieres Restar");
            string? dinero = Console.ReadLine();

            int devolver = 0;

            while (!int.TryParse(dinero, out devolver))
            {
                Console.WriteLine("Ese no es un numero.\n");
                dinero = Console.ReadLine();
            }

            try
            {
                cuentaManager.RestarDinero(NombreUsuario, devolver);
            }
            catch (Exception)
            {
                Console.WriteLine("No se puede Restar Negativos\n");
            }
        }
        else
        {
            Console.WriteLine("No has iniciado sesion.\n");
        }
    }

    private void ListaProductos()
    {

    }
}
