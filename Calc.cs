using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator // Same namespace = call ing main
{
    public class Calc
    {
        private float num1;
        private float num2;
        private float result;
        private string calc_operator;

        public Calc()
        {
            this.num1 = 0;
            this.num2 = 0;
            this.result = 0;
            this.calc_operator = "Give operator";
        }
        public Calc(float one, float two, string cal)
        {
            this.num1 = one;
            this.num2 = two;
            this.calc_operator = cal;
        }   

        public float Num1
        {
            get { return this.num1; }

            set
            {
                this.num1 = value;
            }
        } //Testing get / set

        public float Num2
        {
            get { return this.num2; }

            set
            {
                this.num2 = value;
            }

        }

        public string Calc_operator
        {
            get { return this.calc_operator; }

            set
            {
                this.calc_operator = value;

            }

        }


        public void Print_resultat()
        {
            switch (calc_operator)
            {
                case "+":
                    result = num1 + num2;
                    Console.WriteLine(result);

                    break;
                case "-":
                    result = num1 - num2;
                    Console.WriteLine(result);

                    break;
                case "*":
                    result = num1 * num2;
                    Console.WriteLine(result);

                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        Console.WriteLine(result);

                    }
                    else
                    {
                        Console.WriteLine("{0} / {1} = To Infinity and beyond xD ", num1, num2);

                    }
                    break;
                default:
                    Console.WriteLine("Error input values etc");
                    break;

            }
        }

    }
}
