using System;
public class Logger
{
    private static Logger? _instance;
    private static readonly object _lock = new object();

    private Logger() { }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new Logger();
            }
        }
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"[LOG - {DateTime.Now}] {message}");
    }
}
class Program
{
    static void Maind(string[] args)
    {
        // Obtener la instancia del Logger
        var logger1 = Logger.GetInstance();
        var logger2 = Logger.GetInstance();

        // Probar que ambas variables apuntan a la misma instancia
        Console.WriteLine("¿logger1 y logger2 son el mismo objeto?: " + (logger1 == logger2));

        // Mostrar los hashcodes para comprobar que son iguales
        Console.WriteLine("Hash de logger1: " + logger1.GetHashCode());
        Console.WriteLine("Hash de logger2: " + logger2.GetHashCode());

        if (logger1 == logger2)
            Console.WriteLine("Ambos son de misma instancia " + (logger1.GetHashCode() == logger2.GetHashCode()));
        else
            Console.WriteLine("No son de la misma instancia "  + (logger1.GetHashCode() == logger2.GetHashCode()));

        // Usar el logger
        Console.ReadKey(); // Espera una tecla para cerrar consola
    }
}