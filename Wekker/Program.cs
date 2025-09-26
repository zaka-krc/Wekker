using System;
using System.Threading;

delegate void Alarmtype();

class Program
{
    static Alarmtype alarmtype = new Alarmtype(dummy);
    static Timer timer = new Timer(Start);
    static int seconden;
    static int sluimertijd;
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
                            alarmtype += Geluid;
                            break;
                        case '3':
                            alarmtype += Knipperen;
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
                            alarmtype -= Geluid;
                            break;
                        case '3':
                            alarmtype -= Knipperen;
                            break;
                    }
                    break;
                case '3':
                    Console.Write("Na hoeveel seconden gaat de wekker weer af?");
                    sluimertijd = int.Parse(Console.ReadLine());
                    timer.Change(seconden * 1000, sluimertijd * 1000); //*1000 omzetten naar milliseconden
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

    static void Geluid()
    {
        Console.Beep(659, 250); // E5
        Console.Beep(659, 250); // E5
        Console.Beep(698, 250); // F5
        Console.Beep(784, 250); // G5
        Console.Beep(784, 250); // G5
        Console.Beep(698, 250); // F5
        Console.Beep(659, 250); // E5
        Console.Beep(587, 250); // D5
        Console.Beep(523, 250); // C5
        Console.Beep(523, 250); // C5
        Console.Beep(587, 250); // D5
        Console.Beep(659, 250); // E5
        Console.Beep(659, 375); // E5
        Console.Beep(587, 125); // D5
        Console.Beep(587, 500); // D5
        //dit is het Eine kleine Nachtmusik van Mozart
    }

    static void Knipperen()
    {
        int cursorTop = Console.CursorTop;
        for (int i = 0; i < 5; i++)
        {
            Console.Write("\rOpstaan!!"); // \r zet cursor terug naar begin van de lijn
            Thread.Sleep(300);
            Console.Write("\r         "); // Overschrijf met spaties
            Thread.Sleep(300);
        }
    }

    static void dummy() { }//dit is een lege methode zodat de delegate altijd iets aanroept
}