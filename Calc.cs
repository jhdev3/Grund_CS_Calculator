using System;



namespace Calculator // Same namespace = as Program.cs
{
    public class Calc
    {
        public float num1;  // float "spara minne" 32 bit/4bytes, Minsta värde 1.175494351 E - 38 Högsta värde: 3.402823466 E + 38   precision: någonstanns mellan 7 decimaler. =>  24 bits of precision :)
        public float num2; // Borde vara tillräckligt, men ska vi åka till Mars ändrar vi till Double. ;)
        private float result;
        private string calc_operator;

        public Calc()
        {
            this.num1 = 0;
            this.num2 = 0;
            this.result = 0;
            this.calc_operator = "Give operator";
        }
        public Calc(float one, float two)
        {
            this.num1 = one;
            this.num2 = two;
            this.result = 0;
            this.calc_operator = string.Empty;
        }

        //public float Num1
        //{
        //    get { return this.num1; }

        //    set
        //    {
        //        this.num1 = value;
        //    }
        //} //Testing get / set

        //public float Num2
        //{
        //    get { return this.num2; }

        //    set
        //    {
        //        this.num2 = value;
        //    }

        //}
    

    public string Calc_operator 
        {
            get { return this.calc_operator; }

            set
            {
                this.calc_operator = value;
                //Time to check this value.
                string check_value = Print_result();

                while (check_value == "Error:CO555")
                {
                    Console.WriteLine(" {0} är en felaktig operator använd enbart + -*eller / så får du även ett resultat  :) ", this.calc_operator);

                    this.calc_operator = Console.ReadLine();

                    this.calc_operator = this.calc_operator.Trim();

                    check_value = Print_result();
                }
                    
            }

        }

        public string Print_result()
        {
            string output_r = " "; 
            switch (calc_operator)
            {
                case "+":
                    result = num1 + num2;
                    output_r = $"{num1} {calc_operator} {num2} = {result}";
                    break;
                case "-":
                    result = num1 - num2;
                    output_r = $"{num1} {calc_operator} {num2} = {result}";
                    break;
                case "*":
                    result = num1 * num2;
                    output_r = $"{num1} {calc_operator} {num2} = {result}";
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        output_r = $"{num1} {calc_operator} {num2} = {result}";
                    }
                    else
                    {
                        output_r = string.Format("{0} / {1} = To Infinity and beyond xD ", num1, num2); // Testa en annan variant :) 
                    }
                    break;
                default:
                    output_r = "Error:CO555"; //Felaktig operator
                    break;
            }
            return output_r;

        }

    }
}











/*   
 *   Float/double dont throw any overflows exceptions :) 
 *   try
                    {
                        unchecked { 
                        result = num1 * num2;
                        }
                        checked
                        {
                            result = num1 * num2;

                        }
                        // Placera kod här som KAN ge ett oväntat undantag
                    }
                    catch (Exception )
                    {
                        Console.WriteLine("TESTA EXECPTION");
                    } */