namespace Lab3_komis;

public class SearchBy
{
    public static void Year()
    {
        Console.Write("Enter year: ");
        var success = Int32.TryParse(Console.ReadLine(), out int year);
        if (!success)
        {
            Console.WriteLine("Invalid year");
            Year();
            return;
        }
        var vehicles = Database.Vehicles.Where(veh => veh.Year == year);

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
    
    public static void Model()
    {
        Console.Write("Enter model: ");
        string? input =  Console.ReadLine();
        if (String.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid model");
            Model();
            return;
        }
        input = input.ToLower().Trim();
    
        var vehicles = Database.Vehicles.Where(veh => veh.Model.ToLower() == input);

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

    public static void EngineCapacity()
    {
        Console.Write("Enter engine capacity: ");
        var success = double.TryParse(Console.ReadLine(), out double engineCapacity);
        if (!success)
        {
            Console.WriteLine("Invalid year");
            EngineCapacity();
            return;
        }
        var vehicles = Database.Vehicles.Where(veh => veh.EngineCapacity == engineCapacity);
    
    
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
}