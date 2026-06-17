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
            Console.WriteLine("3. Moto");
            int tipoVehiculo=int.Parse(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Hora no válida. El viaje debe ser entre las 0:00 y las 23:00.");
            return;
        }
    }
    }