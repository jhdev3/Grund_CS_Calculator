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
        public string Background_color
        {
            get { return $"{this.background_color}"; }

            set
            {
                ConsoleColor consoleColor;

                if (Enum.TryParse(value, out consoleColor))
                {
                    this.background_color = consoleColor;
                    //Console.WriteLine("Backgrunds färgen: {0} Uppdateringen lyckades  :)", consoleColor);
                    Save_user();
                }
                else
                { 
                    Console.WriteLine("BackgroundColor Error");
                }


            }
        }
        public string Text_color
        {
            get { return $"{this.text_color}"; }

            set
            {
                ConsoleColor consoleColor;

                if (ConsoleColor.TryParse(value, out consoleColor)) //Lika som background bara att background => Enum förklarar datatypen ConsoleColor bättre ;) //Kan göra check vid input.
                {
                    this.text_color = consoleColor;
                    Save_user();

                    //   Console.Clear();// För att ändra hela consolen. 
                   // Console.WriteLine("Bra val av text färg: {0}  :)", consoleColor);

                }
                else
                {
                    Console.WriteLine("Tyvärr felaktig imatning text färgen kommer förbli {0} du kan göra ett nytt försök :)", text_color);
                }

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


            foreach (var color in colors)
            {
                if (color != ConsoleColor.Black) //Så texten syns dvs byter inte text färg till samma som backgrounds färgen :) 
                {

                    Console.ForegroundColor = color;
                    Console.WriteLine("\t {0}", color);

                }
            }
        }

        /*
         * Läsa och skriv till fil, för att spara användar uppgifterna namn och färg på consolen etc
         *
         *  Finns en hel del olika sätt bestäma vart textfilen ska, enklaste är att ha den i samma map som kör/exe filen hamnar vi compilering. I visual stuido är det främs debug då jag compilerar dit
         *  taken att hämta path är för säkerhet och kontroll går att compilera till realese med ;) 
         *
           string startupPath = System.IO.Directory.GetCurrentDirectory();

            string startupPath = Environment.CurrentDirectory;
         * 
         */
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
            Console.WriteLine("Hej dags göra calculatorn personlig :), mata in ett användarnamn användarnamnet för inte innehålla något mellanslag: ");
            User_name = Console.ReadLine();
            Console.WriteLine("Nu har du även möjligheten att ändra text och backgrunds färg :)");
            Colors_Available();
            Console.WriteLine("Mata in en text färg, för att det ska bli rätt tänk på stor bokstav först: ");
            Text_color = Console.ReadLine();
            Console.WriteLine("Mata in en backgrunds färg, för att det ska bli rätt tänk på stor bokstav först: ");
            Background_color = Console.ReadLine();
        }


        /*  
         WriteAllText method  if document exist its writing over everything if not it creates doc and write. 
         
         */
        private void Save_user()
        {
            try
            {
                
                    string save_user = string.Format("{0}\n{1}\n{2}", User_name, Text_color, Background_color);
                    File.WriteAllText(text_file, save_user);
                
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("Something went wrong:");
                Console.WriteLine(e.Message);
            }
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

                /*
                 *          User_name = sr.ReadLine(); this works instead of line but dont like it
                            Text_color = sr.ReadLine();
                            Background_color = sr.ReadLine(); 
                 */
                string[] user_inputs = new string[3];
                int index = 0;
                try
                {
                    using (StreamReader sr = new StreamReader(text_file))
                    {
                        string line;

                        // Read and display lines from the file until the end of
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

                User_name = user_inputs[0];
                Text_color = user_inputs[1];
                Background_color = user_inputs[2];
                Console.ReadKey();

                Update_background_text();

            } 
        }

    }

    class Test_user
    {


        static void Main(string[] args)
        {
            Console.ReadKey();

            User ny = new User();

            //ny.Colors_Available();
            //ny.Background_color = Console.ReadLine();
            // ny.Text_color = Console.ReadLine();
            ny.Read_from_file();

            ny.Update_background_text();

            Console.WriteLine("Användarnamn: " + ny.User_name);

            Console.WriteLine("Matar in nya data: ");
            ny.Colors_Available();

            ny.User_name = Console.ReadLine();
            ny.Background_color = Console.ReadLine();
            ny.Text_color = Console.ReadLine();


            ny.Update_background_text();


            Console.WriteLine("Backgrunds_Färg: " + ny.Background_color);

            Console.ReadKey();
           //Felsök:) File.Delete(@"C:\Users\eneby\OneDrive\Bilder\TUC\Programmering Grund\Calculator\Grund_CS_Calculator\bin\Debug\netcoreapp3.1\user_config.txt");

        }
    }


}
//string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); //Same directory
 