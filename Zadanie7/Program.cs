/*Utwórz tablicę Zwierze[] z obiektami różnych zwierząt i wywołaj DajGlos() w
pętli foreach.*/

public class Zwierze
{
    public virtual void DajGlos() => Console.WriteLine("Zwierzę wydaje dźwięk");
}

class Pies : Zwierze
{
    public override void DajGlos() => Console.WriteLine("Hau hau!");
}

class Kot : Zwierze
{
    public override void DajGlos() => Console.WriteLine("Miau!");
}

class Krowa : Zwierze
{
    public override void DajGlos() => Console.WriteLine("Muu!");
}

class Swinia : Zwierze
{
    public override void DajGlos() => Console.WriteLine("Chrum!");
}

Zwierze[] zwierzeta =
{
    new Pies(),
    new Kot(),
    new Krowa(),
    new Swinia()
};

foreach (object zwierze in zwierzeta)
{
    DajGlos();
}