using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubArray
{
    class Program
    {
        /// <summary>
        /// longest sub array in an array.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int T;
            int k, d;            
            bool isT = int.TryParse(Console.ReadLine(), out T);
            if (!isT)
            {
                Console.WriteLine("Invalid Number of testcase.");
                return;
            }
            for (int t = 0; t < T; t++)
            {
                string lengthAndDistinct = Console.ReadLine();
                string temp3 = Console.ReadLine();
                var temp2 = lengthAndDistinct.Split(' ');
                if (temp2.Length > 2)
                {
                    Console.WriteLine("Improper data.");
                    return;
                }
                bool isk = int.TryParse(temp2[0], out k);
                if (!isk)
                {
                    Console.WriteLine("Invalid length of array.");
                    return;
                }
                bool isd = int.TryParse(temp2[1], out d);
                if (!isd)
                {
                    Console.WriteLine("Invalid Number of distinct item.");
                    return;
                }
                var inputArray = temp3.Split(' ').ToList();
                if (inputArray.Count != k)
                {
                    Console.WriteLine("Array length is not valid.");
                    return;
                }
                if (inputArray.Distinct().Count() != d)
                {
                    Console.WriteLine("Disinct element are not equal as per test case.");
                    return;
                }

                List<string> temparr = new List<string>();
                for (int i = 0; i < k; i++)
                {
                    if (!temparr.Contains(inputArray[i]))
                    {
                        temparr.Add(inputArray[i]);
                    }
                    else
                    {
                        i = inputArray.IndexOf(inputArray[i]);
                        temparr.Clear();
                        i++;
                        temparr.Add(inputArray[i]);
                    }
                }
                Console.WriteLine(temparr.Count);
            }
            Console.ReadLine();
        }
    }
}
