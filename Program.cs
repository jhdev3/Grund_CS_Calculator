using System;
using System.Collections.Generic; //List
using Calculator.data;

namespace Calculator
{
    class Program
    {
        public static float tal1, tal2;  //Räcker med static där, i Prgoram classen kul att se vad som händer med olika deklaringar. 
        static string math_operator;
        static User GetUser = new User();

        // TryParse framför Pars TryParse returnar 0 om det misslyckas istället för olika exceptions. så gör det enklare att hantera och gå vidare med TryParse
       
     
        static float Check_input_float(string input) //Gör om string till float. 
        {
            bool check_input = true;
            float f;

            do
            {
                check_input = float.TryParse(input, out f);

                if (check_input == false)
                {
                    Console.WriteLine("Det här: {0} är inget tal!!!  Försök igen :)", input);  // Cant Quit program from here, not the point either. 
                    input = Console.ReadLine();
                }

            } while (!check_input); //Same as the if-statment above, just using logical operators.  

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

        static bool Get_input(string read) //Testar lika olika typer av input.
        {
            if (read == GetUser.User_name)
                return false;
            string[] input_array = Trim_and_stuff(read); //Avsulta på en rad sök efter ordet annars trim men varför ? 

            if (input_array[1] != null)
            {
                tal1 = Check_input_float(input_array[0]);
                tal2 = Check_input_float(input_array[1]);
                return true;

            }     
            else //Standard input rad efter rad
            {
                tal1 = Check_input_float(input_array[0]);
                math_operator = Console.ReadLine(); // Avsluta med hjälp av operatorn 
                if (math_operator == GetUser.User_name) 
                    return false;
                tal2 = Check_input_float(Console.ReadLine());
                return true;

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
            List<Calc> history = new List<Calc>(); //Skapar en array
            GetUser.Read_from_file();
            Console.WriteLine("Hej {0} \n Det är är din personliga kalkylator skriv hjälp för att se alla kommandon och instruktioner {0}", GetUser.User_name);

            do
            {
                Console.WriteLine("Do some math");
                read = Console.ReadLine();

                switch (read)
                {
                    case "åter":
                        GetUser.Reset_colors();
                        break;
                    case "färg":
                        GetUser.Colors_Available();
                        GetUser.Update_Colors();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "anv":
                        Console.WriteLine("Ange ett nytt användarnamn: ");
                        GetUser.User_name = Console.ReadLine();
                        break;
                    case "hjälp":
                        Console.WriteLine("Avsluta genom att skriva ditt användarnamn: {0} ", GetUser.User_name);
                        Console.WriteLine("Mata in det som du vill räkna ut på en rad eller en rad i taget det spelar ingen roll");
                        Console.WriteLine("Kommer säga till när det blir fel xD ");
                        Console.WriteLine("Utför enbart en matematisk operation => absolut bästa kvalite på uträkningen xD");

                        Console.WriteLine("Kommandon: " );
                        Console.WriteLine("historik <--------skriver ut historiken av uträkningarna ");
                        Console.WriteLine("clear   <--------rensar skärmen");
                        Console.WriteLine("färg    <--------ändra backgrund + text färg");
                        Console.WriteLine("anv    <--------ändra användarnamn");
                        Console.WriteLine("åter    <--------ändra tillbaka färgerna till default");
                        break;
                    case "historik":
                        History(history);
                        break;
                    default:
                       
                        if (Get_input(read))
                        {
                            Calc do_the_math = new Calc(tal1, tal2);

                            do_the_math.Calc_operator = math_operator; //Last check point in this Calc of DOOOM.

                            Console.WriteLine(do_the_math.Print_result());

                            history.Add(do_the_math);
                        }
                        else
                        {
                            
                            read = GetUser.User_name;
                        }
                        break;

                }

            } while (read != GetUser.User_name);

            Console.WriteLine(" \t  Hej då {0} \n", GetUser.User_name);

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