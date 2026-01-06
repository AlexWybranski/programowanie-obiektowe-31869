namespace Lab3_komis;

public abstract class Vehicle
{
    public int Id { get; protected set; }
    public double EngineCapacity { get; set; }
    public string Model { get ; set; }
    public int Year { get; set; }
    public Vehicle(double engineCapacity, string model, int year)
    {
        EngineCapacity = engineCapacity;
        Model = model;
        Year = year;
    }

    public virtual void Start()
    {
        Console.WriteLine("Vehicle started");
    }

    public void Stop()
    {
        Console.WriteLine("Vehicle stopped");
    }
    
    public abstract void Test();
}