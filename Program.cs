using System;
using System.Collections.Generic; //List

namespace Calculator
{
    class Program
    {
        // TryParse framför Pars TryParse returnar 0 om det misslyckas istället för Excetions så gör det enklare att hantera och gå vidare med TryParse
        private static float check_input_float(string input) //Gör om string till float. 
        {
                bool check = true;
                float f;

                do
                {
                    check = float.TryParse(input, out f);

                    if (check == false)
                    {
                        Console.WriteLine("Felaktigt inmating, Mata in ett talet på nytt tack :)");  // Cant Quit program from here, not the point either. 
                        input = Console.ReadLine();
                    }

                } while (!check); //Same as the if-statment above, just using logical operators.  
            
                return f;
           }
           
        static void Main(string[] args)
        {
            float tal1=0, tal2=0, resultat; //Lägga som private/public i klass kanske för OOP standard = 0
            string read;
            List<Calc>  history = new List<Calc>(); //Skapar en array/lista/vector
            Calc do_the_math = new Calc();

            Console.WriteLine("En fantatiskt miniräknare, där om du vill AVSLUTA matar in MARKUS \n Mata in ett tal:");

            do
            {

                read = Console.ReadLine();
                if (read == "MARCUS")
                {
                    break;
                }
                tal1 = check_input_float(read);
                do_the_math.Num1 = tal1;

                read = Console.ReadLine();
                if (read == "MARCUS")
                {
                    break;
                }
                do_the_math.Calc_operator = read;

                read = Console.ReadLine();
                if (read =="MARCUS") {
                    break;
                }
                tal2 = check_input_float(read);
                do_the_math.Num2 = tal2;

                do_the_math.Print_resultat();

                history.Add(new Calc(tal1,tal2,do_the_math.Calc_operator));


            } while (read != "MARCUS");
           
            Console.WriteLine("Kalkyl Historik: ");
            foreach (Calc calc in history)
            {
                calc.Print_resultat();

            }
            Console.WriteLine("Hej då");
            
            Console.ReadKey();
        }

       
    }

}


