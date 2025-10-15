// Poproś użytkownika o podanie liczby większej od zera. Jeśli poda liczbę ujemną
// lub 0 — zapytaj ponownie.
int number;
string tmp;

do
{
    Console.WriteLine("Enter a number larger than 0: ");
    tmp = Console.ReadLine();
    number = int.Parse(tmp);
} while (number <= 0);