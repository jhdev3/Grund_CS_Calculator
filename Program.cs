using System;
using System.Collections.Generic; //List

namespace Calculator
{
    class Program
    {
        public static float tal1, tal2;  //Räcker med static där, i Prgoram classen kul att se vad som händer med olika deklaringar. 
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
                    Console.WriteLine("Det här: {0} är inget tal!!!  Försök igen :)", input);  // Cant Quit program from here, not the point either. 
                    input = Console.ReadLine();
                }

            } while (!check); //Same as the if-statment above, just using logical operators.  

            return f;
        }

        static string[] Trim_and_stuff(string trim)
        {
            string temp = string.Empty;
            string[] temp_array = new string[2];  //What i want :) 
            int array_index = 0;
            char whitespce = ' ';

            foreach (char a in trim)
            {              
                if(array_index >= 2) //The magic Array ;)
                    break;

                switch (a)
                {
                    case '+':
                        math_operator = $"{a}";
                        temp_array[array_index] += temp;
                        temp = string.Empty;
                        ++array_index;
                        break;
                    case '-':
                        math_operator = $"{a}";
                        temp_array[array_index] += temp;
                        temp = string.Empty;
                        ++array_index; 
                        break;
                    case '*':
                        math_operator = $"{a}";
                        temp_array[array_index] += temp;
                        temp = string.Empty;
                        ++array_index; 
                        break;
                    case '/':
                        math_operator = $"{a}";
                        temp_array[array_index] += temp;
                        temp = string.Empty;
                        ++array_index; 
                        break;
                    default:
                        if(a != whitespce)
                               temp += a;
                        break;
                }

            }
            if(temp != string.Empty) //En rad eller bara sista talet i raden. 
                temp_array[array_index] += temp;
           
            //foreach(string a in temp_array)
            //{
            //    Console.WriteLine(a);
            //}

            return temp_array;
        }

        static void Get_input(string read) //Testar lika olika typer av input.
        {
            string[] input_array = Trim_and_stuff(read); //Avsulta på en rad sök efter ordet annars trim men varför ? 

            if (input_array[1] != null)
            {
                tal1 = Check_input_float(input_array[0]);
                tal2 = Check_input_float(input_array[1]);

            }     
            else //Standard input rad efter rad
            {
                tal1 = Check_input_float(input_array[0]);
                math_operator = Console.ReadLine(); // Avsluta på Marcus behöver en extra kontroll efter input
                if(math_operator != "MARCUS") //Vill man avsulta 
                       tal2 = Check_input_float(Console.ReadLine());

            }
        }

        static void History(List<Calc> h)
        {
            Console.WriteLine("\t Kalkyl Historik: ");
            foreach (Calc calc in h)
            {
                Console.WriteLine("\t \t" + calc.Print_result());

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


                switch (read)
                {
                    case "MARCUS":  
                        Console.WriteLine(" \t  Hej då \n");
                        break;
                    case "help":
                        Console.WriteLine("Avsluta genom att skriva ditt användarnamn: ");
                        Console.WriteLine("Mata in det som du vill räkna ut på en rad eller en rad i taget");
                        Console.WriteLine("Skriv historik, för att få se calculatorns historik" );

                        break;
                    case "historik":
                        History(history);
                        break;
                    default:
                        Get_input(read);
                        if (math_operator == "MARCUS")
                            read = "MARCUS";

                        else
                        {
                            Calc do_the_math = new Calc(tal1, tal2);

                            do_the_math.Calc_operator = math_operator; //Last check point in this Calc of DOOOM.

                            Console.WriteLine(do_the_math.Print_result());

                            history.Add(do_the_math);
                        }
                        break;

                }

            } while (read != "MARCUS");


            History(history);

            Console.ReadKey();
        }


    }

}



/* 
 Trim-version 1

string trim = "Blablabla balla babalab" 
string temp;
char whitespace = ' ';

foreach(char a in trim){
        if(a != whitespace)
            temp += a;
        
}
 Console.WriteLine(temp);
 
 
 
 
 
 */ 