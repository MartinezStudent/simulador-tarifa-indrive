 public class Program
    {
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

            //Variables para cálculo de tarifa
            double tarifaBase=0;
            double costoKm=0;
            string tipoVehiculo="";//Se asignará según la selección del usuario (case)
            switch(vehiculo)
            {
                case 1:
                    tipoVehiculo="Económico";
                    tarifaBase=2.00;
                    costoKm=1.50;
                    break;
                case 2:
                    tipoVehiculo="Confort";
                    tarifaBase=3.00;
                    costoKm=2.00;
                    break;
                case 3:
                    tipoVehiculo="Premium";
                    tarifaBase=5.00;
                    costoKm=3.00;
                    break;
                case 4:
                    tipoVehiculo="Moto";
                    tarifaBase=1.5;
                    costoKm=1.00;
                    break;
                default:
                    Console.WriteLine("Tipo de vehículo no válido.");
                    return;
            }
            Console.WriteLine("\nRealizando cálculos de tarifa...");
            Console.WriteLine("----------------------------------");

            //Asignación de reglas de problemática a resolver
            
            //Regla 1: Cálculo de tarifa base por tipo de vehículo
            double subtotal=tarifaBase+(costoKm*distanciaViaje);

            //Regla 2: Recargo hora pico
            if ((hora >= 7 && hora <= 9) || (hora >= 17 && hora <= 20))
            {
                subtotal = subtotal * 1.30;
                Console.WriteLine("Aplica recargo de hora pico (+30%)");
            }
            else
            {
                Console.WriteLine("No aplica recargo de hora pico");
            }

            //Regla 3: Descuento distancia larga
            if (distanciaViaje > 15)
            {
                subtotal = subtotal * 0.95;
                Console.WriteLine("Aplica descuento por distancia larga (-5%)");
            }
            else
            {
                Console.WriteLine("No aplica descuento por distancia larga");
            }

            //Regla 4: Tarifa mínima
            subtotal = Math.Max(subtotal, 5.00);

            //Regla 5: Redondeo
            double tarifa = Math.Round(subtotal, 2);
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