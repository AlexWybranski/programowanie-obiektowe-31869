using System.Text.Json;
using Lab3_komis;

var carsPath = Path.Combine(Directory.GetCurrentDirectory(), "cars.json");
var bikesPath = Path.Combine(Directory.GetCurrentDirectory(), "bikes.json");

var carsJson = File.ReadAllText(carsPath);
var bikesJson = File.ReadAllText(bikesPath);

var cars = JsonSerializer.Deserialize<List<Car>>(carsJson);
var bikes = JsonSerializer.Deserialize<List<Bike>>(bikesJson);

List<Vehicle> Vehicles()
{
    var list = new List<Vehicle>();
    list.AddRange(cars);
    list.AddRange(bikes);
    return list;
}

bool running = true;

do
{
    Console.WriteLine("Vehicle lot");
    Console.Write("Select option:\n[1] Show all\n[2] Search by year\n[3] Search by model\n" +
                  "[4] Search by engine capacity\n[5] Add Vehicle\n[0] Exit\n");
    
    var input = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (input)
    {
        case '1':
            DisplayVehicleModel();
            break;
        case '2':
            SearchByYear();
            break;
        case '3':
            SearchByModel();
            break;
        case '4':
            SearchByEngineCapacity();
            break;
        case '5':
            AddNewVehicle();
            break;
        case '0':
            Console.WriteLine("Goodbye...");
            running = false;
            break;
        default: 
            Console.WriteLine("Invalid menu option");
            break;
    }
} while (running);

void DisplayVehicleModel()
{
    Console.WriteLine("Vehicles:");
    foreach (var veh in Vehicles())
    {
        Console.WriteLine(veh.Model);
    }
}

void SearchByYear()
{
    Console.Write("Enter year: ");
    var success = Int32.TryParse(Console.ReadLine(), out int year);
    if (!success)
    {
        Console.WriteLine("Invalid year");
        SearchByYear();
        return;
    }
    var vehicles = Vehicles().Where(veh => veh.Year == year);

    if (!vehicles.Any())
    {
        Console.WriteLine("No vehicles found");
    }
    else
    {
        foreach (var veh in vehicles)
        {
            Console.WriteLine(veh.Model);
        }
    }
}

void SearchByModel()
{
    Console.Write("Enter model: ");
    string? input =  Console.ReadLine();
    if (String.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Invalid model");
        SearchByModel();
        return;
    }
    input = input.ToLower().Trim();
    
    var vehicles = Vehicles().Where(veh => veh.Model.ToLower() == input);

    if (!vehicles.Any())
    {
        Console.WriteLine("No vehicles found");
    }
    else
    {
        foreach (var veh in vehicles)
        {
            Console.WriteLine(veh.Model);
        }
    }
}

void SearchByEngineCapacity()
{
    Console.Write("Enter engine capacity: ");
    var success = double.TryParse(Console.ReadLine(), out double engineCapacity);
    if (!success)
    {
        Console.WriteLine("Invalid format, try 'x,y'");
        SearchByEngineCapacity();
        return;
    }
    var vehicles = Vehicles().Where(veh => veh.EngineCapacity == engineCapacity);

    if (!vehicles.Any())
    {
        Console.WriteLine("No vehicles found");
    }
    else
    {
        foreach (var veh in vehicles)
        {
            Console.WriteLine(veh.Model);
        }
    }
}

void AddNewVehicle()
{
    Console.WriteLine("B for Bike, C for Car");
    var input = Console.ReadKey().KeyChar;
    Console.WriteLine();
    if (input.ToString().ToLower() is not ("b" or "c"))
    {
        Console.WriteLine("Invalid type of vehicle");
        return;
    }
    
    Console.Write("Enter engine capacity: ");
    var success = double.TryParse(Console.ReadLine(), out double engineCapacity);
    if (!success)
    {
        Console.WriteLine("Invalid engine capacity");
        return;
    }
    
    Console.Write("Enter model: ");
    string? model = Console.ReadLine();
    if (String.IsNullOrEmpty(model))
    {
        Console.WriteLine("Invalid model");
        return;
    }
    
    Console.Write("Enter year: ");
    success = Int32.TryParse(Console.ReadLine(), out int year);
    if (!success)
    {
        Console.WriteLine("Invalid year");
        return;
    }
    
    if (input == 'c')
    {
        var v = new Car(engineCapacity, model, year);
        cars.Add(v);
        File.WriteAllText(carsPath, JsonSerializer.Serialize(cars));
    }
    else
    {
        var v = new Bike(engineCapacity, model, year);
        bikes.Add(v);
        File.WriteAllText(bikesPath, JsonSerializer.Serialize(bikes));
    }
}