using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    static class ExtensionMethods
    {
        //The MaxOverPrevious saves processing if the goal is to get the first x elements
        //if the user wants to get the entire list then the deffered execution doesn't accomplish anything
        //but, this does give the user an option to look through the first 5 elemetns for example, and not have to 
        //iterate through the entire list to get that
        //it does accomplish if the user addes more elements to the list after they call the method, before
        //they iterate over it

        public static IEnumerable<int> MaxOverPrevious(this IEnumerable<int> list)
        {
            if (list.Any())
            {
                int max = list.ElementAt(0);
                yield return max;

                foreach (int val in list)
                {
                    if (val > max)
                    {
                        max = val;
                        yield return val;
                    }
                }

            }
        }

        public static IEnumerable<int> MaxOverPrevious(this IEnumerable<int> list, Func<int, int> convert)
        {
            list = list.Select(convert);

            if (list.Any())
            {
                int max = list.ElementAt(0);
                yield return max;

                foreach (int val in list)
                {
                    if (val > max)
                    {
                        max = val;
                        yield return val;
                    }
                }

            }
        }


        //LocalMaxima saves processing if the goal is to get the first x elements (just like MaxOVerPrevious)
        //if the user wants to get the entire list then the deffered execution doesn't accomplish anything
        //but, this does give the user an option to look through the first 5 elemetns for example, and not have to 
        //iterate through the entire list to get that
        //it does accomplish if the user addes more elements to the list after they call the method, before
        //they iterate over it

        public static IEnumerable<int> LocalMaxima(this IEnumerable<int> list)
        {
            int prev, after;
            for(int i = 0; i < list.Count(); i++)
            {
                prev = int.MinValue;
                after = int.MinValue;
                if (i-1 >= 0)
                    prev = list.ElementAt(i - 1);
                if(i+1 < list.Count())
                    after = list.ElementAt(i + 1);
                if (list.ElementAt(i) > prev && list.ElementAt(i) > after)
                {
                    yield return list.ElementAt(i);
                }      
            }
        }

        public static IEnumerable<int> LocalMaxima(this IEnumerable<int> list, Func<int, int> convert)
        {
            list = list.Select(convert);

            int prev, after;
            for (int i = 0; i < list.Count(); i++)
            {
                prev = list.ElementAtOrDefault(i - 1);
                after = list.ElementAtOrDefault(i + 1);
                if (list.ElementAt(i) > prev && list.ElementAt(i) > after)
                {
                    yield return list.ElementAt(i);
                }
            }
        }


        //In AtLeastK, the elements of the list will only be iterated as long as necessary
        //if k is 3, and the first 3 elements pass the condition, the method will return true and stop
        //deffered execution can make a small difference here - if values are removed or added before the 
        //IEnumerable is actually iterated through, the method will test based on the updated list
        //if there are values that pass the condition that are added to the front, this can save processing
        
        public static bool AtLeastK(this IEnumerable<int> list, int k, Func<int, bool> test)
        {
            int count = 0;
            foreach(var val in list)
            {
                if (test(val)) count++;
                if (count >= k) return true;
            }
            return false;           
        }

        public static bool AtLeastK(this IEnumerable<int> list, int k, Func<int, bool> test, Func<int,int> convert)
        {
            list = list.Select(convert);
            int count = 0;
            foreach (var val in list)
            {
                if (test(val)) count++;
                if (count >= k) return true;
            }
            return false;
        }


        //In AtLeastHalf is similar to AtLeastK, but K is half the size of the list
        //Here too, the elements of the list will only be iterated as long as necessary
        //the count extnession method is needed to get the size of the array, so the function knows when it is half - 
        //it makes sense to use the count method because if the IEnumerable that is passed in is a list, then
        //the count method will use the count property (and the list won't need to be iterate through)
        //deffered execution can make a small difference here - if values are removed or added before the 
        //IEnumerable is actually  iterated through, the method will test based on the updated list
        //if there are values that pass the condition that are added to the front, this can save processing

        public static bool AtLeastHalf(this IEnumerable<int> list, Func<int, bool> test)
        {
            int countSelect = 0;
            int countTotal = list.Count();
            foreach (var val in list)
            {
                if (test(val)) countSelect++;
                if (countSelect >= countTotal / 2.0) return true;
            }
            return false;         
        }

        public static bool AtLeastHalf(this IEnumerable<int> list, Func<int, bool> test, Func<int,int> convert)
        {
            list = list.Select(convert);
            int countSelect = 0;
            int countTotal = list.Count();
            foreach (var val in list)
            {
                if (test(val)) countSelect++;
                if (countSelect >= countTotal / 2.0) return true;
            }
            return false;
        }
    }
}