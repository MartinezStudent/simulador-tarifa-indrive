 public class Program
    {
        public static void Main(string[] args)
    {
        Console.WriteLine("InDrive - Simulador de Tarifas");
        Console.WriteLine("----------------------------------");
        //Entrada de datos iniciales
        Console.WriteLine("Nombre del pasajero:");
        string nombrePasajero=Console.ReadLine();
        Console.WriteLine("Distancia del viaje (en km):");
        double distanciaViaje=double.Parse(Console.ReadLine());
        Console.WriteLine("Hora de salida (formato 24h):");
        int hora=int.Parse(Console.ReadLine());
        if(hora>=0 && hora<=23)
        {
            Console.WriteLine("Datos iniciales validos");
            Console.WriteLine("----------------------------------");
            //Módulo de tarifas
            Console.WriteLine("Seleccione el tipo de vehículo:");
            Console.WriteLine("1. Económico");
            Console.WriteLine("2. Confort");
            Console.WriteLine("3. Premium");
            Console.WriteLine("4. Moto");
            int tipoVehiculo=int.Parse(Console.ReadLine());
            //Variables para cálculo de tarifa
            double tarifaBase=0;
            double costoKm=0;
            string tipoVehiculo="";
            switch(tipoVehiculo)
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
        }
        else
        {
            Console.WriteLine("Hora no válida. El viaje debe ser entre las 0:00 y las 23:00.");
            return;
        }
    }
    }