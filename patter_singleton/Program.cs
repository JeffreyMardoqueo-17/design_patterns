using System;
namespace patter_singleton
{
    public class Singleton
    {
        private static Singleton? _instance;
        private static readonly object _lock = new object();
        private Singleton() { }

        //metodo
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)

                        _instance = new Singleton();
                }
            }
            return _instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Obtener la instancia del Singleton
            var instancia1 = Singleton.GetInstance();
            var instancia2 = Singleton.GetInstance();

            // Probar que ambas variables apuntan a la misma instancia
            Console.WriteLine("¿instancia1 y instancia2 son el mismo objeto?: " + (instancia1 == instancia2));

            // Mostrar los hashcodes para comprobar que son iguales
            Console.WriteLine("Hash de instancia1: " + instancia1.GetHashCode());
            Console.WriteLine("Hash de instancia2: " + instancia2.GetHashCode());

            Console.ReadKey(); // Espera una tecla para cerrar consola
        }
    }
}