namespace Presentation;

using Business;

public class MenuOpciones
{

    private CuentaUsuariosManager cuentaManager = new CuentaUsuariosManager();
    private CuentaProductosManager cuentaProducto = new CuentaProductosManager();

    protected string? NombreUsuario;
    protected decimal DineroUsuario;
    protected string? NombreProducto;

    public void MenuGeneral()
    {

        while (true)
        {
            Console.WriteLine("1. Iniciar sesión");
            Console.WriteLine("2. Crear cuenta");
            Console.WriteLine("3. Lista de Productos");
            Console.WriteLine("0. Salir");

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                Console.WriteLine("Ese no es un numero");
                opcion = Console.ReadLine();
            }

            switch (numOption)
            {
                case 1:
                    IniciarSesion();
                    break;

                case 2:
                    CrearCuenta();
                    break;

                case 3:
                    ListaProductos();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }


    public void MenuUsuario()
    {

        while (true)
        {
            Console.WriteLine($"Cuenta {NombreUsuario} Dinero: $ {DineroUsuario}\n");
            Console.WriteLine("1. Configuracion de Cuenta");
            Console.WriteLine("2. Lista de Productos");
            Console.WriteLine("0. Salir");

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                Console.WriteLine("Ese no es un numero");
                opcion = Console.ReadLine();
            }

            switch (numOption)
            {
                case 1:
                    MenuUsuarioAvanzado();
                    break;

                case 2:
                    ListaProductos();
                    ComprarProducto();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    public void MenuUsuarioAvanzado()
    {
        while (true)
        {
            Console.WriteLine($"Cuenta de {NombreUsuario} Dinero: $ {DineroUsuario}\n");
            Console.WriteLine("1. Cambiar Nombre");
            Console.WriteLine("2. Cambiar Contraseña");
            Console.WriteLine("3. Agregar Dinero");
            Console.WriteLine("4. Historial Cuenta");
            Console.WriteLine("5. Cerrar Sesion");
            Console.WriteLine("6. Eliminar Cuenta");
            Console.WriteLine("0. Volver atras");

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                Console.WriteLine("Ese no es un numero");
                opcion = Console.ReadLine();
            }

            switch (numOption)
            {
                case 1:
                    CambiarNombre();
                    break;

                case 2:
                    CambiarContraseña();
                    break;

                case 3:
                    AnadirDinero();
                    break;

                case 4:
                    HistorialUsuario();
                    break;

                case 5:
                    CerrarSesion();
                    break;

                case 6:
                    EliminarCuenta();
                    break;

                case 0:
                    MenuUsuario();
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }


    public void MenuAdministrador()
    {
        while (true)
        {
            Console.WriteLine("Cuenta de Administrador\n");
            Console.WriteLine("1. Administrar Usuarios");
            Console.WriteLine("2. Administrar Productos");
            Console.WriteLine("0. Salir Cuenta");

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                Console.WriteLine("Ese no es un numero\n");
                opcion = Console.ReadLine();
            }

            switch (numOption)
            {
                case 1:
                    MenurAdminUsuario();
                    break;

                case 2:
                    MenuAdminProducto();
                    break;

                case 0:
                    CerrarSesion();
                    MenuGeneral();
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    public void MenurAdminUsuario()
    {
        while (true)
        {
            Console.WriteLine("Cuenta de Administrador\n");
            Console.WriteLine("1. Lista de Usuarios");
            Console.WriteLine("2. Añadir Usuario");
            Console.WriteLine("3. Eliminar Usuario");
            Console.WriteLine("0. atras");

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                Console.WriteLine("Ese no es un numero\n");
                opcion = Console.ReadLine();
            }

            switch (numOption)
            {
                case 1:
                    ListaUsuarios();
                    break;

                case 2:
                    CrearCuenta();
                    break;

                case 3:
                    EliminarCuenta();
                    break;
                case 0:
                    MenuAdministrador();
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    public void MenuAdminProducto()
    {
        while (true)
        {
            Console.WriteLine("Cuenta de Administrador\n");
            Console.WriteLine("1. Lista de Productos");
            Console.WriteLine("2. Anadir Producto");
            Console.WriteLine("3. Modificar Producto");
            Console.WriteLine("4. Eliminar Producto");
            Console.WriteLine("0. atras");

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                Console.WriteLine("Ese no es un numero\n");
                opcion = Console.ReadLine();
            }

            switch (numOption)
            {
                case 1:
                    ListaProductos();
                    break;

                case 2:
                    CrearProducto();
                    break;

                case 3:
                    ModificarProducto();
                    break;

                case 4:
                    EliminarProducto();
                    break;
                case 0:
                    MenuAdministrador();
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }


    protected void CrearCuenta()
    {
        try
        {
            Console.WriteLine("\nCREANDO CUENTA\n");

            Console.Write("Crea un Nombre: ");
            string? nombre = Console.ReadLine();

            Console.Write("Crea una Contraseña: ");
            string? contraseña = Console.ReadLine();

            cuentaManager.CrearCuenta(nombre, contraseña);

            Console.WriteLine("\nCuenta creada exitosamente.\n");
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nOcurrio un error: {e.Message}\n");
        }
    }

    protected void CrearProducto()
    {
        if (NombreUsuario == "admin")
        {
            try
            {
                Console.WriteLine("\nAÑADIENDO PRODUCTO\n");

                Console.WriteLine("Escribe el nombre del producto.");

                string? nombre = Console.ReadLine();

                Console.WriteLine("Ponle un precio al producto.");
                string? precioConvert = Console.ReadLine();
                decimal precio = 0;

                while (!decimal.TryParse(precioConvert, out precio))
                {
                    Console.WriteLine("\nEse no es un numero.\n");
                    precioConvert = Console.ReadLine();
                }

                cuentaProducto.CrearProducto(nombre, precio);

                Console.WriteLine("\nProducto añadido exitosamente.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nOcurrio un error: {e.Message}\n");
            }

        }
        else
        {
            Console.WriteLine("\nEsta no es una cuenta ADMIN\n");
        }
    }

    protected void IniciarSesion()
    {
        Console.Write("Ingrese nombre de usuario: ");
        string? nombre = Console.ReadLine();

        Console.Write("Ingrese contraseña: ");
        string? contraseña = Console.ReadLine();

        if (cuentaManager.IniciarSesion(nombre, contraseña))
        {

            if (nombre == "admin")
            {
                NombreUsuario = nombre;
                Console.WriteLine("\nInicio de sesión exitoso.\n");
                MenuAdministrador();
            }
            else
            {
                NombreUsuario = nombre;
                DineroUsuario = cuentaManager.ObtenerDineroUsuario(NombreUsuario);

                Console.WriteLine("\nInicio de sesión exitoso.\n");

                MenuUsuario();
            }
        }
        else
        {
            Console.WriteLine("\nInicio de sesión fallido.\n");
        }
    }

    protected void CerrarSesion()
    {
        NombreUsuario = null;
        DineroUsuario = 0;

        Console.WriteLine("\nSesion Cerrada Correctamente \n");

        MenuGeneral();
    }

    protected void AnadirDinero()
    {

        if (NombreUsuario != null)
        {

            try
            {
                Console.WriteLine("Cuanto dinero quieres agregar");
                string? convert = Console.ReadLine();

                int dinero = 0;

                while (!int.TryParse(convert, out dinero))
                {
                    Console.WriteLine("\nEse no es un numero.\n");
                    convert = Console.ReadLine();
                }

                cuentaManager.AgregarDinero(NombreUsuario, dinero);
                DineroUsuario = cuentaManager.ObtenerDineroUsuario(NombreUsuario);

                Console.WriteLine("\nDinero añadido exitosamente.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nOcurrio un error: {e.Message}\n");
            }
        }
        else
        {
            Console.WriteLine("\nNo has iniciado sesion.\n");
        }
    }
    protected void CambiarNombre()
    {
        Console.WriteLine("Escrime tu nuevo nombre: ");
        string? nombreNuevo = Console.ReadLine();


        try
        {
            cuentaManager.ModificarNombre(NombreUsuario, nombreNuevo);

            NombreUsuario = nombreNuevo;

            Console.WriteLine("\nCambio de nombre exitoso.\n");
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nOcurrio un Error: {e.Message}\n");
        }
    }

    protected void CambiarContraseña()
    {
        Console.WriteLine("Escrime tu nueva Contrasena: ");
        string? nuevaContra = Console.ReadLine();

        try
        {
            cuentaManager.ModificarContraseña(NombreUsuario, nuevaContra);

            DineroUsuario = cuentaManager.ObtenerDineroUsuario(NombreUsuario);

            Console.WriteLine("\nCambio de nombre exitoso.\n");
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nOcurrio un Error: {e.Message}\n");
        }
    }

    protected void EliminarCuenta()
    {


        try
        {
            if (NombreUsuario == "admin")
            {
                Console.WriteLine("¿Que cuenta quieres Eliminar?\n");
                string? cuenta = Console.ReadLine();

                cuentaManager.EliminarCuenta(cuenta);
                Console.WriteLine("\nCuenta Eliminada exitisa.\n");
            }
            else
            {
                cuentaManager.EliminarCuenta(NombreUsuario);
                Console.WriteLine("\nCuenta Eliminada exitisa.\n");

                MenuGeneral();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nOcurrio un error: {e.Message}\n");
        }
    }

    protected void ModificarProducto()
    {
        try
        {
            Console.WriteLine("¿Que producto modificara?: ");
            string? productoViejo = Console.ReadLine();


            Console.WriteLine("Escriba el nuevo nombre: ");
            string? nuevoProducto = Console.ReadLine();

            cuentaProducto.ModificarNombreProducto(productoViejo, nuevoProducto);
            Console.WriteLine("\nNombre cambiado exitosamente.\n");

            Console.WriteLine("Escriba el nuevo precio: ");
            string? precioInput = Console.ReadLine();

            if (decimal.TryParse(precioInput, out decimal nuevoPrecio) && nuevoPrecio >= 0)
            {
                cuentaProducto.ModificarPrecioProducto(nuevoProducto, nuevoPrecio);
                Console.WriteLine("\nPrecio cambiado exitosamente.\n");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nOcurrio un error: {e.Message}\n");
        }
    }


    protected void EliminarProducto()
    {
        try
        {
            Console.WriteLine("Escrime del producto a eliminar ");
            string? eliminar = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(eliminar))
            {
                cuentaProducto.EliminarProducto(eliminar);
                Console.WriteLine("\nProducto Eliminado Exitosamente.\n");
            }
        }
        catch (Exception e)
        {

            Console.WriteLine($"\nOcurrio un error: {e.Message}\n");
        }
    }

    protected void ComprarProducto()
    {

        if (NombreUsuario != null)
        {

            try
            {
                Console.WriteLine("Escribe el nombre del producto\n");

                string? producto = Console.ReadLine();

                NombreProducto = producto;

                cuentaManager.RestarDinero(NombreUsuario, NombreProducto);
                DineroUsuario = cuentaManager.ObtenerDineroUsuario(NombreUsuario);

                Console.WriteLine("Producto Comprado Correctamente.\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nOcurrio un error: {e.Message}\n");
            }
        }
        else
        {
            Console.WriteLine("No has iniciado sesion.\n");
        }
    }

    protected void HistorialUsuario()
    {
        Console.WriteLine(cuentaManager.HistorialCuenta(NombreUsuario));
    }

    protected void ListaProductos()
    {

        Console.WriteLine(cuentaProducto.AlmacenProductos());
    }

    protected void ListaUsuarios()
    {
        Console.WriteLine(cuentaManager.AlmacenUsuarios());
    }
}
