namespace Lab3_komis;

public abstract class Vehicle
{
    
    public double EngineCapacity { get; protected set; }
    private string _model;
    private int _year;
    
    public string Model => _model;

    public int Year
    {
        get { return _year; }
    }
    public Vehicle(double engineCapacity, string model, int year)
    {
        EngineCapacity = engineCapacity;
        this._model = model;
        this._year = year;
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