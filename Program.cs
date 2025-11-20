using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("=== CALCULO DEL AÑO DE NACIMIENTO ===\n");

            Console.Write("Por favor, escribe tu nombre: ");
            string nombre = Console.ReadLine();

            int edad = -1; 

           
            while (true)
            {
                Console.Write("Ahora escribe tu edad: ");
                string entradaEdad = Console.ReadLine(); 

                if (int.TryParse(entradaEdad, out edad) && edad >= 0 && edad <= 120)
                {
                    break; 
                }

                Console.WriteLine("Error: La edad debe ser un número entre 0 y 120.\n");
            }
    
            int añoActual = DateTime.Now.Year;
            int añoNacimiento = añoActual - edad;

            Console.WriteLine("\n---------------------------------");
            Console.WriteLine($"Hola {nombre}, según los datos:");
            Console.WriteLine($"• El año actual del sistema es: {añoActual}");
            Console.WriteLine($"• Tu año aproximado de nacimiento es: {añoNacimiento}");
            Console.WriteLine("---------------------------------");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("\nPresiona ENTER para salir...");
            Console.ReadLine();
        }
    }
}