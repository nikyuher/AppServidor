namespace Presentation;

using Business;

public class MenuOpciones
{

    public CuentaUsuarios? Usuarios { get; set; }
    public CuentaUsuarios? Trabajadores { get; set; }

    public string? NombreUsuario { get; set; }
    public string? NombreTrabajador { get; set; }
    public decimal DineroUsuario { get; set; }

    protected List<CuentaUsuarios> ListaUsuarios = new List<CuentaUsuarios>() { };
    protected List<CuentaTrabajadores> ListaTrabajadores = new List<CuentaTrabajadores>() { };

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

                break;

            case 2:
                break;

            case 3:
                break;
        }
    }
}