using NetLinkWelcomeProject;

List<Airflight> airflights = new List<Airflight>()
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

//var departuresOperators = from flight in airflights
//                          select flight.Departure;

//foreach (var item in departuresOperators)
//    Console.WriteLine(item);
//Console.WriteLine();



//var departuresMethods = airflights.Select(f => f.Departure);

//foreach (var item in departuresMethods)
//    Console.WriteLine(item);
//Console.WriteLine();


var pairsCitiesOperations = from flight in airflights
                            select new
                            {
                                flight.Departure,
                                flight.Arrival,
                            };

foreach (var item in pairsCitiesOperations)
    Console.WriteLine(item);
Console.WriteLine();

var pairsCitiesMethods = airflights.Select(flight => new
                                            {
                                                flight.Departure,
                                                flight.Arrival,
                                            });

foreach (var item in pairsCitiesMethods)
    Console.WriteLine(item);
Console.WriteLine();