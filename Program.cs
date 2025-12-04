using System;
using System.Globalization;

class Program
{mn
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            try
            {
                Console.WriteLine("=== CALCULO DEL AÑO Y MES DE NACIMIENTO ===\n");

                string usuario = LeerNombre("Escribe tu nombre: ");
                Console.Write("¿La consulta es para ti? (si/no): ");
                string respuesta = Console.ReadLine().Trim().ToLower();

                string nombreConsulta;
                string parentesco;

                if (respuesta == "si")
                {
                    parentesco = "tú";
                    nombreConsulta = usuario;
                }
                else
                {
                    parentesco = LeerNombre("Escribe el parentesco (padre, madre, hijo, etc): ").ToLower();
                    nombreConsulta = LeerNombre("Escribe el nombre de la persona: ");
                }

                int edad;

                // Validación especial para padres y madres
                if (parentesco == "padre" || parentesco == "madre")
                {
                    edad = LeerEdadMinima(15);
                }
                else
                {
                    edad = LeerEdad();
                }

                DateTime fechaNacimiento;

                if (parentesco == "hijo" && edad == 0)
                {
                    int mesNacimiento = LeerMesNacimiento();
                    fechaNacimiento = CalcularFechaNacimientoPorMes(mesNacimiento);

                    int mesesCalculados = CalcularMesesExactos(fechaNacimiento);

                    Console.WriteLine("\n---------------------------------");
                    Console.WriteLine($"Según los datos, {nombreConsulta}:");
                    Console.WriteLine($"• Nació en {ObtenerMes(fechaNacimiento)} {fechaNacimiento.Year}");
                    Console.WriteLine($"• Actualmente tiene {mesesCalculados} meses.");
                    Console.WriteLine("---------------------------------");
                }
                else if (edad == 0)
                {
                    int meses = LeerMeses();
                    fechaNacimiento = DateTime.Now.AddMonths(-meses);

                    Console.WriteLine("\n---------------------------------");
                    Console.WriteLine($"Según los datos, {nombreConsulta}:");
                    Console.WriteLine($"• Tiene {meses} meses.");
                    Console.WriteLine($"• Nació en {ObtenerMes(fechaNacimiento)} de {fechaNacimiento.Year}");
                    Console.WriteLine("---------------------------------");
                }
                else
                {
                    fechaNacimiento = DateTime.Now.AddYears(-edad);

                    Console.WriteLine("\n---------------------------------");
                    Console.WriteLine($"Según los datos, {nombreConsulta}:");
                    Console.WriteLine($"• Año aproximado de nacimiento: {fechaNacimiento.Year}");
                    Console.WriteLine($"• Mes aproximado: {ObtenerMes(fechaNacimiento)}");
                    Console.WriteLine("---------------------------------");
                }

                Console.Write("\n¿Deseas realizar otra consulta? (si/no): ");
                string seguir = Console.ReadLine().Trim().ToLower();

                if (seguir != "si")
                {
                    continuar = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }

        Console.WriteLine("\nGracias y adiós.");
    }

    static string LeerNombre(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string nombre = Console.ReadLine().Trim();

            if (!string.IsNullOrWhiteSpace(nombre))
                return nombre;

            Console.WriteLine("Error: no puede estar vacío.\n");
        }
    }

    static int LeerEdad()
    {
        while (true)
        {
            Console.Write("Escribe la edad (0–120): ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int edad) && edad >= 0 && edad <= 120)
                return edad;

            Console.WriteLine("Edad inválida.\n");
        }
    }

    static int LeerEdadMinima(int minimo)
    {
        while (true)
        {
            Console.Write($"Escribe la edad del {(minimo == 15 ? "padre/madre" : "adulto")} (mínimo {minimo}): ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int edad) && edad >= minimo)
                return edad;

            Console.WriteLine($"Error: debe tener al menos {minimo} años.\n");
        }
    }

    static int LeerMeses()
    {
        while (true)
        {
            Console.Write("Escribe los meses (0–11): ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int meses) && meses >= 0 && meses <= 11)
                return meses;

            Console.WriteLine("Mes inválido.\n");
        }
    }

    static int LeerMesNacimiento()
    {
        while (true)
        {
            Console.Write("Escribe el mes de nacimiento (1–12): ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int mes) && mes >= 1 && mes <= 12)
                return mes;

            Console.WriteLine("Mes inválido.\n");
        }
    }

    static DateTime CalcularFechaNacimientoPorMes(int mesNacimiento)
    {
        int year = DateTime.Now.Year;
        DateTime nacimiento = new DateTime(year, mesNacimiento, 1);

        if (nacimiento > DateTime.Now)
            nacimiento = nacimiento.AddYears(-1);

        return nacimiento;
    }

    static int CalcularMesesExactos(DateTime fecha)
    {
        DateTime hoy = DateTime.Now;
        int meses = (hoy.Year - fecha.Year) * 12 + hoy.Month - fecha.Month;

        return meses;
    }

    static string ObtenerMes(DateTime fecha)
    {
        return fecha.ToString("MMMM", new CultureInfo("es-ES"));
    }
}
