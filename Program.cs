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
                    Console.WriteLine("Felaktigt inmating, Mata in ett talet på nytt tack :)");  // Cant Quit program from here, not the point either. 
                    input = Console.ReadLine();
                }

            } while (!check); //Same as the if-statment above, just using logical operators.  

            return f;
        }

        static void Get_input(string read)
        {
            string[] input_array;
            input_array = read.Split(" ");


            // Console.WriteLine("Array-Length: {0}", input_array.Length); Felsökning 

            if (input_array.Length == 3)
            {
                tal1 = Check_input_float(input_array[0]);
                math_operator = input_array[1];
                tal2 = Check_input_float(input_array[2]);
                Console.WriteLine("IF-Statment-Complete");

            }
            else if (input_array.Length == 4 && string.IsNullOrWhiteSpace(input_array[3]))
            {
                tal1 = Check_input_float(input_array[0]);
                math_operator = input_array[1];
                tal2 = Check_input_float(input_array[2]);
                Console.WriteLine("IF-Statment-Else-ife-Complete");
            }
            else
            {
                tal1 = Check_input_float(input_array[0]);
                math_operator = Console.ReadLine();
                tal2 = Check_input_float(Console.ReadLine());
                Console.WriteLine("Else-statment-Complete");

            }

            //foreach (string t in input_array)
            //{

            //    Console.WriteLine("Your input: {0}", t);

            //}

        }


        static void Main(string[] args)
        {
            string read;
            List<Calc> history = new List<Calc>(); //Skapar en array/lista/vector

            Console.WriteLine("En fantatiskt miniräknare, där om du vill AVSLUTA matar in MARKUS \n Mata in ett tal:");

            do
            {

                read = Console.ReadLine();
                if (read == "MARCUS")
                {
                    break;
                }

                Get_input(read);


                Calc do_the_math = new Calc(tal1, tal2, math_operator);
                do_the_math.Print_resultat();
                history.Add(do_the_math);



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


