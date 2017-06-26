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
            Computer prototype = new Computer(id: "c1356", ram: 8000000000, storage: 512, cellularAntenna: true);
            Computer userPrototype = null;
            Computer[] computers = new Computer[10];

            int selection;
            do
            {
                do
                {
                    selection = Menu();
                } while (selection < 1 || selection > 6);
                switch (selection)
                {
                    case 1:
                        AddComputer(computers);
                        break;
                    case 2:
                        PrototypeComputer(ref userPrototype);
                        break;
                    case 3:
                        Console.Write("About which computer would you like a summary (1-10)? ");
                        int index = Convert.ToInt16(Console.ReadLine());
                        SummaryComputer(computers[index - 1], prototype);
                        break;
                    case 4:
                        StatisticsAll(computers);
                        break;
                    case 5:
                        Console.WriteLine("Which range of computers would you like to include in your summary? ");
                        Console.Write("Start: ");
                        int start = Convert.ToInt16(Console.ReadLine());
                        Console.Write("End: ");
                        int end = Convert.ToInt16(Console.ReadLine());
                        StatisticsRange(computers, prototype, userPrototype, start, end);
                        break;
                    case 6:
                        Console.Write("Exiting application...");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;
                }
            } while (selection != 6);

            Console.ReadKey();
        }

        public static int Menu()
        {
            Console.WriteLine(@"Please select from the following menu:
            1. Add a computer
            2. Specify your prototype computer
            3. Summary of a specific computer
            4. Summary of statistics of all computers
            5. Summary of specific computers
            6. Exit Application");
            int selection;
            int.TryParse(Console.ReadLine(), out selection);
            return selection;
        }

        public static void AddComputer(Computer[] computers)
        {
            Console.Write("What is the id of the computer? ");
            String id = Console.ReadLine();
            Console.Write("Does the device have a cellular antenna? (y/n or NA) ");
            String data = Console.ReadLine().ToUpper();
            bool? antenna = null;
            if(data.ToUpper() == "NA")
                antenna = null;
            else if (data[0] == 'Y')
                antenna = true;
            else 
                antenna = false;
            Console.Write("What is the hard drive storge of the device (in GB) or null if doesn't support a hard drive? ");
            data = Console.ReadLine();
            double? storage = null;
            double store;
            bool test = double.TryParse(data, out store);
            if (test) { storage = store; }
            Console.Write("How much RAM does the device have (in Bytes)? ");
            Int64 ram = Convert.ToInt64(Console.ReadLine());
            Console.Write("Is the device equipped for extra software? (y/n) ");
            data = Console.ReadLine().ToUpper();
            int?[] software;
            if (data[0] == 'Y')
            {
                software = new int?[5];
                for (int i = 0; i < software.Length; i++)
                {
                    Console.Write($"Do you have software {i + 1} installed on your computer? (y/n) ");
                    data = Console.ReadLine().ToUpper();
                    if (data[0] == 'Y')
                    {
                        Console.Write($"How many licenses do you have for software {i + 1}? ");
                        software[i] = Convert.ToInt16(Console.ReadLine());
                    }
                    else
                    {
                        software[i] = null;
                    }
                }
            }
            else
            {
                software = null;
            }
            
            for (int i = 0; i < computers.Length; i++)
            {
                if (computers[i] == null)
                {
                    computers[i] = new Computer(id, ram, storage, antenna, software);
                    break;
                }
            }
        }

        public static void PrototypeComputer(ref Computer prototype)
        {
            Console.Write("What is the id your prototype computer? ");
            String id = Console.ReadLine();
            Console.Write("Does your prototype computer have a cellular antenna? (y/n or NA) ");
            String data = Console.ReadLine().ToUpper();
            bool? antenna = null;
            if (data.ToUpper() == "NA")
                antenna = null;
            else if (data[0] == 'Y')
                antenna = true;
            else
                antenna = false;
            Console.Write("What is the hard drive storge of your prototype computer (in GB) or null if doesn't support a hard drive? ");
            data = Console.ReadLine();
            double? storage = null;
            double store;
            bool test = double.TryParse(data, out store);
            if (test) { storage = store; }
            Console.Write("How much RAM does your prototype have (in Bytes)? ");
            Int64 ram = Convert.ToInt64(Console.ReadLine());
            Console.Write("Is the device equipped for extra software? (y/n) ");
            data = Console.ReadLine().ToUpper();
            int?[] software;
            if (data[0] == 'Y')
            {
                software = new int?[5];
                for (int i = 0; i < software.Length; i++)
                {
                    Console.Write($"Do you have software {i + 1} installed on your computer? (y/n) ");
                    data = Console.ReadLine().ToUpper();
                    if (data[0] == 'Y')
                    {
                        Console.Write($"How many licenses do you have for software {i + 1}? ");
                        software[i] = Convert.ToInt16(Console.ReadLine());
                    }
                    else
                    {
                        software[i] = null;
                    }
                }
            }
            else
            {
                software = null;
            }
            prototype = new Computer(id, ram, storage, antenna, software);
        }

        public static void SummaryComputer(Computer computer, Computer prototype)
        {
            computer = computer ?? prototype;
            Console.WriteLine(computer);
        }

        public static void StatisticsAll(Computer[] computers)
        {
            Int64 ram = 0;
            double antenna = 0;
            double compWithAntenna = 0;
            double storage = 0;
            double compWithStorage = 0;
            int software = 0;
            int[] licenses = new int[5];
            int compWithSoftware = 0;
            int[] compWithLicense = new int[5];

            int i;
            for (i = 0;  i < computers.Length && computers[i] != null; i++)
            {
                ram += computers[i].RAM;
                if (computers[i].CellularAntenna.HasValue)
                {
                    antenna += (bool)computers[i].CellularAntenna ? 1 : 0;
                    compWithAntenna++;
                }
                if (computers[i].Storage.HasValue)
                {
                    storage += (double)computers[i].Storage;
                    compWithStorage++;
                }
                if (computers[i].Software != null)
                {
                    for (int j = 0; j < computers[i].Software.Length; j++)
                    {
                        if (computers[i].Software[j] != null)
                        {
                            software ++;
                            licenses[j] += (int)computers[i].Software[j];
                            compWithLicense[j]++;
                        }
                    }
                    compWithSoftware++;
                }
            }

            double avgRam = (double)ram / (double)i;
            double avgAntenna = (double)antenna / (double)compWithAntenna * 100;
            double avgStorage = (double)storage / (double)compWithStorage;
            if (i != 0)
            {
                Console.WriteLine($"The average RAM of all your devices is {avgRam} Bytes");
                Console.WriteLine($"{avgAntenna}% of your devices have a cellular antenna");
                Console.WriteLine($"The average hard drive capacity of your devices is {avgStorage} GB");
                if(!double.IsNaN(software / (double)compWithSoftware))
                    Console.WriteLine($"The average number of software per machine is {software / (double)compWithSoftware}");
                else
                    Console.WriteLine($"None of these devices support additional software");
                Console.WriteLine("The average number of licenses for each program is as follows: ");
                for (int x = 0; x < licenses.Length; x++)
                {
                    if (!double.IsNaN((double)licenses[x] / compWithLicense[x]))
                        Console.WriteLine($"\tSoftware {x + 1}: {(double)licenses[x] / compWithLicense[x]}");
                    else
                        Console.WriteLine($"\tSoftwarwe {x + 1}: No licenses on any of the devices");
                }
            }
            else
            {
                Console.WriteLine("You didn't enter any computers\n");
            }
        }

        public static void StatisticsRange(Computer[] computers, Computer prototype, Computer userPrototype, int start, int end)
        {
            Int64 ram = 0;
            int antenna = 0;
            int compWithAntenna = 0;
            double storage = 0;
            int compWithStorage = 0;
            int software = 0;
            int[] licenses = new int[5];
            int compWithSoftware = 0;
            int[] compWithLicense = new int[5];

            int amount = end - start + 1;
            Computer comp;

            for (int i = start - 1; i < computers.Length && i < end; i++)
            {
                comp = computers[i] ?? userPrototype ?? prototype;
                ram += comp.RAM;
                if (comp.CellularAntenna.HasValue)
                {
                    antenna += (bool)comp.CellularAntenna ? 1 : 0;
                    compWithAntenna++;
                }
                if (comp.Storage.HasValue)
                {
                    storage += (double)comp.Storage;
                    compWithStorage++;
                }
                if (comp.Software != null)
                {
                    for (int j = 0; j < comp.Software.Length; j++)
                    {
                        if (comp.Software[j] != null)
                        {
                            software ++;
                            licenses[j] += (int)comp.Software[j];
                            compWithLicense[j]++;
                        }
                    }
                    compWithSoftware++;
                }
            }

            Console.WriteLine($"The average RAM of all your devices is {ram / (double)amount} Bytes");
            Console.WriteLine($"{(antenna / (double)compWithAntenna) * 100}% of your devices have a cellular antenna");
            Console.WriteLine($"The average hard drive capacity of your devices is {storage / (double)compWithStorage} GB");
            if (!double.IsNaN(software / (double)compWithSoftware))
                Console.WriteLine($"The average number of software per machine is {software/(double)compWithSoftware}");
            else
                Console.WriteLine($"None of these devices support additional software");
            Console.WriteLine("The average number of licenses for each program is as follows: ");
            for (int x = 0; x < licenses.Length; x++)
            {
                if (!double.IsNaN((double)licenses[x] / compWithLicense[x]))
                    Console.WriteLine($"\tSoftware {x + 1}: {(double)licenses[x] / compWithLicense[x]}");
                else
                    Console.WriteLine($"\tSoftwarwe {x + 1}: No licenses on any of the devices");
            }
        }
    }
}