using System;
using System.Threading;

delegate void Alarmtype();

class Program
{
    static Alarmtype alarmtype = new Alarmtype(dummy);
    static Timer timer = new Timer(Start);
    static int seconden = 20;
    static int sluimertijd = 5;
    static int keuze;

    static void Main()
    {
        do
        {
            Console.WriteLine("Kies uit: ");
            Console.WriteLine("1 Kies wekkertype (toevoegen)");
            Console.WriteLine("2 Verwijder een wekkertype");
            Console.WriteLine("3 Zet de sluimertijd op");
            Console.WriteLine("4 Zet de tijd waarop het alarm moet afgaan");
            Console.WriteLine("5 Stop de wekker");
            keuze = Console.Read();
            Console.ReadLine();

            switch (keuze)
            {
                case '1':
                    Console.WriteLine("Alarmtype toevoegen:");
                    Console.WriteLine("1 Tekst");
                    Console.WriteLine("2 Geluid");
                    Console.WriteLine("3 Knipperen");
                    int alarmAdd = Console.Read();
                    Console.ReadLine();
                    switch (alarmAdd)
                    {
                        case '1':
                            alarmtype += ZendTekst;
                            break;
                        case '2':
                            alarmtype += MaakLawaai;
                            break;
                        case '3':
                            alarmtype += KnipperLichten;
                            break;
                    }
                    break;
                case '2':
                    Console.WriteLine("Alarmtype verwijderen:");
                    Console.WriteLine("1 Tekst");
                    Console.WriteLine("2 Geluid");
                    Console.WriteLine("3 Knipperen");
                    int alarmRemove = Console.Read();
                    Console.ReadLine();
                    switch (alarmRemove)
                    {
                        case '1':
                            alarmtype -= ZendTekst;
                            break;
                        case '2':
                            alarmtype -= MaakLawaai;
                            break;
                        case '3':
                            alarmtype -= KnipperLichten;
                            break;
                    }
                    break;
                case '3':
                    Console.Write("Na hoeveel seconden gaat de wekker weer af?");
                    sluimertijd = int.Parse(Console.ReadLine());
                    timer.Change(seconden * 1000, sluimertijd * 1000);
                    break;
                case '4':
                    Console.Write("Na hoeveel seconden moet het alarm afgaan? ");
                    seconden = int.Parse(Console.ReadLine());
                    timer.Change(seconden * 1000, sluimertijd * 1000);
                    break;
                case '5':
                    timer.Dispose();
                    break;
            }
        } while (keuze != '5');
    }

    static void Start(object state)
    {
        alarmtype();
    }

    static void ZendTekst()
    {
        Console.WriteLine("Opstaan!!");
    }

    static void MaakLawaai()
    {
        Console.Beep();
    }

    static void KnipperLichten()
    {
        Console.WriteLine("Knipperen");
    }

    static void dummy() { }
}