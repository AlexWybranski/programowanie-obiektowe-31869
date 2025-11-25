namespace Lab3_komis;

public abstract class Vehicle
{
    
    public double EngineCapacity { get; protected set; }
    private string model;
    private int year;
    
    public string Model => model;

    public int Year
    {
        get { return year; }
    }
    public Vehicle(double engineCapacity, string model, int year)
    {
        EngineCapacity = engineCapacity;
        this.model = model;
        this.year = year;
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