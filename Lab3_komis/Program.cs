using System.Text.Json;
using Lab3_komis;
using Lab3_komis.Database;

// var carsPath = Path.Combine(Directory.GetCurrentDirectory(), "cars.json");
// var bikesPath = Path.Combine(Directory.GetCurrentDirectory(), "bikes.json");
//
// var carsJson = File.ReadAllText(carsPath);
// var bikesJson = File.ReadAllText(bikesPath);
//
// var cars = JsonSerializer.Deserialize<List<Car>>(carsJson);
// var bikes = JsonSerializer.Deserialize<List<Bike>>(bikesJson);

// List<Vehicle> Vehicles()
// {
//     var list = new List<Vehicle>();
//     list.AddRange(cars);
//     list.AddRange(bikes);
//     return list;
// }

var db = new CarsDb();

bool running = true;

do
{
    Console.WriteLine("Vehicle lot");
    Console.Write("Select option:\n[1] Show all\n[2] Search by year\n[3] Search by model\n" +
                  "[4] Search by engine capacity\n[5] Add Vehicle\n[6] Edit vehicle\n[7] Delete vehicle\n[0] Exit\n");
    
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
        case '6':
            EditVehicle();
            break;
        case '7':
            DeleteVehicle();
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
    foreach (var veh in db.Vehicles)
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
    var vehicles = db.Vehicles.Where(veh => veh.Year == year);

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
    
    var vehicles = db.Vehicles.Where(veh => veh.Model.ToLower() == input);

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
    var vehicles = db.Vehicles.Where(veh => veh.EngineCapacity == engineCapacity);

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
        db.Cars.Add(v);
    }
    else
    {
        var v = new Bike(engineCapacity, model, year);
        db.Bikes.Add(v);
    }

    db.SaveChanges();
}

void EditVehicle()
{
    Console.WriteLine("B for Bike, C for Car");
    var input = Console.ReadKey().KeyChar;
    Console.WriteLine();
    if (input.ToString().ToLower() is not ("b" or "c"))
    {
        Console.WriteLine("Invalid type of vehicle");
        return;
    }
    else
    {
        if (input == 'c')
        {
            Console.WriteLine("Cars:");
            foreach (var veh in db.Cars)
            {
                Console.WriteLine(veh.Id);
                Console.WriteLine(veh.Model);
            }

            Console.WriteLine("Choose car to edit: ");
            int car = Convert.ToInt32(Console.ReadLine());

            var edited = db.Cars.FirstOrDefault(a => a.Id == car);

            if (edited != null)
            {
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

                edited.EngineCapacity = engineCapacity;
                edited.Model = model;
                edited.Year = year;
                db.Cars.Update(edited);
            }
        }
        else
        {
            Console.WriteLine("Bikes:");
            foreach (var veh in db.Bikes)
            {
                Console.WriteLine(veh.Id);
                Console.WriteLine(veh.Model);
            }

            Console.WriteLine("Choose bike to edit: ");
            int bike = Convert.ToInt32(Console.ReadLine());

            var edited = db.Bikes.FirstOrDefault(a => a.Id == bike);

            if (edited != null)
            {
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

                edited.EngineCapacity = engineCapacity;
                edited.Model = model;
                edited.Year = year;
                db.Bikes.Update(edited);
            }
        } 
        db.SaveChanges();
    }
}

void DeleteVehicle()
{
    Console.WriteLine("B for Bike, C for Car");
    var input = Console.ReadKey().KeyChar;
    Console.WriteLine();
    if (input.ToString().ToLower() is not ("b" or "c"))
    {
        Console.WriteLine("Invalid type of vehicle");
        return;
    }
    else
    {
        if (input == 'c')
        {
            Console.WriteLine("Cars:");
            foreach (var veh in db.Cars)
            {
                Console.WriteLine(veh.Id);
                Console.WriteLine(veh.Model);
            }

            Console.WriteLine("Choose car to delete: ");
            int car = Convert.ToInt32(Console.ReadLine());

            var deleted = db.Cars.FirstOrDefault(a => a.Id == car);
            if (deleted != null)
            {
                db.Cars.Remove(deleted);
            }
        }
        else
        {
            Console.WriteLine("Bikes:");
            foreach (var veh in db.Bikes)
            {
                Console.WriteLine(veh.Id);
                Console.WriteLine(veh.Model);
            }

            Console.WriteLine("Choose bike to delete: ");
            int bike = Convert.ToInt32(Console.ReadLine());

            var deleted = db.Bikes.FirstOrDefault(a => a.Id == bike);
            if (deleted != null)
            {
                db.Bikes.Remove(deleted);
            }
        }
        db.SaveChanges();
    }
}