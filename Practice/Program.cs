using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class LongestSubarrayContiguousElements
    {
        public int findRequiredLength(int[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }

            int maxLength = 1;
            int subArrayStart = 0, subArrayEnd = 0;

            // we are interested in looking at sub-arrays with minimum length as 2
            // since length of 1 for longest sub-array with contiguous elements is trivial 
            // and we don't need to check for that  
            for (int i = 0; i < array.Length - 1; i++)
            {
                int maxElement = array[i], minElement = array[i];

                for (int j = i + 1; j < array.Length; j++)
                {
                    // update min and max elements
                    if (array[j] > maxElement)
                    {
                        maxElement = array[j];
                    }
                    if (array[j] < minElement)
                    {
                        minElement = array[j];
                    }

                    // if difference between min and max is equal to length of sub-array 
                    // then we have found sub-array with elements which could form contiguous sequence
                    if ((maxElement - minElement) == (j - i))
                    {
                        // if length of sub-array is greater than maximum length found
                        if ((j - i + 1) > maxLength)
                        {
                            maxLength = j - i + 1;
                            subArrayStart = i;
                            subArrayEnd = j;
                        }
                    }
                }
            }

            Console.WriteLine(subArrayStart + "-" + subArrayEnd);
            return maxLength;
        }

    }
        class Program
    {
        static int maxSubArraySum(int[] a)
        {
               // public static void main(String[] args)
                {
                    LongestSubarrayContiguousElements solution = new LongestSubarrayContiguousElements();
                    int[] testArray = { 10, 12, 11, 94, 56, 32, 34, 36, 33, 35, 37 };

                   Console.WriteLine(solution.findRequiredLength(testArray));

                }


                int size = a.Length;
            int max_so_far = int.MinValue,
                max_ending_here = 0;
            int asd = 0;
            for (int i = 0; i < size; i++)
            {
                asd += 1;
                max_ending_here = max_ending_here + a[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }



        static void Main(string[] args)
        {

            int[] a1 = { -2, -3, 4, -1, -2, 1, 5, -3 };
            Console.Write("Maximum contiguous sum is " +
                                    maxSubArraySum(a1));


            int testcase = 1;
            string DistLenStr = "5 6";
            string temparray = "3 2 1 3 4 5";

            //int testcase = Convert.ToInt32(Console.ReadLine());

            List<Tuple<string, string>> top = new List<Tuple<string, string>>();

            for (int i = 0; i < testcase; i++)
            {
                //string DistLenStr = Console.ReadLine();
                //string temparray = Console.ReadLine();
                top.Add(new Tuple<string, string>(DistLenStr, temparray));
            }

            foreach (var t in top)
            {
                
                string[] DistLen = t.Item1.Split(' ');
                int DistinctVal = Convert.ToInt32(DistLen[0]);
                int arrlen = Convert.ToInt32(DistLen[1]);
                string[] arraytest = t.Item2.Split(' ');
                var a = arraytest.Distinct().ToList();

                if (arraytest.Length != arrlen || a.Count != DistinctVal || arraytest.Length <= DistinctVal)
                {
                    Console.WriteLine("Inavlid");
                    Console.ReadLine();
                    return;
                }


                List<string> tempArrTest = new List<string>();
                int len = 0;
                for (int i = 0; i < arrlen; i++)
                {

                    if (!tempArrTest.Contains(arraytest[i]))
                    {
                        tempArrTest.Add(arraytest[i]);
                    }
                    else
                    {
                        if (len < tempArrTest.Count)
                            len = tempArrTest.Count;
                        tempArrTest = new List<string>();
                        tempArrTest.Add(arraytest[i]);
                    }
                }
                if (len < tempArrTest.Count)
                    len = tempArrTest.Count;
                Console.WriteLine(len);
            }

            Console.ReadLine();
        }
    }

}
