using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Sale
    {
        public Sale(String item, String customer, double ppi, int quantity, String addr, bool expship)
        {
            Item = item;
            Customer = customer;
            PricePerItem = ppi;
            Quantity = quantity;
            Address = addr;
            ExpeditedShipping = expship;
        }

        public String Item { get; set; }
        public String Customer { get; set; }
        public double PricePerItem { get; set; }
        public int Quantity { get; set; }
        public String Address { get; set; }
        public bool ExpeditedShipping { get; set; }

        override
        public String ToString()
        {
            String line = Customer + " ordered " + Quantity + " " + Item + " at " + PricePerItem + " each. Address: " + Address + " Expedited Shipping? " + ExpeditedShipping;
            return line;
        }
    }
}
