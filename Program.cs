 public class Program
    {
        //Refactorización de código
        static bool esHoraPico (int hora) //Regla 2: Recargo hora pico - separado
        {
            return (hora >= 7 && hora <= 9) || (hora >= 17 && hora <= 20);
        }
        static double calcularTarifa(double distanciaViaje, int hora, int tipoVehiculo)
        {
            double tarifaBase = 0;
            double costoKm = 0;

            switch (tipoVehiculo)
            {
                case 1: 
                tarifaBase = 2.00; 
                costoKm = 1.50; 
                break;
                case 2: 
                tarifaBase = 3.00; 
                costoKm = 2.00; 
                break;
                case 3: 
                tarifaBase = 5.00; 
                costoKm = 3.00; 
                break;
                case 4: 
                tarifaBase = 1.50; 
                costoKm = 1.00; 
                break;
            }
            double subtotal=tarifaBase+(costoKm*distanciaViaje); //Regla 1: Cálculo de tarifa base por tipo de vehículo

            if (esHoraPico(hora))
            {
                subtotal = subtotal * 1.30;
            }

            if (distanciaViaje > 15)//Regla 3: Descuento distancia larga
            {
                subtotal = subtotal * 0.95;
            }

            subtotal = Math.Max(subtotal, 5.00); //Regla 4: Tarifa mínima

            return Math.Round(subtotal, 2); //Regla 5: Redondeo
        }
        //Adición de validación de datos
        static bool esValido(double distanciaViaje, int hora, int tipoVehiculo)
        {
        return distanciaViaje > 0 
        && (hora >= 0 && hora <= 23) 
        && (tipoVehiculo >= 1 && tipoVehiculo <= 4);
        }
        public static void Main(string[] args)
    {
        Console.WriteLine("InDrive - Simulador de Tarifas");
        Console.WriteLine("----------------------------------");
        //Entrada de datos iniciales
        Console.Write("Nombre del pasajero: ");
        string nombrePasajero=Console.ReadLine();
        Console.Write("Distancia del viaje (en km): ");
        double distanciaViaje=double.Parse(Console.ReadLine());
        Console.Write("Hora de salida (formato 24h): ");
        int hora=int.Parse(Console.ReadLine());
        if(hora>=0 && hora<=23)
        {
            Console.WriteLine("Datos iniciales validos");
            Console.WriteLine("----------------------------------");
            //Módulo de tarifas
            Console.WriteLine("Tipo de vehículo:");
            Console.WriteLine("1. Económico");
            Console.WriteLine("2. Confort");
            Console.WriteLine("3. Premium");
            Console.WriteLine("4. Moto");
            Console.Write("Escriba el dígito correspondiente al tipo de vehículo: ");
            int vehiculo=int.Parse(Console.ReadLine());

            string tipoVehiculo="";
            switch (vehiculo)
            {
                case 1:
                    tipoVehiculo = "Económico";
                    break;
                case 2:
                    tipoVehiculo = "Confort";
                    break;
                case 3:
                    tipoVehiculo = "Premium";
                    break;
                case 4:
                    tipoVehiculo = "Moto";
                    break;
                default:
                    Console.WriteLine("Tipo de vehículo no válido.");
                    return;
            }
             Console.WriteLine("----------------------------------");
            if (esHoraPico(hora))
            {
                Console.WriteLine("Aplica recargo de hora pico (+30%)");
            }
            else
            {
                Console.WriteLine("No aplica recargo de hora pico");
            }
            if (distanciaViaje > 15)
                Console.WriteLine("Aplica descuento por distancia larga (-5%)");
            else
                Console.WriteLine("No aplica descuento por distancia larga");

            double tarifa = calcularTarifa(distanciaViaje, hora, vehiculo);
            Console.WriteLine("----------------------------------");

            //Resultado final
            Console.WriteLine("\nSimulador de Tarifa - Indrive");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Pasajero     : {nombrePasajero}");
            Console.WriteLine($"Distancia    : {distanciaViaje} Km");
            Console.WriteLine($"Hora         : {hora}:00 hrs");
            Console.WriteLine($"Tipo vehículo seleccionado   : {tipoVehiculo}");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Tarifa final           : S/ {tarifa}");
            
        }
        else
        {
            Console.WriteLine("Hora no válida. El viaje debe ser entre las 0:00 y las 23:00.");
            return;
        }
    }
    }