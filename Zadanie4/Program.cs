public class Person
{
    public string name;
    public int age;

    public void IntroduceYourself()
    {
        Console.WriteLine($"Hi, my name is {name} and i'm {age} years old!");
    }
    
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}

class Program
{
    static void Main()
    {
        Person p1 = new Person("Alex" , 23);
        Person p2 = new Person("Bob", 28);
        Person p3 = new Person("John", 24);
        Person p4 = new Person("Jane", 30);
        Person p5 = new Person("Cthulhu", 782);
        
        p1.IntroduceYourself();
        p2.IntroduceYourself();
        p3.IntroduceYourself();
        p4.IntroduceYourself();
        p5.IntroduceYourself();
    }
}