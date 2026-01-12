namespace Projekt.Items;

public abstract class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string ValueOfItem { get; set; }
}

public class Console : Item
{
    public string Condition { get; set; }
}

public class Accessory : Item
{
    public string Platform { get; set; }
    public string Colour { get; set; }
}

public class Game : Item
{
    public string Platform { get; set; }
    public string Edition {get; set;}
}