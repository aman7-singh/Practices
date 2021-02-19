using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    static class GeeksForGeeks
    {

        public static string LongestLCS(string s1, string s2)
        {
            //var inputLongestLCS1 = "stone";
            //var inputLongestLCS2 = "longest";
            var a1 = s1.ToCharArray();
            var a2 = s2.ToCharArray();
            var ans = "";
            var lcs = new int[a1.Length,a2.Length];
            for (int i = 1; i < a1.Length; i++)
            {
                for (int j = 1; j < a2.Length; j++)
                {
                    if (a1[i] == a2[j])
                    {
                        lcs[i,j] = 1 + lcs[i - 1, j - 1];
                        ans += s1[i];
                    }
                    else
                    {
                        lcs[i, j] = Math.Max(lcs[i-1,j],lcs[i,j-1]);
                    }
                }
            }
            return ans;
        }
        public static List<int> UnionOfTwoArray(int[] a1, int[] a2)
        {
            var sda1 = a1.Distinct().ToList();
            var sda2 = a2.Distinct().ToList();
            sda1.Sort();
            sda2.Sort();

            var temp = sda1;
            if (sda1.Count > sda2.Count)
            {
                temp = sda1;
            }
            var res = new List<int>();
            int i = 0;
            int j = 0;
            while (i < sda1.Count && j < sda2.Count)
            {
                if (sda1[i] < sda2[j])
                {
                    res.Add(sda1[i]);
                    i++;
                }
                else if (sda1[i] > sda2[j])
                {
                    res.Add(sda2[j]);
                    j++;
                }
                else 
                {
                    res.Add(sda2[j]);
                    j++;
                    i++;
                }
            }

            while (i < sda1.Count)
            { res.Add(sda1[i++]); }
            while (j < sda2.Count)
            { res.Add(sda2[j++]); }


            return res;
        }

        static public void MainGFG()
        {
            Console.WriteLine("Hello World!");
            int T = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                var input = Console.ReadLine().Split(' ');
                if (N == input.Length)
                {
                    var s = input.Select(int.Parse).ToArray();
                    int min = int.MaxValue;
                    int max = int.MinValue;
                    GetMinAndMax(s,out min,out max);
                }
            }
        }
        public static void GetMinAndMax(int[] a, out int min, out int max)
        {
            min = int.MaxValue;
            max = int.MinValue;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
                else if (a[i] > max)
                {
                    max = a[i];
                }
            }
        }
        public static int[] InsertionSort(int[] arr)
        {
            int j = 0;
            int temp;
            for (int i = 1; i < arr.Length; i++)
            {
                temp = arr[i];
                j = i - 1;

                while (j>=0 && arr[j]>temp )
                {
                    arr[j+1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }

            return arr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name=[-1, 2, -3, 4, 5, 6, -7, 8, 9]></param>
        /// <returns>[9, -7, 8, -3, 5, -1, 2, 4, 6]</returns>
        /// 
        public static int[] RearrangePositiveAndNegativeNumbers(int[] arr)
        {

            int n = arr.Length;
            int i = -1, temp = 0;
            for (int j = 0; j < n; j++)
            {
                if (arr[j] < 0)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            int pos = i + 1, neg = 0;
            // Increment the negative index by 2 and 
            // positive index by 1, i.e., swap every  
            // alternate negative number with next positive number 
            while (pos < n && neg < pos && arr[neg] < 0)
            {
                temp = arr[neg];
                arr[neg] = arr[pos];
                arr[pos] = temp;
                pos++;
                neg += 2;
            }


            /*
            int x = 0;
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    x = arr[i];
                    arr[i] = arr[j];
                    arr[j] = x;
                    j++;
                }
            }

            int p = 0;
            //int n = 0;
            int y = 0;
            int z = 0;
            for (int k=0;k<arr.Length;k++)
            {
                if (k % 2 == 0 && j+p<arr.Length)
                {
                    y = arr[k];
                    arr[k] = arr[j+p];
                    arr[j + p] = y;
                    p++;
                }
                else if (j+n < arr.Length)
                {
                    z = arr[k];
                    arr[k] = arr[j + n];
                    arr[j + n] = z;
                    n++;
                }
            }
            */
            return arr;
        }
        public static int[] RearrangeArrayReplaceAproach(int[] input)
        {
            int temp = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < 0 || input[i] > input.Length - 1)
                {
                    input[i] = -1;
                    continue;
                }
                if (input[i] != i)
                {
                    temp = input[i];
                    input[i] = input[temp];
                    input[temp] = temp;
                }

                if (input[i] == temp && i != temp)
                {
                    input[i] = -1;
                    continue;
                }

                if (input[i] < 0 || input[i] > input.Length - 1)
                {
                    input[i] = -1;
                    continue;
                }

                if (input[i] != i)
                {
                    i--;
                }
            }
            return input;
            //int x=-1;
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] != i && arr[i] != -1)
            //    {
            //        if (arr[i] >= arr.Length)
            //        {
            //            arr[i] = -1;
            //            continue;
            //        }
            //        x = arr[i];
            //        arr[i] = arr[x];
            //        arr[x] = x;
            //    }
            //    if (x == arr[i] && x != i)
            //    {
            //        arr[i] = -1;
            //        continue;
            //    }

            //    if (arr[i] != i && arr[i] != -1)
            //    {
            //        if (i == arr.Length - 1)
            //        {
            //            arr[i] = -1;
            //        }
            //        i--;
            //    }
            //}
            //return arr;
        } 
        public static int[] RearrangeArray( int[] arr)
        {
            var tempArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr.Any(a => a == i))
                {
                    tempArr[i] = i;
                }
                else
                {
                    tempArr[i] = -1;
                }
            }
            return tempArr;
        }

        #region Rotate Array
        //rotate(arr[], d, n)
        //reverse(arr[], 1, d);   ==> [1,2,3,4,5] => 21345 => 21543 =>34512
        //reverse(arr[], d + 1, n);
        //reverse(arr[], 1, n);

        public static int[] LeftRotateByReverse(int[] arr, int d)
        {
            int totallen = arr.Length;
            ReverseArray(arr, 0, d - 1);
            ReverseArray(arr, d, arr.Length-1);
            ReverseArray(arr, 0, arr.Length-1);
            return arr;
        }

        private static void ReverseArray(int[] arr, int start, int end )
        {
            while (start < end)
            {
                var temp = arr[end];
                arr[end] = arr[start];
                arr[start] = temp;
                start++;
                end--;
            }

        }

        public static int[] RightRotate(int[] arr, int d)
        {
            var tempArr = new int[arr.Length];
            //int[] tempArr = (int[])arr.Clone();
            Array.Copy(arr, tempArr,arr.Length);
            for (int i = 0; i < d; i++)
            {
                RightRotateArrayByOneElement(tempArr);
            }
            return tempArr;
        }
        private static void RightRotateArrayByOneElement( int[] arr)
        {
            int i = 0;
            int temp = arr[arr.Length-1];
            for (i = arr.Length - 1; i > 0; i--)
            {
                arr[i] = arr[i-1];
            }
            arr[i] = temp;
        }
        public static int[] LeftRoatate(int[] arr, int d)
        {
            var tempArr = new int[arr.Length];
            for (int i = 0; i < d; i++)
            {
                LeftRotateArrayByOneElement(tempArr);
            }
            return tempArr;
        }
        private static void LeftRotateArrayByOneElement(int[] arr)
        {
            int i = 0;
            int temp = arr[0];
            for ( i = 0; i < arr.Length-1; i++)
            {
                arr[i] = arr[i + 1];
            }

            arr[i] = temp;
        }
        #endregion
    }
}
