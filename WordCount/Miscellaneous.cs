using System;
using System.Linq;

namespace WordCount
{
	using System;
    using System.Collections.Generic;

    public class Solution
	{
		public static void Masdin()
		{
			int maxTime = 360;
			int Testcases = Convert.ToInt32(Console.ReadLine());
			for (int i = 0; i < Testcases; i++)
			{
				string[] tokens = Console.ReadLine().Split(' ');
				int problems = int.Parse(tokens[0]);
				int traveltime = int.Parse(tokens[1]);
				if (traveltime >= 360)
				{
					Console.WriteLine(0);
					break; ;
				}
				int availableTime = maxTime - traveltime;
				int timeTaken = 0;
				int p;
				for (p = 1; p <= problems; p++)
				{
					timeTaken += p * 3;

					if (availableTime < timeTaken)
					{
						break; ;
					}
				}
				Console.WriteLine(p - 1);
			}
		}
	}
	public static class Miscellaneous
    {
		#region

		public static int PeakElement(int[] A)
		{
			int n = A.Length;
			int s = 0;
			int e = n - 1;
			int m = 0;

			while (s <= e)
			{
				m = s + (e - s) / 2;

				if (m > 0 && m < n - 1)
				{
					if (A[m] > A[m + 1] && A[m] > A[m - 1])
						return m;
					else if (A[m] < A[m + 1])
						s = m + 1;
					else
						e = m - 1;
				}
				else if (m == 0)
				{
					if (A[0] > A[1])
						return 0;
					else if (A[0] == A[1])
						return -1;
					else
						return 1;
				}
				else if (m == n - 1)
				{
					if (A[m] > A[m - 1])
						return m;
					else if (A[m] == A[m - 1])
						return -1;
					else
						return m - 1;
				}
			}

			

			return -1;
		}

		public static char NextAlphabeticalElement(char[] A, char srch)
		{
			int n = A.Length;
			int s = 0;
			int e = n-1;
			int m = 0;
			while (s <= e)
			{
				m = s + (e - s) / 2;
				if (A[m] == srch)
				{
					return A[(m + 1)%n];
				}
				else if (A[m] < srch)
				{
					s = m + 1;
				}
				else
				{
					e = m - 1;
				}
			}
			return '\0';
			
		}
		public static int ArrayRotated(int[] nums)
		{
			//All the integers of nums are unique

			int n = nums.Length;
			// If the list has just one element then return that element.
			if (nums.Length == 1)
			{
				return nums[0];
			}

			// initializing left and right pointers.
			int left = 0, right = nums.Length - 1;

			// if the last element is greater than the first element then there is no rotation.
			// e.g. 1 < 2 < 3 < 4 < 5 < 7. Already sorted array.
			// Hence the smallest element is first element. A[0]
			if (nums[right] > nums[0])
			{
				return nums[0];
			}

			while ( left <= right)
			{
				// Find the mid element
				int mid = left + (right - left) / 2;

				// if the mid element is greater than its next element then mid+1 element is the smallest
				// This point would be the point of change. From higher to lower value.
				if (nums[mid] > nums[mid + 1])
				{
					return mid + 1;
				}

				// if the mid element is lesser than its previous element then mid element is the smallest
				if (nums[mid - 1] > nums[mid])
				{
					return mid;
				}

				// if the mid elements value is greater than the 0th element this means
				// the least value is still somewhere to the right as we are still dealing with elements
				// greater than nums[0]
				if (nums[mid] > nums[0])
				{
					left = mid + 1;
				}
				else
				{
					// if nums[0] is greater than the mid value then this means the smallest value is somewhere to
					// the left
					right = mid - 1;
				}

			}

			return -1;
		}

		public static int FloorElementInSortedArray(int[] A, int ele)
		{
			int res = -1;
			int n = A.Length;
			int s = 0;
			int e = n - 1;
			int m = 0;

			while (s <= e)
			{
				m = s + (e - s) / 2;

				if (A[m] == ele)
				{
					return ele;
				}
				else if (A[m] < ele)
				{
					res = A[m];
					s = m + 1;
				}
				else if (A[m] > ele)
				{
					e = m - 1;
				}
			}

			return res;
		}

        public static int CountElement(int[] A, int srh)
		{
			int first = BinarySearchForFirstElement(A, srh);
			int last = BinarySearchForlastElement(A, srh);
			int res = last - first + 1;
			return res;
		}
		public static int BinarySearchForFirstElement(int[] A, int srh)
		{
			int n = A.Length;
			int s = 0;
			int e = n - 1;
			int m = 0;
			int res = -1;
			while (s <= e)
			{
				m = s + (e - s) / 2;
				if (srh == A[m])
				{
					e = m - 1;
					res = m;
				}
				else if (srh < A[m])
				{
					e = m - 1;
				}
				else
				{
					s = m + 1;
				}
			}
			return res;
		}
		public static int BinarySearchForlastElement(int[] A, int srh)
		{
			int n = A.Length;
			int s = 0;
			int e = n - 1;
			int m = 0;
			int res = -1;
			while (s <= e)
			{
				m = s + (e - s) / 2;
				if (srh == A[m])
				{
					s = m + 1;
					res = m;
				}
				else if (srh < A[m])
				{
					e = m - 1;
				}
				else
				{
					s = m + 1;
				}
			}
			return res;
		}
		public static int BinarySearch(int[] A, int srh)
		{
			int n = A.Length;
			int s = 0;
			int e = n-1;
			int m = 0;

			while(s<=e)
			{
				m = s+(e-s)/ 2;
				if (srh == A[m])
				{
					return m;
				}
				else if (srh > A[m])
				{
					s = m + 1;
				}
				else
				{
					e = m - 1;
				}
			}
			return -1;
		}

		#endregion
		public static List<int> spiralOrder(List<List<int>> A)
		{
			int n = A.Count;
			int m = A[0].Count;
			int dir = 0;
			int T = 0;
			int R = m - 1;
			int L = 0;
			int B = n - 1;
			List<int> result = new List<int>();

			while (L <= R && T <= B)
			{
				if (dir == 0)
				{
					for (int i = L; i <= R; i++)
					{
						result.Add(A[T][i]);
					}
					T++;
				}
				else if (dir == 1)
				{
					for (int i = T; i <= B; i++)
					{
						result.Add(A[i][R]);
					}
					R--;
				}
				else if (dir == 2)
				{
					for (int i = R; i >= L; i--)
					{
						result.Add(A[B][i]);
					}
					B--;
				}
				else if (dir == 3)
				{
					for (int i = B; i >= T; i--)
					{
						result.Add(A[i][L]);
					}
					L++;
				}
				dir = (dir + 1) % 4;
			}
			return result;
		}
		public static int solve(List<int> A, int B)
		{
			int n = A.Count;
			int sum = 0;
			for (int i = 0; i < B; i++)
			{
				sum += A[i];
			}
			int res = int.MinValue;
			for (int i = 0; i < B; i++)
			{
				sum += A[n - 1 - i];
				sum -= A[B - 1 - i];
				if (res < sum)
				{
					res = sum;
				}
			}
			return res;
		}


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
