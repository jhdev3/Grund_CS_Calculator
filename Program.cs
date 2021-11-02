using System;
namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            float tal1=0, tal2=0; //Lägga som private/public i klass kanske
            string calc_operator;
            bool run = true;


           
            do
            {
                Console.WriteLine("Mata in ett tal: \n");
                tal1 = float.Parse(Console.ReadLine()); //Gör om string till float. 
                calc_operator = Console.ReadLine();
                tal2 = float.Parse(Console.ReadLine());

                switch (calc_operator)
                {
                    case "+":
                        Console.WriteLine("{0} + {1} = {2} ", tal1, tal2, tal1 + tal2);
                        break;
                    case "-":
                        Console.WriteLine("{0} - {1} = {2} ", tal1, tal2, tal1 - tal2);
                        break;
                    case "*":
                        Console.WriteLine("{0} * {1} = {2} ", tal1, tal2, tal1 * tal2);
                        break;
                    case "/":
                        Console.WriteLine("{0} / {1} = {2} ", tal1, tal2, tal1 / tal2);
                        break;
                    default:
                        Console.WriteLine("Felaktig inmanting din dummer");
                        run = false;
                        break;

                }
            } while (run);


            Console.ReadKey();
        }
    }
}


/* 
 
Good to know: 

Float - 7 digits (32 bit)

Double-15-16 digits (64 bit)

Decimal -28-29 significant digits (128 bit)
 

Metoder: 
 public, protected eller private = OOP  kan sättas framör static, till console applications.  

Lamba metod = kort function/metod    func("inparametrar) x, y => "vad de utför" 

Var = typ variabel skapa en local variabel utan att ge dem en explicit typ, String, int, double etc. 

            
            exempel på writeline. 
            Console.WriteLine("Hello World!" + (tal1,  tal2));

            Console.WriteLine("Hello World!\t{1} och {2} är totalt {0} ", tal1 + tal2, tal1, tal2 );



 
 */ 