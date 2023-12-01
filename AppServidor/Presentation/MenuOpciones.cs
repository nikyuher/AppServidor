namespace Presentation;

using System.Reflection;
using Business;

public class MenuOpciones
{

    private CuentaUsuariosManager cuentaManager = new CuentaUsuariosManager();
    private CuentaProductosManager cuentaProducto = new CuentaProductosManager();

    public string? NombreUsuario;
    public decimal DineroUsuario;

    public string? NombreProducto;

    public void MostrarMenu()
    {
        while (true)
        {
            Console.WriteLine($"Cuenta {NombreUsuario} Dinero: €{DineroUsuario}");
            Console.WriteLine("1. Crear cuenta");
            Console.WriteLine("2. Iniciar sesión");
            Console.WriteLine("3. Cerrar Sesion");
            Console.WriteLine("4. Añadir Dinero");
            Console.WriteLine("5. Restar Dinero");
            Console.WriteLine("6. Crear Producto");
            Console.WriteLine("7. Salir");

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
                    CrearProducto();
                    break;

                case 7:
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

    private void CrearProducto()
    {
        if (NombreUsuario == "ADMIN")
        {
            Console.WriteLine("Escribe el nombre del producto.");

            string? nombre = Console.ReadLine();

            Console.WriteLine("Ponle un precio al producto.");
            string? precioConvert = Console.ReadLine();
            int precio = 0;

            while (!int.TryParse(precioConvert, out precio))
            {
                Console.WriteLine("Ese no es un numero.\n");
                precioConvert = Console.ReadLine();
            }

            if (precio > 0)
            {
                cuentaProducto.CrearProducto(nombre, precio);

            }
            else
            {
                Console.WriteLine("No puede ponerle Precios Negativos\n");
            }
        }
        else
        {
            Console.WriteLine("Esta no es una cuenta ADMIN\n");
        }
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
            Console.WriteLine("Cuanto dinero quieres agregar\n");
            string? convert = Console.ReadLine();

            int dinero = 0;

            while (!int.TryParse(convert, out dinero))
            {
                Console.WriteLine("Ese no es un numero.\n");
                convert = Console.ReadLine();
            }

            try
            {
                cuentaManager.AgregarDinero(NombreUsuario, dinero);
            }
            catch (Exception)
            {
                Console.WriteLine("No se puede añadir negativos\n");
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

            try
            {
                Console.WriteLine("Escribe el nombre del producto");

                string? producto = Console.ReadLine();

                NombreProducto = producto;

                cuentaManager.RestarDinero(NombreUsuario, NombreProducto);
            }
            catch (Exception)
            {
                Console.WriteLine("No se encontro el Producto\n");
            }
        }
        else
        {
            Console.WriteLine("No has iniciado sesion.\n");
        }
    }
}
