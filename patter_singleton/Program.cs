using System;

/// <summary>
/// Representa un contador global implementado usando el patrón Singleton.
/// 
/// Este patrón garantiza que solo exista una instancia de la clase en toda la aplicación,
/// lo cual es útil para manejar recursos compartidos como contadores, loggers o configuraciones.
/// 
/// ✔ Problema que resuelve:
///   - Evita múltiples instancias del contador en diferentes partes del sistema.
///   - Proporciona un punto de acceso global y seguro para modificar el contador.
/// 
/// ✔ Características:
///   - Constructor privado para evitar instanciación externa.
///   - Propiedad estática 'Instance' que devuelve la única instancia.
///   - Uso de 'lock' para asegurar el acceso seguro en entornos multi-hilo.
/// 
/// ✔ Ejemplo de uso:
///   var contador = GlobalCounter.Instance;
///   contador.Increment();
///   contador.Show();
/// 
/// Este patrón es fundamental para mantener la consistencia de datos y optimizar el uso de recursos.
/// </summary>

namespace patter_singleton
{
    // 🧠 Singleton que representa un contador global
    public class GlobalCounter
    {
        // 1. Instancia única
        private static GlobalCounter ? _instance;

        // 2. Lock para thread safety
        private static readonly object _lock = new object();

        // 3. Contador
        public int Count { get; private set; }

        // 4. Constructor privado
        private GlobalCounter()
        {
            Count = 0;
            Console.WriteLine("Instancia de GlobalCounter creada");
        }

        // 5. Propiedad pública para acceder a la instancia
        public static GlobalCounter Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new GlobalCounter();

                    return _instance;
                }
            }
        }

        // 6. Método para incrementar
        public void Increment()
        {
            Count++;
            Console.WriteLine($"Contador incrementado a: {Count}");
        }

        // 7. Método para mostrar el valor actual
        public void Show()
        {
            Console.WriteLine($"Valor actual del contador: {Count}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🧪 Iniciando prueba de patrón Singleton (Contador Global)");

            // Obtenemos la instancia única
            var contador1 = GlobalCounter.Instance;
            contador1.Increment(); // Contador: 1
            contador1.Increment(); // Contador: 2
            contador1.Show();      // Muestra: 2

            // Obtenemos otra referencia
            var contador2 = GlobalCounter.Instance;
            contador2.Increment(); // Contador: 3

            // Verificamos que sea la misma instancia
            Console.WriteLine($"¿contador1 y contador2 son la misma instancia? {object.ReferenceEquals(contador1, contador2)}");

            contador1.Show(); // Muestra: 3

            Console.WriteLine("✅ Prueba finalizada");
        }
    }
}
