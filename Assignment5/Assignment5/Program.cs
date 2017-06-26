using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 5, 9, 4, 7, 15, 16, 10, 11, 14, 19, 18 };


            //the following examples iterate through the entire list
            Console.WriteLine("MaxOverPrevious");
            foreach(int val in list.MaxOverPrevious())
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
            foreach (int val in list.MaxOverPrevious(i => i / 2 + 7))
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Local maxima");
            foreach (int val in list.LocalMaxima())
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
            foreach (int val in list.LocalMaxima(i => i / 2 + 7))
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("AtLeastK");
            Console.WriteLine(list.AtLeastK(3, i => i >= 16 && i < 20));
            Console.WriteLine(list.AtLeastK(3, i => i >= 16 && i < 20, i => i / 2 + 7));
            Console.WriteLine();

            Console.WriteLine("AtLestHalf");
            Console.WriteLine(list.AtLeastHalf(i => i >= 16 && i < 20));
            Console.WriteLine(list.AtLeastHalf(i => i >= 16 && i < 20, i => i / 2 + 7));
            Console.WriteLine();


            //the following example uses the ToList on a few of the function to show it will do the whole thing at once
            Console.WriteLine("LocalMaxima using ToList to iterate through the entire thing");
            foreach (int val in list.LocalMaxima(i => i / 2 + 7).ToList())
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
            Console.WriteLine();


            //the follwoing example will only iterate through the first 5 elements
            Console.WriteLine("LocalMaxima only loops through 5 elements");
            int count = 0;
            foreach (int val in list.LocalMaxima())
            {
                Console.Write(val + " ");
                if (++count >= 5) break;
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
