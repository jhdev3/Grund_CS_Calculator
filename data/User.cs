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

        public string User_name//enda kravet inga mellanslag allowed ;)
        {
            get { return this.user_name; }

            set
            {
                if (Check_whitespace(value))
                {
                    this.user_name = value; //Gör en koll så att strängen inte inehåller whitespace
                    Console.WriteLine("Ditt användarnamn är nu: {0} ", this.user_name);

                    Save_user();
                }
                else
                    Console.WriteLine("Dåligt val av användarnamn {0} \n det får inte innehålla whitespaces :(  \n ditt användarnamn är: {1} ", value, this.user_name);
            }
        }
        private bool Check_whitespace(string to_beC)
        {
            char a;
            char whitespace = ' ';
            if (to_beC == null || to_beC == string.Empty) // kan använda string.IsNullOrEmpty(to_beC) etc men vill använda for loop:)
                return false;
            
            for(int i=0;i < to_beC.Length; i++)
            {
                a = to_beC[i];
                if (a == whitespace)
                    return false;
            }
            return true;


        }
        private void Background_color(string input) //String to console color i set så samma i get :) 
        {

            ConsoleColor consoleColor;
            input = String_for_ConsoleColor(input);

            if (ConsoleColor.TryParse(input, out consoleColor)) //Lika som background bara att background => Enum förklarar datatypen ConsoleColor bättre ;) //Kan göra check vid input.
            {
                this.background_color = consoleColor;
            }
            else
            {
                Console.WriteLine("Tyvärr felaktig imatning: {0}  backgrunds färgen kommer förbli: {1} ", input, this.background_color);
            }
        }


        /* 
         
            Bara första bokstaven görs till upper
            DarkRed etc Colors är CaseSensetive av en anledning :) 
        Går att utveckla till att genom att jämföra hela Color listan=> lowercase och sedan göra de ändringar som behövs.
         
         
         */
        public string String_for_ConsoleColor(string test) // en liten hjälp till använderan så en stor/liten bokstav inte orsakr irrterande fel. 
        {

            if(test != null && test.Length > 2) //Minsta färgen = Red = 3 ^^
            {
                string save_test = test; 
                test.ToUpper();
                string make_magic = test[0] + save_test.Substring(1);
                return make_magic;
            }
            else
                return test; //TryParse hanterar felaktiga färger och dåliga strängar också :)

        }

        private void Text_color(string input)
        {
            ConsoleColor consoleColor;

            input = String_for_ConsoleColor(input);

            if (Enum.TryParse(input, out consoleColor)) //Lika som background => Enum förklarar datatypen ConsoleColor bättre ;) 
            {
                this.text_color = consoleColor;
               // Console.WriteLine("Bra val av textfärgen: " + consoleColor); om man vill se vad som händer checking :) 

            }
            else
            {
                  Console.WriteLine("Tyvärr felaktig imatning: {0} färgen på texten kommer förbli: {1}:)", input  ,this.text_color);
             }    
        }

        public void Update_background_text() //Uppdaterar consolen viktigt med console clear för bakgrunden :)  
        {
            Console.WriteLine("Text och backgrundsfärg är nu uppdaterade slå på en valfri tangent för att gå vidare xD: ");
            Console.ReadKey();
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

            Console.ForegroundColor = this.text_color;
            Console.BackgroundColor = this.background_color;


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
            string t_color = Console.ReadLine();
            Console.WriteLine("Mata in en backgrunds färg från listan: ");
            string bg_color = Console.ReadLine();

            if (bg_color != t_color)
            {
                Background_color(bg_color);
                Text_color(t_color);
            }
            else
            {
                Console.WriteLine("Backgrunds färgen och text-färgen får inte vara samma \n går att uppdatera, just nu är: \n backgrundsfärg: {0} \n textfärg: {1}",this.background_color, this.text_color);
            }
        }

        public void Update_Colors()
        {
            Console.WriteLine("Mata in en ny textfärg: " );
            string t_color = Console.ReadLine();
            Console.WriteLine("Mata in en ny backgrundsfärg: ");
            string bg_color = Console.ReadLine();
            if (bg_color != t_color)
            {
                Background_color(bg_color);
                Text_color(t_color);
                Save_user();
                Update_background_text();
            }
            else
                Console.WriteLine("Felaktigt inmatting eller val av färger din klant försök igen om du vill att det ska ändras \n PS samma backgrundsfärg och textfärg fungerar inte  ");
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
                           // Console.WriteLine(line); Just får checking :)
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
                Console.ForegroundColor = this.text_color;
                Console.BackgroundColor = this.background_color;
                Console.Clear();

            } 
        }

        public void Reset_colors()
        {
            this.background_color = ConsoleColor.Black;
            this.text_color = ConsoleColor.White;
            Console.ForegroundColor = this.text_color;
            Console.BackgroundColor = this.background_color;
            Console.Clear();
            Save_user();
            Console.WriteLine("Färgerna är uppdaterade och tillbaka till Default :)");
        }

    }

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
//string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); //Same directory
 