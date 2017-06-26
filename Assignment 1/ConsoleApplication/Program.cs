using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Classes;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int ageInt = 0;
            int years = 0;
            bool nbc = false;
            int termServed = 0;
            bool didRebel = false;

            
            if (args.Length == 0)
            {
                bool testAge = false;
                while (!testAge)
                {
                    Console.Write("How old are you? ");
                    String age = (Console.ReadLine());
                    testAge = int.TryParse(age, out ageInt);
                }

                Console.Write("Are you a natural born US citizen (y/n)? ");
                String naturalBornCitizen = Console.ReadLine();
                if (naturalBornCitizen[0] == 'y' || naturalBornCitizen[0] == 'Y')
                {
                    nbc = true;
                }

                bool testYears = false;
                while (!testYears)
                {
                    Console.Write("How many years were you living in the US? ");
                    String yearsInUS = Console.ReadLine();
                    testYears = int.TryParse(yearsInUS, out years);
                }

                bool testTerms = false;
                while (!testTerms)
                {
                    Console.Write("How many prior terms have you served? ");
                    String terms = Console.ReadLine();
                    testTerms = int.TryParse(terms, out termServed);
                }

                Console.Write("Have you rebelled against the US (y/n)? ");
                String rebelled = Console.ReadLine();
                if (rebelled[0].Equals('Y') || rebelled[0].Equals('y'))
                {
                    didRebel = true;
                }
            }
            else if (args.Length == 5)
            {
                if (!(int.TryParse(args[0], out ageInt)))
                {
                    Console.WriteLine("You entered the wrong arguments.");
                    Console.ReadKey();
                    System.Environment.Exit(1);
                }
                if (!(int.TryParse(args[1], out years)))
                {
                    Console.WriteLine("You entered the wrong arguments.");
                    Console.ReadKey();
                    System.Environment.Exit(1);
                }
                String nborn = args[2];
                if (nborn[0].Equals('y') || nborn[0].Equals('Y'))
                {
                    nbc = true;
                }
                if (!(int.TryParse(args[3], out termServed)))
                {
                    Console.WriteLine("You entered the wrong arguments.");
                    Console.ReadKey();
                    System.Environment.Exit(1);
                }
                String rebel = args[4];
                if (rebel[0] == 'y' || rebel[0] == 'Y')
                {
                    didRebel = true;
                }

            }
            else
            {
                Console.WriteLine("You entered the wrong arguments.");
                Console.ReadKey();
                System.Environment.Exit(1);
            }

            Eligibility eligiblePrez = new Eligibility(ageInt, years, nbc, termServed, didRebel);
            bool couldRun = eligiblePrez.EligiblePrez();

            if (couldRun)
            {
                Console.WriteLine("You are eligible to run for President of the US!");
            }
            else
            {
                Console.WriteLine("You are not eligible to run for President of the US!");
            }

            Console.ReadKey();
        }

    }
}
