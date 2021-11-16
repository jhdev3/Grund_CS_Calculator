using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.data
{
    class Test_user
    {


        static void Main(string[] args)
        {

            User ny = new User();
            ny.Read_from_file();

            Console.WriteLine("Mata in ett användarnamn: ");

            ny.User_name = Console.ReadLine();

            ny.Colors_Available();

            ny.Update_Colors();


            Console.ReadKey();

            //ny.Read_from_file();

            //ny.Update_background_text();

            //Console.WriteLine("Användarnamn: " + ny.User_name);

            //Console.WriteLine("Matar in nya data: ");
            //ny.Colors_Available();

            //ny.User_name = Console.ReadLine();
            //ny.Text_color(Console.ReadLine());

            //Console.ReadKey();

            //ny.Text_color(Console.ReadLine());

            //Console.ReadKey();

            //ny.Update_background_text();
            //Console.ReadKey();
            //Felsök:) File.Delete(@"C:\Users\eneby\OneDrive\Bilder\TUC\Programmering Grund\Calculator\Grund_CS_Calculator\bin\Debug\netcoreapp3.1\user_config.txt");

        }
    }

}
