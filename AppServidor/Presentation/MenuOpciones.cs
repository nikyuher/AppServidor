namespace Presentation;

using System.Diagnostics;
using Business;
using Spectre.Console;


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
            var table = new Table();
            table.AddColumn("[u]Opción[/]");
            table.AddColumn("[u]Descripción[/]");
            table.AddRow("1.", "Iniciar sesión");
            table.AddRow("2.", "Crear cuenta");
            table.AddRow("3.", "Lista de Productos");
            table.AddRow("", "");
            table.AddRow("0.", "Salir");

            AnsiConsole.Write(table);

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                AnsiConsole.WriteLine("Eso no es una opcion");
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
                    AnsiConsole.WriteLine("[red]Opción no válida. Inténtelo de nuevo.[/]");
                    break;
            }
        }
    }


    public void MenuUsuario()
    {
        while (true)
        {
            var table = new Table();
            table.AddColumn($"[u]Cuenta de {NombreUsuario}[/]");
            table.AddColumn($"[u]Dinero $ {DineroUsuario}[/]");
            table.AddRow("1.", "Configuracion de Cuenta");
            table.AddRow("2.", "Comprar Productos");
            table.AddRow("", "");
            table.AddRow("0.", "Salir");

            AnsiConsole.Write(table);

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                AnsiConsole.WriteLine("Ese no es un número");
                opcion = Console.ReadLine();
            }

            switch (numOption)
            {
                case 1:
                    MenuUsuarioAvanzado();
                    break;

                case 2:
                    MenuComprarProducto();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    AnsiConsole.WriteLine("[red]Opción no válida. Inténtelo de nuevo.[/]");
                    break;
            }
        }
    }


    public void MenuComprarProducto()
    {
        while (true)
        {
            var table = new Table();
            table.AddColumn($"[u]Cuenta de {NombreUsuario}[/]");
            table.AddColumn($"[u]Dinero $ {DineroUsuario}[/]");
            table.AddRow("1.", "Lista Productos");
            table.AddRow("2.", "Búsqueda Productos");
            table.AddRow("", "");
            table.AddRow("0.", "Volver Atras");

            AnsiConsole.Write(table);

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                AnsiConsole.WriteLine("Ese no es un número");
                opcion = Console.ReadLine();
            }

            switch (numOption)
            {
                case 1:
                    ListaProductos();
                    ComprarProducto();
                    break;

                case 2:
                    if (true)
                    {
                        if (BusquedaProducto())
                        {
                            ComprarProducto();
                        }
                    }
                    break;

                case 0:
                    MenuUsuario();
                    break;

                default:
                    AnsiConsole.WriteLine("[red]Opción no válida. Inténtelo de nuevo.[/]");
                    break;
            }
        }
    }


    public void MenuUsuarioAvanzado()
    {
        while (true)
        {
            var table = new Table();
            table.AddColumn($"[u]Cuenta de {NombreUsuario}[/]");
            table.AddColumn($"[u]Dinero $ {DineroUsuario}[/]");
            table.AddRow("1.", "Cambiar Nombre");
            table.AddRow("2.", "Cambiar Contraseña");
            table.AddRow("3.", "Agregar Dinero");
            table.AddRow("4.", "Historial Cuenta");
            table.AddRow("5.", "Cerrar Sesión");
            table.AddRow("6.", "Eliminar Cuenta");
            table.AddRow("", "");
            table.AddRow("0.", "Volver Atrás");

            AnsiConsole.Write(table);

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                AnsiConsole.WriteLine("Ese no es un número");
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
                    AnsiConsole.WriteLine("[red]Opción no válida. Inténtelo de nuevo.[/]");
                    break;
            }
        }
    }


    public void MenuAdministrador()
    {
        while (true)
        {
            var table = new Table();
            table.AddColumn("[u]Cuenta de Administrador[/]");
            table.AddRow("1. Administrar Usuarios");
            table.AddRow("2. Administrar Productos");
            table.AddRow("");
            table.AddRow("0. Salir Cuenta");

            AnsiConsole.Write(table);

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                AnsiConsole.WriteLine("Esa no es una opción\n");
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
                    AnsiConsole.WriteLine("[red]Opción no válida. Inténtelo de nuevo.[/]");
                    break;
            }
        }
    }


    public void MenurAdminUsuario()
    {
        while (true)
        {
            var table = new Table();
            table.AddColumn("[u]Cuenta de Administrador[/]");
            table.AddRow("1. Lista de Usuarios");
            table.AddRow("2. Buscar Usuarios");
            table.AddRow("3. Añadir Usuario");
            table.AddRow("4. Eliminar Usuario");
            table.AddRow("");
            table.AddRow("0.Volver Atrás");

            AnsiConsole.Write(table);

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                AnsiConsole.WriteLine("Esa no es una opción\n");
                opcion = Console.ReadLine();
            }

            switch (numOption)
            {
                case 1:
                    ListaUsuarios();
                    break;
                case 2:
                    BusquedaUsuarios();
                    break;
                case 3:
                    CrearCuenta();
                    break;

                case 4:
                    if (BusquedaUsuarios())
                    {
                        EliminarCuenta();
                    }

                    break;
                case 0:
                    MenuAdministrador();
                    break;

                default:
                    AnsiConsole.WriteLine("[red]Opción no válida. Inténtelo de nuevo.[/]");
                    break;
            }
        }
    }


    public void MenuAdminProducto()
    {
        while (true)
        {
            var table = new Table();
            table.AddColumn("[u]Cuenta de Administrador[/]");
            table.AddRow("1. Lista de Productos");
            table.AddRow("2. Buscar Productos");
            table.AddRow("3. Añadir Producto");
            table.AddRow("4. Modificar Producto");
            table.AddRow("5. Eliminar Producto");
            table.AddRow("");
            table.AddRow("0.Volver Atrás");

            AnsiConsole.Write(table);

            string? opcion = Console.ReadLine();
            int numOption = 0;

            while (!int.TryParse(opcion, out numOption))
            {
                AnsiConsole.WriteLine("Esa no es una opción\n");
                opcion = Console.ReadLine();
            }

            switch (numOption)
            {
                case 1:
                    ListaProductos();
                    break;
                case 2:
                    BusquedaProducto();
                    break;
                case 3:
                    CrearProducto();
                    break;

                case 4:
                    if (BusquedaProducto())
                    {
                        ModificarProducto();
                    }
                    break;

                case 5:
                    if (BusquedaProducto())
                    {
                        EliminarProducto();
                    }
                    break;
                case 0:
                    MenuAdministrador();
                    break;

                default:
                    AnsiConsole.WriteLine("[red]Opción no válida. Inténtelo de nuevo.[/]");
                    break;
            }
        }
    }



    protected void CrearCuenta()
    {
        try
        {
            AnsiConsole.WriteLine("\nCREANDO CUENTA\n");

            Console.Write("Crea un Nombre: ");
            string? nombre = Console.ReadLine();

            Console.Write("Crea una Contraseña: ");
            string? contraseña = Console.ReadLine();

            cuentaManager.CrearCuenta(nombre, contraseña);

            AnsiConsole.WriteLine("\n[green]Cuenta creada exitosamente.[/]\n");
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine($"\n[red]Ocurrio un error: {e.Message}[/]\n");
        }
    }

    protected void CrearProducto()
    {
        if (NombreUsuario == "admin")
        {
            try
            {
                AnsiConsole.WriteLine("\nAÑADIENDO PRODUCTO\n");

                AnsiConsole.WriteLine("Escribe el nombre del producto.");

                string? nombre = Console.ReadLine();

                AnsiConsole.WriteLine("Ponle un precio al producto.");
                string? precioConvert = Console.ReadLine();
                decimal precio = 0;

                while (!decimal.TryParse(precioConvert, out precio))
                {
                    AnsiConsole.WriteLine("\nEse no es un numero.\n");
                    precioConvert = Console.ReadLine();
                }

                cuentaProducto.CrearProducto(nombre, precio);

                AnsiConsole.WriteLine("\nProducto añadido exitosamente.\n");
            }
            catch (Exception e)
            {
                AnsiConsole.WriteLine($"\nOcurrio un error: {e.Message}\n");
            }

        }
        else
        {
            AnsiConsole.WriteLine("\nEsta no es una cuenta ADMIN\n");
        }
    }

    protected void IniciarSesion()
    {
        AnsiConsole.WriteLine("\nINICIANDO SESION\n");

        Console.Write("Ingrese nombre de usuario: ");
        string? nombre = Console.ReadLine();

        Console.Write("Ingrese contraseña: ");
        string? contraseña = Console.ReadLine();

        if (cuentaManager.IniciarSesion(nombre, contraseña))
        {

            if (nombre == "admin")
            {
                NombreUsuario = nombre;
                AnsiConsole.WriteLine("\nInicio de sesión exitoso.\n");
                MenuAdministrador();
            }
            else
            {
                NombreUsuario = nombre;
                DineroUsuario = cuentaManager.ObtenerDineroUsuario(NombreUsuario);

                AnsiConsole.WriteLine("\nInicio de sesión exitoso.\n");

                MenuUsuario();
            }
        }
        else
        {
            AnsiConsole.WriteLine("\nInicio de sesión fallido.\n");
        }
    }

    protected void CerrarSesion()
    {
        NombreUsuario = null;
        DineroUsuario = 0;

        AnsiConsole.WriteLine("\nSesion Cerrada Correctamente \n");

        MenuGeneral();
    }

    protected void AnadirDinero()
    {

        if (NombreUsuario != null)
        {
            try
            {
                AnsiConsole.WriteLine("\nAÑADIENDO DINERO\n");

                AnsiConsole.WriteLine("Cuanto dinero quieres agregar");
                string? convert = Console.ReadLine();

                int dinero = 0;

                while (!int.TryParse(convert, out dinero))
                {
                    AnsiConsole.WriteLine("\nEse no es un numero.\n");
                    convert = Console.ReadLine();
                }

                cuentaManager.AgregarDinero(NombreUsuario, dinero);
                DineroUsuario = cuentaManager.ObtenerDineroUsuario(NombreUsuario);

                AnsiConsole.WriteLine("\nDinero añadido exitosamente.\n");
            }
            catch (Exception e)
            {
                AnsiConsole.WriteLine($"\nOcurrio un error: {e.Message}\n");
            }
        }
        else
        {
            AnsiConsole.WriteLine("\nNo has iniciado sesion.\n");
        }
    }

    protected void CambiarNombre()
    {
        AnsiConsole.WriteLine("\nCAMBIANDO NOMBRE\n");

        AnsiConsole.WriteLine("Escrime tu nuevo nombre: ");
        string? nombreNuevo = Console.ReadLine();


        try
        {
            cuentaManager.ModificarNombre(NombreUsuario, nombreNuevo);

            NombreUsuario = nombreNuevo;

            AnsiConsole.WriteLine("\nCambio de nombre exitoso.\n");
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine($"\nOcurrio un Error: {e.Message}\n");
        }
    }

    protected void CambiarContraseña()
    {
        AnsiConsole.WriteLine("\nCAMBIANDO CONTRASEÑA\n");

        AnsiConsole.WriteLine("Escrime tu nueva Contrasena: ");
        string? nuevaContra = Console.ReadLine();

        try
        {
            cuentaManager.ModificarContraseña(NombreUsuario, nuevaContra);

            DineroUsuario = cuentaManager.ObtenerDineroUsuario(NombreUsuario);

            AnsiConsole.WriteLine("\nCambio de nombre exitoso.\n");
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine($"\nOcurrio un Error: {e.Message}\n");
        }
    }

    protected void EliminarCuenta()
    {
        try
        {
            if (NombreUsuario == "admin")
            {
                AnsiConsole.WriteLine("¿Que cuenta quieres Eliminar?\n");
                string? cuenta = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(cuenta))
                {
                    cuentaManager.EliminarCuenta(cuenta);
                    AnsiConsole.WriteLine("\nCuenta Eliminada exitisa.\n");
                }
                else
                {
                    throw new Exception("No puedes poner vacios.");
                }
            }
            else
            {
                cuentaManager.EliminarCuenta(NombreUsuario);
                AnsiConsole.WriteLine("\nCuenta Eliminada exitisa.\n");

                MenuGeneral();
            }
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine($"\nOcurrio un error: {e.Message}\n");
        }
    }

    protected void ModificarProducto()
    {
        try
        {
            AnsiConsole.WriteLine("\nMODIFICANDO PRODUCTO\n");

            AnsiConsole.WriteLine("¿Que producto modificara?: ");
            string? productoViejo = Console.ReadLine();


            AnsiConsole.WriteLine("Escriba el nuevo nombre: ");
            string? nuevoProducto = Console.ReadLine();

            cuentaProducto.ModificarNombreProducto(productoViejo, nuevoProducto);
            AnsiConsole.WriteLine("\nNombre cambiado exitosamente.\n");

            AnsiConsole.WriteLine("Escriba el nuevo precio: ");
            string? precioInput = Console.ReadLine();

            if (decimal.TryParse(precioInput, out decimal nuevoPrecio) && nuevoPrecio >= 0)
            {
                cuentaProducto.ModificarPrecioProducto(nuevoProducto, nuevoPrecio);
                AnsiConsole.WriteLine("\nPrecio cambiado exitosamente.\n");
            }
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine($"\nOcurrio un error: {e.Message}\n");
        }
    }


    protected void EliminarProducto()
    {
        try
        {
            AnsiConsole.WriteLine("\nELIMINANDO PRODUCTO\n");

            AnsiConsole.WriteLine("Escrime del producto a eliminar ");
            string? eliminar = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(eliminar))
            {
                cuentaProducto.EliminarProducto(eliminar);
                AnsiConsole.WriteLine("\nProducto Eliminado Exitosamente.\n");
            }
            else
            {
                throw new Exception("No puedes poner vacios.");
            }
        }
        catch (Exception e)
        {

            AnsiConsole.WriteLine($"\nOcurrio un error: {e.Message}\n");
        }
    }

    protected void ComprarProducto()
    {

        if (NombreUsuario != null)
        {

            try
            {

                AnsiConsole.WriteLine("Quieres Comprar: S/N ");
                string? confirmacion = Console.ReadLine();

                if (confirmacion != "S" && confirmacion != "N" && confirmacion != "s" && confirmacion != "n")
                {
                    throw new Exception("Esa no es una opcion valida");
                }

                if (confirmacion == "S" || confirmacion == "s")
                {

                    AnsiConsole.WriteLine("\nCOMPRANDO PRODUCTO\n");

                    AnsiConsole.WriteLine("Escribe el nombre del producto\n");

                    string? producto = Console.ReadLine();

                    NombreProducto = producto;

                    cuentaManager.RestarDinero(NombreUsuario, NombreProducto);
                    DineroUsuario = cuentaManager.ObtenerDineroUsuario(NombreUsuario);

                    AnsiConsole.WriteLine("Producto Comprado Correctamente.\n");

                }

            }
            catch (Exception e)
            {
                AnsiConsole.WriteLine($"\nOcurrio un error: {e.Message}\n");
            }
        }
        else
        {
            AnsiConsole.WriteLine("No has iniciado sesion.\n");
        }
    }


    protected bool BusquedaProducto()
    {
        try
        {
            AnsiConsole.WriteLine("¿Que deseas buscar?");
            string? busqueda = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                List<CuentaProductos> resultados = cuentaProducto.BuscarProductos(busqueda);

                AnsiConsole.WriteLine(cuentaProducto.ResultadosProducto(resultados));

                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine($"\nOcurrio un error: {e.Message}\n");
            return false;
        }
    }

    protected bool BusquedaUsuarios()
    {
        try
        {
            AnsiConsole.WriteLine("¿Que usuario Buscas?");
            string? busqueda = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                List<CuentaUsuarios> resultados = cuentaManager.BuscarUsuarios(busqueda);

                AnsiConsole.WriteLine(cuentaManager.ResultadosUsuario(resultados));

                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            AnsiConsole.WriteLine($"\nOcurrio un error: {e.Message}\n");
            return false;
        }
    }

    protected void HistorialUsuario()
    {
        AnsiConsole.WriteLine(cuentaManager.HistorialCuenta(NombreUsuario));
    }

    protected void ListaProductos()
    {

        AnsiConsole.WriteLine(cuentaProducto.AlmacenProductos());
    }

    protected void ListaUsuarios()
    {
        AnsiConsole.WriteLine(cuentaManager.AlmacenUsuarios());
    }
}
