/*Dodaj metodę Wyplata(double kwota), która wypłaca pieniądze tylko jeśli saldo
jest wystarczające.*/

public class KontoBankowe
{
    private double saldo;
    public double PobierzSaldo() { return saldo; }
   
    public void Wplata(double kwota) { saldo += kwota; }
    public void Wyplata(double kwota)
    {
        if (kwota > saldo)
        {
            Console.WriteLine("Niewystarczające środki na koncie!");
        }
        else
        {
            saldo -= kwota;
        }
    }
}

