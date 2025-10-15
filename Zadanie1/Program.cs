//Napisz program, który pyta użytkownika o hasło, dopóki nie wpisze poprawnego
//(„admin123”).

string passwd = "admin123";

while (true)
{
    Console.WriteLine("Please enter your password: ");
    string input = Console.ReadLine();

    if (input == passwd)
    {
        Console.WriteLine("Logged successfully!");
        break;
    }
    else
    {
        Console.WriteLine("Wrong password!");
        continue;
    }
}