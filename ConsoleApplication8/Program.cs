using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    public delegate string myDelegate(string value);

    class Account
    {
        private string deposite;
        public event myDelegate ValueEntered;
        public string Deposite
        {
            set
            {
                deposite = value;
                ValueEntered(deposite);
            }
        }

        public string Result(int value)
        {
            if (value <= 500)
            {
                return "You got";
            }
            else
            {
                return "Congratulation you reach your gool!!";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            Account yousif = new Account();
            yousif.ValueEntered += delegate (string value)
            {
                result += Int32.Parse(value);
                return result.ToString();
            };

            string str;
            do
            {
                str = ConvInput("Enter the value").ToString();
                if (!str.Equals("exit", StringComparison.OrdinalIgnoreCase)&&(!str.Equals("0")))
                {
                    yousif.Deposite = str;
                    Console.WriteLine(yousif.Result(result) + "\t {0}", result);
                }
            } while (!str.Equals("exit", StringComparison.OrdinalIgnoreCase)&&(!str.Equals("0")));

            Console.WriteLine("\nGoodbye!");
            Console.ReadLine();
        }
        private static int ConvInput(string lable)
        {
            Console.WriteLine(lable);
            string input;
            int output;
            do
            {
                input = Console.ReadLine();
                if (Int32.TryParse(input,out output))
                {
                    return output;
                }
                else if (input.Equals("exit",StringComparison.OrdinalIgnoreCase))
                {
                    return output = 0;
                }
                else
                {
                    Console.WriteLine("Please enter a Number!!");
                }
            } while (true);
        }
    }
}
