using Calculator.user;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.user
{
    class User
    {
        public string user_name;
        private ConsoleColor text_color;
        private ConsoleColor background_color;
        //private ConsoleColor consoleColor; use this instead of string :) 



        public User()
        {
            this.user_name = "MARCUS";
            this.text_color = ConsoleColor.White;
            this.background_color = ConsoleColor.Black;
            
        }

        public string Background_color
        {
            get { return $"{this.background_color}"; }

            set
            {
                ConsoleColor consoleColor;

                if (Enum.TryParse(value, out consoleColor))
                {
                    Console.BackgroundColor = consoleColor;
                    this.background_color = consoleColor;
                    Console.Clear();// För att ändra hela consolen. 
                    Console.WriteLine("BackgroundColor Updaterad bra :)");
                }
                else
                    Console.WriteLine("BackgroundColor Error");


            }
        }
        public string Text_color
        {
            get { return $"{this.text_color}"; }

            set
            {
                ConsoleColor consoleColor;

                if (Enum.TryParse(value, out consoleColor))
                {
                    Console.ForegroundColor = consoleColor;
                    this.text_color = consoleColor;
                    Console.Clear();

                    //   Console.Clear();// För att ändra hela consolen. 
                    Console.WriteLine("BackgroundColor Updaterad bra :)");
                }
                else
                    Console.WriteLine("BackgroundColor Error");

            }
        }

        public void Colors_Available()
        {
            ConsoleColor [] colors = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor)); //Hämtar alla fårger i en color array

            Console.WriteLine("List of all colors available: ");

            foreach(var color in colors)
            {
                if (color == background_color) //Så texten syns = byter inte text färg till samma som backgrounds färgen :) 
                {
                    Console.WriteLine("\t {0}", color);
                }
                else
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine("\t {0}", color);
                }
            }




    }



}

        //public void Set_Colors()
        //{
        //    ConsoleColor consoleColor;
        //    if (Enum.TryParse(text_color, out consoleColor))
        //        Console.ForegroundColor = consoleColor;

        //    if (Enum.TryParse(background_color, out consoleColor))
        //        Console.BackgroundColor = consoleColor;


        //    Console.Clear();
        //}



    class test
    {
        //static void Set_Colors(User n)
        //{
        //    ConsoleColor consoleColor;
        //    if (Enum.TryParse(n.text_color, out consoleColor))
        //        Console.ForegroundColor = consoleColor;
        //    else
        //        Console.WriteLine("FelForeground");
        //    if (Enum.TryParse(n.Background_color, out consoleColor))
        //        Console.BackgroundColor = consoleColor;
        //    else
        //        Console.WriteLine("BackgroundColor");

        //    Console.Clear();
        //}
        static void Main(string[] args)
        {

            User ny = new User();

            ny.Colors_Available();
            //ny.Background_color = Console.ReadLine();
            
            Console.WriteLine("Backgrunds_Färg: " + ny.Background_color);
           
           // Set_Colors(ny);

            Console.WriteLine("Ny background färg + text färg :)  ");



            Console.ReadKey();

        }
    }


}
