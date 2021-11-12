using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calculator.data
{
    class User
    {
        public string user_name;
        private ConsoleColor text_color;  //Enum typ där varje valbar färg motsvarar en siffra dvs Enum ^^
        private ConsoleColor background_color;

        private string text_file;


        public User()
        {
            this.user_name = "MARCUS";
            this.text_color = ConsoleColor.White;
            this.background_color = ConsoleColor.Black;
            this.text_file = Path_to_root()+ @"\user_config.txt";

        }

        public string User_name
        {
            get { return this.user_name; }

            set
            {
                this.user_name = value; //Gör en koll så att strängen inte inehåller whitespace
                Save_user();
            }
        }
        private void Background_color(string input) //String to console color i set så samma i get :) 
        {

            ConsoleColor consoleColor;

            if (ConsoleColor.TryParse(input, out consoleColor)) //Lika som background bara att background => Enum förklarar datatypen ConsoleColor bättre ;) //Kan göra check vid input.
            {
                this.background_color = consoleColor;
            }
            else
            {
                Console.WriteLine("Tyvärr felaktig imatning: {0}  backgrunds färgen kommer förbli: {1} ", input, this.background_color);
            }


     
        }

        public string Format_String(string test) // Format_String_for_stupid_users:)
        {



            if(test != null && test.Length > 2) //Minsta färgen = Red = 3 ^^
            {
                string make_lower = test.ToLower();
                Console.WriteLine(make_lower);

                test.ToUpper();
                Console.WriteLine(test.ToUpper());

                string make_magic = test[0] + make_lower.Substring(1);
                Console.WriteLine(make_magic);


                return make_magic;

            }
            else
                return test; //TryParse handling badstrings to :)

        }

        public void Text_color(string input)
        {
            ConsoleColor consoleColor;


            if (Enum.TryParse(input, out consoleColor)) //Lika som background => Enum förklarar datatypen ConsoleColor bättre ;) 
            {
                this.text_color = consoleColor;
                Console.WriteLine("Bra val av textfärgen: " + consoleColor);

            }
            else
            {
                  Console.WriteLine("Tyvärr felaktig imatning: {0} färgen på texten kommer förbli: {1}:)", input  ,this.text_color);
             }    
        }

        public void Update_background_text() //Uppdaterar consolen viktigt med console clear för bakgrunden :)  
        {
            Console.ForegroundColor = text_color;
            Console.BackgroundColor = background_color;
            Console.Clear();
        }
        public void Colors_Available()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor)); //Hämtar alla fårger i en colors array

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Lista för alla valbara färger: ");
         
            Console.WriteLine("\t {0}", ConsoleColor.Black);
                                                                //Utan console.clear för att det ska gå att se alla färger bra beroende på vilken backgrund användaren valt xD

            foreach (var color in colors)
            {
                if (color != ConsoleColor.Black) //Så texten syns dvs byter inte text färg till samma som backgrounds färgen :) 
                {

                    Console.ForegroundColor = color;
                    Console.WriteLine("\t {0}", color);

                }
            }
        }

        private string Path_to_root()
        {
            try
            {
                string path = Directory.GetCurrentDirectory();//samma mapp som exe/kör filen hamnar i beroende på om det är debug/realse etc som Visual Studio compilerar till  :)             }
                return path;
            }
            catch (UnauthorizedAccessException UAE)
            {
                Console.WriteLine($"Det var inte kul -> UnathiroizedAccess: {UAE.Message}");
                throw;
            }
            catch (NotSupportedException NE)
            {
                Console.WriteLine($"Det var inte kul -> NotSupported : {NE.Message}");
                throw;
            }

        }

        public void create_new_user()
        {
            Console.WriteLine("Hej dags göra calculatorn personlig :), mata in ett roligt användarnamn:  ");
            User_name = Console.ReadLine();
            Console.WriteLine("Nu har du även möjligheten att ändra text och backgrunds färg :)");
            Colors_Available();
            Console.WriteLine("Mata in en text färg från listan: ");
            Text_color(Console.ReadLine()); 
            Console.WriteLine("Mata in en backgrunds färg från listan: ");
            Background_color(Console.ReadLine());
        }


        /*  
         WriteAllText method  if document exist its writing over everything if not it creates doc and write. 
         
         */
        private void Save_user()
        {
            try
            {
                
                    string save_user = string.Format("{0}\n{1}\n{2}", User_name, this.text_color, this.background_color);
                    File.WriteAllText(text_file, save_user);
                
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("Something went wrong:");
                Console.WriteLine(e.Message);
            }
        }
       
        private ConsoleColor Parsing(string color, ConsoleColor current) 
        {
            ConsoleColor temp;

            if(ConsoleColor.TryParse(color, out temp))
            {
                return temp;
            }
            return current;
        }
        public void Read_from_file()
        {
            
            Console.WriteLine(File.Exists(text_file) ? "File exists." : "File does not exist."); //För en enkel check

            if (!File.Exists(text_file))
            {
                //Create new user and file
                create_new_user();
                //Create new file and save
                Save_user();
            }
            else
            {
                //använda using + StreamReader autmatiskt öppnar och stänger filen när den är klar => Amazing xD 

                string[] user_inputs = new string[3]; 
                int index = 0;
                try
                {
                    using (StreamReader sr = new StreamReader(text_file))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                            if (index <= 2)
                                user_inputs[index] = line;

                            index++;
                        }

                    }
                }
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }

                this.user_name = user_inputs[0];
                this.text_color = Parsing(user_inputs[1], this.text_color);//If someone stuipid changes the txt file, not using this program ^^^^^^^^
                this.background_color = Parsing(user_inputs[2], this.background_color);

                Console.WriteLine($"{User_name}   {this.text_color}   {this.background_color}");

                Console.ReadKey();

                Update_background_text();

            } 
        }

    }

    class Test_user
    {


        static void Main(string[] args)
        {

            User ny = new User();

            ny.Format_String(Console.ReadLine());
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
//string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); //Same directory
 