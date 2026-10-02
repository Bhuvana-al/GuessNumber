using System.Linq.Expressions;

namespace GuessNum;

class Program
{
    
    static readonly Random rnd = new();
    static int randomNumber = rnd.Next(1, 50);
    
    const int MAX_ATTEMPTS = 5;
    static int attempts = 1;     
    static void Main()
    {
        //Console.WriteLine($"Generated random number: {randomNumber}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Välkommen till spelat Gissa numret");
        Console.WriteLine("För att avbryta spelat tryck på tangetan x");
        Console.WriteLine($"Du har högst {MAX_ATTEMPTS} försök på dig att gissa talet.");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Spelomgång: {0}", attempts);
        Console.WriteLine("Applikationen har genererat ett heltal mellan 1 och 50. Gissa talet!");
        Console.ResetColor();

        int inputNumber = ReadNumber();

        while ((inputNumber != randomNumber) && (attempts<5))
        {
            attempts++;
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Fel! Gissa talet igen!");
            Console.WriteLine("Spelomgång: {0}", attempts);
            Console.ResetColor();
            inputNumber = ReadNumber();
        }
        if (inputNumber == randomNumber)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Du gissade rätt! Bra jobbet!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Fel! Du har försökt maxantalet gånger. Bra försök!");
            Console.ResetColor();
        }
    }

    static int ReadNumber()
    {
        int inputNum = 0;
        
        try
        {
            var inputValue = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(inputValue))
            {
                throw new Exception("Du måste ange ett heltalsvärde");
            }
            if (inputValue != "x")
            {
                inputNum = int.Parse(inputValue);
                if (inputNum < 1 || inputNum > 50)
                {
                    throw new Exception($"{inputNum} är inte ett heltal mellan 1 och 50.");
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }
        catch(FormatException ex)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
        catch(Exception ex)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }

        return inputNum;       
    }
}
