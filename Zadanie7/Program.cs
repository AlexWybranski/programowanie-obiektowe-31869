/*Utwórz tablicę Zwierze[] z obiektami różnych zwierząt i wywołaj DajGlos() w
pętli foreach.*/

public class Zwierze
{
    public virtual void DajGlos() => Console.WriteLine("Zwierzę wydaje dźwięk");
}

public class Pies : Zwierze
{
    public override void DajGlos() => Console.WriteLine("Hau hau!");
}

public class Kot : Zwierze
{
    public override void DajGlos() => Console.WriteLine("Miau!");
}

public class Krowa : Zwierze
{
    public override void DajGlos() => Console.WriteLine("Muu!");
}

public class Swinia : Zwierze
{
    public override void DajGlos() => Console.WriteLine("Chrum!");
}

public class Program
{
    public static void Main()
    {
        Zwierze[] zwierzeta =
        {
            new Pies(),
            new Kot(),
            new Krowa(),
            new Swinia()
        };

        foreach (var zwierze in zwierzeta)
        {
            zwierze.DajGlos();
        }
    }
}