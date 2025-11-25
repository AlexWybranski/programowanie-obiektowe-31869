using Lab3_komis;
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
            SearchBy.Year();
            break;
        case '3':
            SearchBy.Model();
            break;
        case '4':
            SearchBy.EngineCapacity();
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
    foreach (var veh in Database.Vehicles)
    {
        Console.WriteLine(veh.Model);
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

    Vehicle v;
    if (input == 'C')
    {
        v = new Car(engineCapacity, model, year);
    }
    else
    {
        v = new Bike(engineCapacity, model, year);
    }
    Database.Vehicles.Add(v);
}