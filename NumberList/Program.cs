using System;
using static System.Console;

namespace NumberList
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numList = new double[20];
            int length;
            string input;


            WriteLine("Please enter a number or Type X");
            length = EnterList(numList);
           
            //Array.Resize(ref numList, length);
            //alternative to making my own shrinkArray Method
            
            numList = shrinkArray(numList, length);

            WriteLine("What function would you like to do?");
            WriteLine("Print, Sum, Sort, or Stop?");
            input = ReadLine();

            while(UserInput(input,numList))
            {
                WriteLine("What function would you like to do?");
                WriteLine("Print, Sum, Sort, or Stop?");
                input = ReadLine();
            }
            
        }

        private static int EnterList(double[] numList)
        {
            string input = ReadLine();
            int post = 0;
            while(input != "X" && post < 20)
            {
                numList[post] = Convert.ToDouble(input);
                ++post;

                WriteLine("You have entered {0} numbers. Please enter a number or Type X", post);
                input = ReadLine();
            }

            return post;
        }

        private static double[] shrinkArray(double[] numList, int post)
        {

            double[] tempArray = new double[post];

            for (int x = 0; x < tempArray.Length; ++x)
            {
                tempArray[x] = numList[x];
            }

            numList = new double[post]; //recreating the array

            for (int x = 0; x < tempArray.Length; ++x)
            {
                numList[x] = tempArray[x];
            }

            return numList;
        }

        private static void PrintList(double[] numList)
        {
            for(int x  = 0; x < numList.Length; ++x)
            {
                WriteLine(numList[x]);
            }
        }

        private static double SumList(double[] numList)
        {
            double sum = 0;

            for(int x = 0; x < numList.Length; ++x)
            {
                sum += numList[x];
            }

            return sum;
        }
        private static bool UserInput(string input, double[] numList)
        {
            input = input.ToLower();

            if(input == "print")
            {
                PrintList(numList);
                return true;
            }
            else if (input == "sum")
            {
                double sum = SumList(numList);
                WriteLine("Sum is {0}", sum);
                return true;
            }
            else if (input == "sort")
            {
                Array.Sort(numList);
                return true;
            }
            else if (input == "stop")
            {
                WriteLine("Stopping Program");
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
