string passwd = "admin123";

while (true)
{
    Console.WriteLine("Please enter your password: ");
    string input = Console.ReadLine();

    if (input == passwd)
    {
        break;
    }
    else
    {
        continue;
    }
}