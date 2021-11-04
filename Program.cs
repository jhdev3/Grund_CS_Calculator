using System;
using System.Collections.Generic; //List

namespace Calculator
{
    class Program
    {
        public static float tal1, tal2;
        static string math_operator;


        

        // TryParse framför Pars TryParse returnar 0 om det misslyckas istället för olika exceptions. så gör det enklare att hantera och gå vidare med TryParse
        static float Check_input_float(string input) //Gör om string till float. 
        {
            bool check = true;
            float f;

            do
            {
                check = float.TryParse(input, out f);

                if (check == false)
                {
                    Console.WriteLine("Felaktigt inmating av talet {0} Mata in ett talet på nytt tack :)", input);  // Cant Quit program from here, not the point either. 
                    input = Console.ReadLine();
                }

            } while (!check); //Same as the if-statment above, just using logical operators.  

            return f;
        }

        static void Get_input(string read) //Testar lika olika typer av input.
        {
            string[] input_array;
            input_array = read.Split(" "); //Vore trevligt att splita med operatorn men den sätts lite längre ner :). 


            if (input_array.Length == 3)
            {
                tal1 = Check_input_float(input_array[0]);
                math_operator = input_array[1];
                tal2 = Check_input_float(input_array[2]);

            }
            else if (input_array.Length == 4 && string.IsNullOrWhiteSpace(input_array[3])) //Råkar få med ett extra mellan slag då det blir split mellan slag, trevligare med trim => split operator osv. 
            {
                tal1 = Check_input_float(input_array[0]);
                math_operator = input_array[1];
                tal2 = Check_input_float(input_array[2]);
            }
            else //Standard input rad efter rad
            {
                tal1 = Check_input_float(input_array[0]);
                math_operator = Console.ReadLine();
                tal2 = Check_input_float(Console.ReadLine());

            }

        }


        static void Main(string[] args)
        {
            string read;
            List<Calc> history = new List<Calc>(); //Skapar en array/lista/vector



            Console.WriteLine("En fantatiskt miniräknare, där om du vill AVSLUTA matar in MARCUS \n Mata in ett tal:");

            do
            {
                read = Console.ReadLine();

                Get_input(read);

                Calc do_the_math = new Calc(tal1, tal2);

                do_the_math.Calc_operator = math_operator; //Last check point in this Calc of DOOOM.

                Console.WriteLine(do_the_math.Print_result());

                history.Add(do_the_math);

            } while (read != "MARCUS");

            Console.WriteLine("\t Kalkyl Historik: ");
            foreach (Calc calc in history)
            {
                Console.WriteLine("\t \t" + calc.Print_result());

            }

            Console.WriteLine("Hej då");

            Console.ReadKey();
        }


    }

}



/* 
 Trim-

string trim = "Blablabla balla babalab" 
string temp;
char whitespace = ' ';

foreach(char a in trim){
        if(a != whitespace)
            temp += a;
        
}
 Console.WriteLine(temp);
 
 
 
 
 
 */ 