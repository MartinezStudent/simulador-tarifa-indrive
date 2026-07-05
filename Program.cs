 public class Program
    {
    //Refactorización de código
        static bool esHoraPico (int hora) 
        {
        return (hora >= 7 && hora <= 9) || (hora >= 17 && hora <= 20); //Regla 2: Recargo hora pico - separado
        }
        static double calcularTarifa(double distanciaViaje, int hora, int tipoVehiculo)
        {
        double tarifaBase = 0; double costoKm = 0;

        switch (tipoVehiculo)
        {
        case 1: tarifaBase = 2.00; costoKm = 1.50; break;
        case 2: tarifaBase = 3.00; costoKm = 2.00; break;
        case 3: tarifaBase = 5.00; costoKm = 3.00; break;
        case 4: tarifaBase = 1.50; costoKm = 1.00; break;
        }
        double subtotal=tarifaBase+(costoKm*distanciaViaje); //Regla 1: Cálculo de tarifa base por tipo de vehículo

        if (esHoraPico(hora))
        {
        subtotal = subtotal * 1.30;
        }

        if (distanciaViaje > 15) 
        {
        subtotal = subtotal * 0.95; //Regla 3: Descuento distancia larga
        }
        
        subtotal = Math.Max(subtotal, 5.00); //Regla 4: Tarifa mínima
        return Math.Round(subtotal, 2); //Regla 5: Redondeo
        }
        //Adición de validación de datos
        static bool esValido(double distanciaViaje, int hora, int tipoVehiculo)
        {
        return distanciaViaje > 0 
        && hora >= 0 && hora <= 23
        && tipoVehiculo >= 1 && tipoVehiculo <= 4;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("InDrive - Cierre de Turno");
            Console.WriteLine("----------------------------------");

            Console.Write("Cantidad de viajes realizadas por el conductor: "); //Regla 1: Cantidad de viajes
            int n = int.Parse(Console.ReadLine());

            //Regla 3: Guardar los resultados en arreglos
            double[] tarifas = new double[n];
            bool[] picoHora = new bool[n];
            double distanciaTotal = 0; //Variable declarada para hacer pruebas de las reglas a implementar

            for (int i = 0; i < n; i++)// Regla 2: Registro y validación de cada viaje
            {
                double distanciaViaje;
                int hora;
                int vehiculo;
                bool validacionDatos;
                do
                {
                    Console.WriteLine($"\nViaje {i + 1} de {n}");
                    Console.Write("Distancia del viaje (en km): ");
                    distanciaViaje=double.Parse(Console.ReadLine());
                    Console.Write("Hora de salida (formato 24h): ");
                    hora=int.Parse(Console.ReadLine());
                    //Tarifas
                    Console.WriteLine("Tipo de vehículo:");
                    Console.WriteLine("1. Económico");
                    Console.WriteLine("2. Confort");
                    Console.WriteLine("3. Premium");
                    Console.WriteLine("4. Moto");
                    Console.Write("Escriba el dígito correspondiente al tipo de vehículo: ");
                    vehiculo=int.Parse(Console.ReadLine());

                    validacionDatos = esValido(distanciaViaje, hora, vehiculo); //LLamada a función de validación de datos
                    if(!validacionDatos)
                    {
                        Console.WriteLine("Datos ingresados no válidos. Intente nuevamente");
                    }
                } while (!validacionDatos); //fin del do-while
            
            tarifas[i] = calcularTarifa(distanciaViaje, hora, vehiculo);
            picoHora[i] = esHoraPico(hora);
            distanciaTotal += distanciaViaje; //Acumulación de la distancia total
            } //Fin del for
/*
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
            */
            //Adición de la suma de tarifas para el cierre de turno
            double tarifaTotalPrueba = 0;
            for (int i = 0; i < n; i++)
            {
                tarifaTotalPrueba += tarifas[i];
            }
            //Print de prueba en consola
            Console.WriteLine($"Cantidad de viajes       : {n}");
            Console.WriteLine($"Distancia total recorrida: {distanciaTotal} Km");
            Console.WriteLine($"Tarifa total sumada      : S/ {tarifaTotalPrueba:F2}");

            /*Resultado final- código inical
            Console.WriteLine("\nSimulador de Tarifa - Indrive");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Pasajero     : {nombrePasajero}");
            Console.WriteLine($"Distancia    : {distanciaViaje} Km");
            Console.WriteLine($"Hora         : {hora}:00 hrs");
            Console.WriteLine($"Tipo vehículo seleccionado   : {tipoVehiculo}");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Tarifa final           : S/ {tarifa}");*/
            
        }
    }