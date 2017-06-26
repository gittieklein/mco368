using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Class;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Sale[] saleItems = new Sale[9];
            saleItems[0] = new Sale("Coffee", "John Smith", 2.99, 1, "123 6th St.", false);
            saleItems[1] = new Sale("Bagel", "Jack Williams", 0.85, 7, "70 Bowman St.", true);
            saleItems[2] = new Sale("Ice cream", "Emily Rogers", 2.50, 2, "71 Pilgrim Avenue", true);
            saleItems[3] = new Sale("Soda", "Zack John", 1.50, 11, "4 Goldfield Rd. ", true);
            saleItems[4] = new Sale("Tea", "ABC llc", 2.50, 200, "44 Shirley Ave.", false);
            saleItems[5] = new Sale("Beer", "Store llc", 4.50, 200, "514 S. Magnolia St.", true);
            saleItems[6] = new Sale("Water", "Company", 1.49, 350, "244 Cross Ave.", true);
            saleItems[7] = new Sale("Lemonade", "Jann Christo", 0.99, 7, "7888 Glenlake Drive", true);
            saleItems[8] = new Sale("Hot Chocolate", "Tory Lindo", 3.49, 1, "9285 St Margarets Ave.", false);

            double total;

            total = TotalProfit(
                saleItems,
                s => s.Customer.Contains("John"),
                s => s.PricePerItem * s.Quantity + (s.ExpeditedShipping ? 15 : 0),  //extra $15 profit with expedited shipping
                (s, d) => Console.WriteLine(s.Item + " - Quantity: " + s.Quantity + ", Customer: " + s.Customer + ", Profit: $" + d),
                s => Console.WriteLine("{0} was purchased not purchased by a customer with the name John ", s.Item)
            );

            Console.WriteLine("The total profit of items bought by customers with the name John is ${0}.\n", total);

            total = TotalProfit(
                saleItems,
                s => s.Quantity > 1,
                s => s.PricePerItem * s.Quantity,
                (s, d) => Console.WriteLine(s.Item + " - Quantity: " + s.Quantity + ", Customer: " + s.Customer + ", Profit: $" + d),
                s => Console.WriteLine(s.Item + " has a quantity of 1")
            );

            Console.WriteLine("The total profit of items with a quantity greater than 1 is ${0}.\n", total);

            total = TotalProfit(
                saleItems,
                s => s.ExpeditedShipping,
                s => s.PricePerItem * s.Quantity - (s.ExpeditedShipping ? 3 : 0),   //lose $3 profit with expedited shipping 
                (s, d) => Console.WriteLine(s.Item + " - Quantity: " + s.Quantity + ", Customer: " + s.Customer + ", Profit: $" + d),
                s => Console.WriteLine(s.Item + " does not have expedited shipping")
            );

            Console.WriteLine("The total profit of items with a expedited shipping is ${0}.\n", total);

            Queries(saleItems);

            Console.ReadKey();

        }

        static double TotalProfit(Sale[] saleItems, Func<Sale, bool> Included,
                        Func<Sale, double> Profit, Action<Sale, double> ActionIncl,
                        Action<Sale> ActionNotIncl)
        {
            double totalProfit = 0;
            double profit;

            foreach (Sale item in saleItems)
            {
                if (Included(item))
                {
                    profit = Profit(item);
                    totalProfit += profit;
                    ActionIncl(item, profit);
                }
                else { ActionNotIncl(item); }
            }

            return totalProfit;
        }

        static void Queries(Sale[] saleItems)
        {
            Console.WriteLine("Linq Queries");

            //1.
            var saleOverTen =
                from s in saleItems
                where s.PricePerItem > 10
                select s;

            var saleOverTen2 = saleItems.Where(s => s.PricePerItem > 10);

            Console.WriteLine("Collection of all Sale objects where the PricePerItem is over 10.0");
            foreach (var element in saleOverTen)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();
            foreach (var element in saleOverTen2)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();


            //2.
            var quantOne =
                from s in saleItems
                where s.Quantity == 1
                orderby s.PricePerItem descending
                select s;

            var quantOne2 = saleItems.Where(s => s.Quantity == 1)
                               .OrderByDescending(s => s.PricePerItem);

            Console.WriteLine("Collection of all Sale objects where the Quantity is 1 in descending order of PricePerItem");
            foreach (var element in quantOne)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();
            foreach (var element in quantOne2)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();

            //3.
            var teaItem =
                from s in saleItems
                where s.Item == "Tea" && s.ExpeditedShipping == false
                select s;

            var teaItem2 = saleItems.Where(s => s.Item == "Tea" && s.ExpeditedShipping == false);

            Console.WriteLine("Collection of Sale objects where the Item is “Tea” and ExpeditedShipping is false");
            foreach (var element in teaItem)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();
            foreach (var element in teaItem2)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();

            //4.
            var address =
                from s in saleItems
                where s.PricePerItem * s.Quantity > 100
                select s.Address;

            var address2 = saleItems.Where(s => s.PricePerItem * s.Quantity > 100)
                                    .Select(s => s.Address);

            Console.WriteLine("Collection of all addresses where the cost of the total order is over 100");
            foreach (var element in address)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();
            foreach (var element in address2)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();

            //5.
            var item =
                from s in saleItems
                where s.Customer.Contains("llc")
                select new
                {
                    ItemProperty = s.Item,
                    TotalPrice = s.PricePerItem * s.Quantity,
                    Shipping = s.ExpeditedShipping ? s.Address + " EXPEDITE" : s.Address
                } into obj
                orderby obj.TotalPrice
                select obj;

            var item2 = saleItems.Where(s => s.Customer.Contains("llc"))
                                 .Select(s => new
                                 {
                                     ItemProperty = s.Item,
                                     TotalPrice = s.PricePerItem * s.Quantity,
                                     Shipping = s.ExpeditedShipping ? s.Address + " EXPEDITE" : s.Address
                                 })
                                 .OrderBy(s => s.TotalPrice);

            Console.WriteLine("Anonymous Object");
            foreach (var element in item)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();
            foreach (var element in item2)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();
        }
    }
}
