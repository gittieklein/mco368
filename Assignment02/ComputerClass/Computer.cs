using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Computer
    {
        private readonly String id;
        private bool? cellularAntenna;
        private double? storage;   //measured in GB
        private int?[] software;
        private Int64 ram;

        public Computer(String id, Int64 ram, double? storage = null, bool? cellularAntenna = null, int?[] licenses = null)
        {
            this.id = id;
            if (ram < 1000)
                this.ram = 1000;
            else
                this.ram = ram;
            this.cellularAntenna = cellularAntenna;
            this.storage = storage;
            this.software = licenses;   //user sends in array and it copies it
        }

        public String Id { get { return id;} }

        public bool? CellularAntenna
        {
            get { return cellularAntenna;}
            set
            {
                    cellularAntenna = value;
            }
        }

        public double? Storage
        {
            get { return storage; }
            set
            {
                if (value >= 0)
                    storage = value;
            }
        }

        public Int64 RAM
        {
            get
            {
                int subtract = 0;
                if (cellularAntenna == true)
                    subtract += 100;
                else
                    subtract += 50;
                if(software != null)
                {
                    for(int i = 0; i < software.Length; i++)
                    {
                        if(software[i] != null)
                            subtract += ((int)software[i] * 10);
                    }
                }
                return ram - subtract;
            }
            set
            {
                if(value >= 1000)
                    ram = value;
            }
        }
           
        public int?[] Software
        {
            get { return software; }
        } 

        public override String ToString()
        {
            String computer =
                   $"Computer ID: {id}";

            computer += (cellularAntenna == true ? "\nComputer has cellular antenna" :
                (cellularAntenna == false ? "\nComputer doesn't cellular antenna" :
                "\nComputer doesn't have feature for cellular antenna"));
           
            computer += storage == null ? "\nComputer doesn't support a hard drive" :
                            $"\nHard drive storage capactiy is {storage} GB";

            computer += $"\nThe RAM is {ram} bytes";

            if (software == null)
                computer += "\nThe computer isn't equipped for extra software";
            else
            {
                computer += "\nExtra software: ";
                for(int i = 0; i < software.Length; i++)
                {
                    computer += software[i].HasValue ? $"\nSoftware {i + 1} has {software[i]} licenses" :
                                                 $"\nSoftware {i + 1} is not installed on this device";
                }
            }
            computer += "\n";
            return computer;
        }
    }
}
