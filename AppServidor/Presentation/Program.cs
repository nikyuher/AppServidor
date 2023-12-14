namespace Presentation;

using Serilog;

class Program
{
    static void Main()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        try
        {
            MenuOpciones menu = new MenuOpciones();
            menu.MenuGeneral();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ocurrió un error inesperado en la aplicación.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
