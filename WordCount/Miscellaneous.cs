using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public static class Miscellaneous
    {
		//Kadan's algorithm
		public static int ContiguousSubArrayWithMaximumSum(int[] arr)
		{
			//input = 1,-2,3,4,-5,5,6,-2,8,-4
			//output = 21
			int mef = 0;
			int msf = int.MinValue;
			for (int i = 0; i < arr.Length; i++)
			{
				mef += arr[i];
				if (mef < arr[i])
				{
					mef = arr[i];
				}

				if (msf < mef)
				{
					msf = mef;
				}
			}
			return msf;
		}
		public static void RotateRight(int[] arr, int d)
		{
			d %= arr.Length;
			reverseArray(arr, 0, arr.Length - 1);
			reverseArray(arr, 0, d - 1);
			reverseArray(arr, d, arr.Length - 1);


			//while (d > arr.Length)
			//{
			//	d -= arr.Length;
			//}
			//reverseArray(arr, 0, arr.Length - 1);
			//reverseArray(arr, d, arr.Length - 1);
			//reverseArray(arr, 0, d - 1);
		}
		public static void RotateLeft(int[] input, int d)
		{
			while (d > input.Length)
			{
				d -= input.Length;
			}
			var temp = new int[d];
			for (int i = 0; i < d; i++)
			{
				temp[i] = input[i];
			}

			for (int i = 0; i < input.Length - d; i++)
			{
				input[i] = input[i + d];
			}
			int len = input.Length;
			for (int i = temp.Length - 1; i >= 0; i--)
			{
				input[--len] = temp[i];
			}
			/*
			// input = 1,2,3,4,5,1,5
			//d = 3
			reverseArray(arr, 0, d - 1); // 3,2,1,4,5,1,5
			reverseArray(arr, d, arr.Length - 1);//3,2,1,5,1,5,4
			reverseArray(arr, 0, arr.Length - 1);//4,5,1,5,1,2,3
			*/
		}
		public static void reverseArray(int[] arr, int s, int e)
		{
			int temp;
			while (s < e)
			{
				temp = arr[s];
				arr[s] = arr[e];
				arr[e] = temp;
				s++;
				e--;
			}
		}
		public static int[] SortAlog(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				var temp = arr[i];
				int j = i - 1;
				while (j >= 0 && arr[j] >temp)
				{
					arr[j + 1] = arr[j];
					j--;
				}
				arr[j + 1] = temp;
			}
			return arr;
		}
		public static int[] RearrangeArrayReplaceAproach(int[] arr)
		{
			//i!=a[i]
			//a[i] >length || a[i] <0
			// if after step 1 it is not fixed (i--)

			int temp = 0;
			for (int i = 0; i < arr.Length;i++ )
			{
				if (arr[i] != i && arr[i] != -1 && arr[i] < arr.Length && arr[i] > -1)
				{
					temp = arr[i];
					arr[i] = arr[temp];
					arr[temp] = temp;
				}
				if (arr[i] == temp && i != arr[i] || arr[i] >arr.Length || arr[i] < -1)
				{
					arr[i] = -1;
					continue;
				}
				if (arr[i] != i && arr[i] != -1)
				{
					i--;
				}
			}
			return arr;
		}
		public static int SmallestPostiveinteger(int[] A)
		{
			int ind = 1;
			A = A.Distinct().ToArray();
			Array.Sort(A);
			// write your code in C# 6.0 with .NET 4.5 (Mono)
			for (int i = 0; i < A.Length; i++)
			{
				if (ind == A[i] && ind < int.MaxValue)
				{
					ind++;
				}
				else
				{
					return ind;
				}
			}
			return ind;
		}
		public static int A_Count(string s)
		{
			//if (s.Contains("aaa")) return -1;
			int a_count = 0;
			int count = 0;
			int len = s.Length;
			for (int i = 0; i<len;i++)
			{
				if (s[i] == 'a' )
				{
					a_count++;
				}
				else
				{
					count++;
					a_count = 0;
				}
				if (a_count == 3)
				{
					return -1;
				}
			}
			return 2*(count+1)-(len - count);
		}
		public static int countA(string s)
		{
			int count_As = 0, count_others = 0, s_len = s.Length;
			for (int i = 0; i < s_len; ++i)
			{
				if (s[i] == 'a')
				{
					count_As++;
				}
				else
				{
					count_others++;
					count_As = 0;
				}
				if (count_As == 3)
				{
					return -1;
				}
			}
			return 2 * (count_others + 1) - (s_len - count_others);
		}

	}

}
