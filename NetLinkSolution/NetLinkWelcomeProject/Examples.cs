using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLinkWelcomeProject
{
    static class Examples
    {
        static List<Airflight> airflights = new List<Airflight>()
        {
            new(){ Name = "ASD-123", Departure = "Moscow", Arrival = "St Peterburg", Price = 7500 },
            new(){ Name = "HJK-893", Departure = "St Peterburg", Arrival = "Ekaterinburg", Price = 12000 },
            new(){ Name = "SD-101", Departure = "Moscow", Arrival = "Kazan", Price = 10000 },
            new(){ Name = "ERT-246", Departure = "St Peterburg", Arrival = "Moscow", Price = 8000 },
            new(){ Name = "POY-987", Departure = "Kazan", Arrival = "Irkutsk", Price = 20000 },
            new(){ Name = "NM-550", Departure = "St Peterburg", Arrival = "Vladivostok", Price = 30000 },
            new(){ Name = "LKE-231", Departure = "Moscow", Arrival = "Vladivostok", Price = 32000 },
            new(){ Name = "AXC-775", Departure = "Irkutsk", Arrival = "Moscow", Price = 23000 },
            new(){ Name = "LKL-56", Departure = "Kazan", Arrival = "Moscow", Price = 11000 },
            new(){ Name = "WQ-200", Departure = "Moscow", Arrival = "Kaliningrad", Price = 9000 },
        };
        public static void LinqWelcomeExample()
        {
            List<Airflight> airflightsFromMoscow = new List<Airflight>();

            foreach (var flight in airflights)
                if (flight.Departure?.ToLower() == "moscow")
                    airflightsFromMoscow.Add(flight);


            foreach (var flight in airflightsFromMoscow)
                Console.WriteLine(flight);
            Console.WriteLine();


            var airflightsLinqOperations = from flight in airflights
                                           where flight.Departure?.ToLower() == "moscow"
                                           select flight;

            foreach (var flight in airflightsLinqOperations)
                Console.WriteLine(flight);
            Console.WriteLine();


            var airflightsLinqMethods = airflights
                                        .Where(f => f.Departure?.ToLower() == "moscow");

            foreach (var flight in airflightsLinqMethods)
                Console.WriteLine(flight);
            Console.WriteLine();
        }
    }
}
