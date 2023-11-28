namespace Presentation;

using Business;

public class MenuOpciones
{

    private CuentaUsuarios? Usuarios { get; set; }
    private CuentaUsuarios? Trabajadores { get; set; }

    public string? NombreUsuario { get; set; }
    public string? NombreTrabajador { get; set; }
    public decimal DineroUsuario { get; set; }

    public MenuOpciones()
    {

    }

    public void MenuGeneral(int opcion)
    {
        switch (opcion)
        {

            case 0:

                break;

            case 1:
                Console.Write("Ingresa tu Cuenta: ");
                string? cuenta = Console.ReadLine();

                NombreUsuario = cuenta;

                break;

            case 2:

                Console.WriteLine("Escribe el nombre de tu Cuenta");
                string? nombre = Console.ReadLine();

                NombreUsuario = nombre;

                break;

            case 3:
                break;
        }
    }

    public void MenuTrabajador(int opcion)
    {
        switch (opcion)
        {

            case 0:

                break;

            case 1:

                break;

            case 2:
                break;

            case 3:
                break;
        }
    }

    public void MenuBasicoUsuario(int opcion)
    {
        switch (opcion)
        {

            case 0:

                break;

            case 1:

                break;

            case 2:
                break;

            case 3:
                break;
        }
    }

    public void MenuAvanzadasUsuario(int opcion)
    {
        switch (opcion)
        {

            case 0:

                break;

            case 1:

                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            case 6:
                break;
        }
    }
}