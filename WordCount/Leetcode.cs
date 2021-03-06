﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class MyHashSet
    {
    }
 
    public static class Leetcode
    {
       
        public static int RainWaterTrap(int[] height)
        {
            int n = height.Length;
            int[] maxl = new int[n];
            int[] maxr = new int[n];
            int[] maxWater = new int[n];
            int totalArea = 0;

            maxr[n - 1] = height[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                maxr[i] = Math.Max(maxr[i + 1], height[i]);
            }

            maxl[0] = height[0];
            maxWater[0] = Math.Min(maxl[0], maxr[0]);
            totalArea = maxWater[0] - height[0];
            for (int i = 1; i < n; i++)
            {
                maxl[i] = Math.Max(maxl[i - 1], height[i]);
                maxWater[i] = Math.Min(maxl[i], maxr[i]);
                totalArea += maxWater[i] - height[i];
            }

            return totalArea;
        }
        public static int RainWaterTrap_old(int[] height)
        {
            int n = height.Length;
            int[] maxl = new int[n];
            int[] maxr = new int[n];
            int[] maxWater = new int[n];
            int[] area = new int[n];
            int totalArea = 0;
            maxl[0] = height[0];
            for (int i = 1; i < n; i++)
            {
                maxl[i] = Math.Max(maxl[i-1], height[i]);
            }
            maxr[n-1] = height[n-1];
            for (int i = n - 2; i >= 0; i--)
            {
                maxr[i] = Math.Max(maxr[i+1], height[i]);
            }

            maxWater[0] = maxl[0];
            for (int i = 0; i < n; i++)
            {
                maxWater[i] = Math.Min(maxl[i], maxr[i]);
            }

            for (int i = 0; i < n; i++)
            {
                area[i] = maxWater[i] - height[i];
            }
            for (int i = 0; i < n; i++)
            {
                totalArea += area[i];
            }

            return totalArea;
        }

        public static int MaxAreaOfRectInBinarySearch(int[][] A)
        {
            int n = A[0].Length;
            int[] prev = new int[n];

            for (int j = 0; j < n; j++)
            {
                prev[j] = A[0][j];
            }
            int max = LargestRectangleArea(prev);

            for (int i = 1; i < A.Length; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (A[i][j] == 0)
                    {
                        prev[j] = 0;
                    }
                    else
                    {
                        prev[j] += A[i][j];
                    }
                }
                max = Math.Max(max, LargestRectangleArea(prev));
            }
            return max;
        }
        public static int MaximalRectangle(char[][] A)
        {
            if (A == null || A.Length <= 0)
            {
                return 0;
            }
            int n = A[0].Length;
            int[] prev = new int[n];
            int ap = 0;
            for (int j = 0; j < n; j++)
            {
                ap = (int)char.GetNumericValue(A[0][j]);
                prev[j] = ap;
            }
            int max = LargestRectangleArea(prev);

            for (int i = 1; i < A.Length; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ap = (int)char.GetNumericValue(A[i][j]);
                    if (ap == 0)
                    {
                        prev[j] = 0;
                    }
                    else
                    {
                        ap = (int)char.GetNumericValue(A[i][j]);
                        prev[j] += ap;
                    }
                }
                max = Math.Max(max, LargestRectangleArea(prev));
            }
            return max;
        }
        public static int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;
            var nslArr = NSL(heights);
            var nsrArr = NSR(heights);

            var width = new int[n];
            var area = new int[n];

            int maxArea = 0;
            for (int i = 0; i < n; i++)
            {
                width[i] = nsrArr[i] - nslArr[i] - 1;
                area[i] = width[i] * heights[i];

                if (maxArea < area[i])
                {
                    maxArea = area[i];
                }
            }

            return maxArea;
        }

        public static int[] NSR(int[] A)
        {
            int n = A.Length;
            Stack<int> stk = new Stack<int>();
            int[] res = new int[n];
            int psudoIndex = n;
            for (int i = n - 1; i >= 0; i--)
            {
                if (stk.Count == 0)
                {
                    res[i] = psudoIndex;
                }
                else if (A[stk.Peek()] < A[i])
                {
                    res[i] = stk.Peek();
                }
                else
                {
                    while (stk.Count > 0 && A[stk.Peek()] >= A[i])
                    {
                        stk.Pop();
                    }
                    if (stk.Count == 0)
                    {
                        res[i] = psudoIndex;
                    }
                    else
                    {
                        res[i] = stk.Peek();
                    }
                }
                stk.Push(i);
            }
            return res;
        }

        public static int[] NSL(int[] A)
        {
            int n = A.Length;
            Stack<int> stk = new Stack<int>();
            int[] res = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (stk.Count == 0)
                {
                    res[i] = -1;
                }
                else if (A[stk.Peek()] < A[i])
                {
                    res[i] = stk.Peek();
                }
                else
                {
                    while (stk.Count > 0 && A[stk.Peek()] >= A[i])
                    {
                        stk.Pop();
                    }
                    if (stk.Count == 0)
                    {
                        res[i] = -1;
                    }
                    else if (A[stk.Peek()] < A[i])
                    {
                        res[i] = stk.Peek();
                    }
                }
                stk.Push(i);
            }
            return res;
        }

        public static int[] StockSpanner(int[] A)
        {
            int n = A.Length;
            int[] output = new int[n];
            int[] temp = new int[n];
            Stack<int> stk = new Stack<int>(); 

            for (int i = 0; i < n; i++)
            {
                if (stk.Count == 0)
                {
                    temp[i] = -1;
                }
                else if (A[stk.Peek()] > A[i])
                {
                    temp[i] = stk.Peek();
                }
                else
                {
                    while (stk.Count > 0 && A[stk.Peek()] <= A[i])
                    {
                        stk.Pop();
                    }
                    if (stk.Count == 0)
                    {
                        temp[i] = -1;
                    }
                    else
                    {
                        temp[i] = stk.Peek();
                    }
                }
                stk.Push(i);
            }
            for (int i = 0; i < n; i++)
            {
                output[i] = i - temp[i];
            }
                return output;
        }
        public static List<int> prevSmaller(int[] A)
        {
            int n = A.Length;
            int[] Arr = new int[n];
            var stk = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                if (stk.Count == 0)
                {
                    Arr[i] = -1;
                }
                else if (stk.Peek() < A[i])
                {
                    Arr[i] = stk.Peek();
                }
                else
                {
                    while (stk.Count > 0 && stk.Peek() >= A[i])
                    {
                        stk.Pop();
                    }
                    if (stk.Count == 0)
                    {
                        Arr[i] = -1;
                    }
                    else if (stk.Peek() < A[i])
                    {
                        Arr[i] = stk.Peek();
                    }
                }
                stk.Push(A[i]);
            }
            return Arr.ToList();
        }
        public static IList<int> CountSmaller(int[] nums)
        {
            int n = nums.Length;
            var res = new int[n];
            var stk = new Stack<int>();
            int i = 0;
            int cnt;
            for (int j = 0; j < n; j++)
            {
                cnt = 0;
                i = j +1;
                stk.Push(j);

                while (stk.Count > 0 && i < n)
                {
                    if (nums[i] < nums[stk.Peek()])
                    {
                        cnt++;
                    }
                    i++;
                }
                res[j] = cnt;
                stk.Pop();
            }
            return res;
        }
        public static IList<int> CountSmaller_wrong(int[] nums)
        {
            int n = nums.Length;
            var res = new int[n];
            var stk = new Stack<int>();
            int[] temp = new int[n];
            for (int x = 0; x < n; x++)
            {
                res[x] = 0;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                int j = 0;
                if (stk.Count == 0)
                {
                    stk.Push(nums[i]);
                    continue;
                }
                if (stk.Count != 0 && stk.Peek() == nums[i])
                {
                    res[i] = stk.Count - 1;
                    continue;
                }
                while (j < n && stk.Count != 0 && stk.Peek() > nums[i])
                {
                    temp[j++] = stk.Pop();
                }
                if (stk.Count != 0 && stk.Peek() < nums[i])
                {
                    res[i] = stk.Count;
                    stk.Push(nums[i]);
                }

                for (int x = 0; x < j; x++)
                {
                    stk.Push(temp[x]);
                }
            }
            return res;
        }
        public static int[] NextGreaterElements(int[] nums)
        {
            int n = nums.Length;
                var next = new int[n];
            for (int i = 0; i < n; i++)
            {
                next[i] = -1;
            }
            Stack<int> stack = new Stack<int>(); // index stack
            for (int i = 0; i < n * 2; i++)
            {
                int num = nums[i % n];
                while (stack.Count !=0 && nums[stack.Peek()] < num)
                    next[stack.Pop()] = num;
                if (i < n) 
                    stack.Push(i);
            }
            return next;
        }
        public static int[] NextGreaterElements_old (int[] nums)
        {
            if (nums.Length <= 0)
                return nums;
            int[] res = new int[nums.Length];
            if (nums.Length == 1)
            {
                res[0] = -1;
                return res;
            }
            var stk = new Stack<int>();
            int temp = nums[nums.Length - 1];
            int v = int.MinValue;
            var ind = -1;
            int k = 0;
            while ( k < nums.Length - 1 && res[nums.Length - 1] == 0)
            {
                if (temp < nums[k])
                {
                    res[nums.Length - 1] = nums[k];
                    stk.Push(nums[k]);
                    ind = k;
                }
                k++;
            }
            if (res[nums.Length - 1] == 0)
            {
                res[nums.Length - 1] = -1;
                stk.Push(nums[nums.Length - 1]);
            }
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (stk.Count == 0)
                {
                    res[i] = -1;
                    stk.Push(nums[i]);
                }

                if (stk.Peek() == nums[i])
                {
                    res[i] = -1;
                }
                while (stk.Peek() < nums[i])
                {
                    res[i] = stk.Pop();
                    stk.Push(nums[i]);
                }
                while (stk.Peek() > nums[i])
                {
                    res[i] = stk.Peek();
                    stk.Push(nums[i]);
                }
            }
            if (ind != -1)
                res[ind] =-1;
            return res;
        }

        public static int FindMin(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;
            if (nums.Length == 1)
            {
                return nums[0];
            }
            // if(nums[high]>nums[0]) return nums[0];
            while (low < high)
            {
                int mid = (low + high) / 2;
                Console.WriteLine(mid);
                if (nums[mid] > nums[high])
                    low = mid + 1;
                else if (nums[mid] < nums[high])
                    high = mid;
                else
                    high--;
            }
            return nums[low];
        }
        public static int[] ReplaceElements(int[] arr)
        {
            var stk = new Stack<int>();
            var res = new int[arr.Length];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (stk.Count == 0)
                {
                    res[i] = -1;
                    stk.Push(arr[i]);
                }
                else if (stk.Peek() < arr[i])
                {
                    res[i] = stk.Pop();
                    stk.Push(arr[i]);
                }
                else
                {
                    res[i] = stk.Peek();
                }
            }
            return res;
        }
        public static IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var dict = new SortedDictionary<int[], int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums1.Length; j++)
                {
                    var arr = new int[] { nums1[i], nums2[j] };
                    if (dict.ContainsKey(arr))
                    {
                        dict[arr] += 1;
                    }
                    else
                    {
                        dict.Add(arr, 1);
                    }
                }
            }
            var res = new List<IList<int>>();
            foreach (var dic in dict)
            {
                for (int i = 0; i < dic.Value & i <k; i++)
                {
                    res.Add(dic.Key.ToList());
                }
            }
            return res;
        }
        public static int LargestSumAfterKNegations(int[] A, int k)
        {

            Array.Sort(A);
            int sum = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] < 0 && k > 0)
                    {
                        A[i] = -A[i];
                        sum += A[i];
                        k--;
                    }
                    else if (k % 2 == 0 && A[i] >= 0)
                    {
                        k = 0;
                        sum += A[i];
                    }
                    else if (k > 0)
                    {
                        k--;
                        sum += -A[i];
                    }
                    else
                    {
                        sum += A[i];
                    }
                }
                return sum;
        }

        public static string MinWindow(string s, string t)
        {
            var dict = new Dictionary<char, int>();
            for (int k = 0; k < t.Length; k++)
            {
                if (!dict.ContainsKey(t[k]))
                {
                    dict.Add(t[k], 0);
                }
                dict[t[k]] += 1;
            }
         
            int dmct = t.Length;
            int mct = 0;
            var map1 = new Dictionary<char, int>();
            int i = -1;
            int j = -1;
            string ans = "";
            while (true)
            {
                bool f1 = false;
                bool f2 = false;
                while (i < s.Length-1 && mct < dmct)
                {
                    i++;
                    if (!map1.ContainsKey(s[i]))
                    {
                        map1.Add(s[i], 0);
                    }
                    map1[s[i]] += 1;

                    if (dict.ContainsKey(s[i]) && map1[s[i]] <= dict[s[i]])
                    {
                        mct++;
                    }
                    f1 = true;
                }
                
                while (j < i && mct == dmct)
                {
                    string pans = s.Substring(j + 1, i - j);
                    if (ans.Length == 0 || pans.Length <= ans.Length)
                    {
                        ans = pans;
                    }
                    j++;
                    if (map1[s[j]] == 1)
                    {
                        map1.Remove(s[j]);
                    }
                    else
                    {
                        map1[s[j]] -= 1;
                    }
                    if ((dict.ContainsKey(s[j]) && !map1.ContainsKey(s[j])) ||(map1.ContainsKey(s[j]) && dict.ContainsKey(s[j]) && map1[s[j]] < dict[s[j]]))
                    {
                        mct--;
                    }
                    f2 = true;
                }

                if (f1==false && f2==false )
                {
                    break;
                }
                
            }
            return ans;
        }
        public static Dictionary<Char, int> CharFrequency(string s)
        {
            var dict = new Dictionary<Char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict.Add(s[i], 0);
                }
                dict[s[i]] += 1;
            }
            return dict;
        }

        public static bool CheckInclusion(string s1, string s2)
        {
            int len1 = s1.Length, len2 = s2.Length;
            if (len1 > len2) return false;

            int[] count = new int[26];
            for (int i = 0; i < len1; i++)
            {
                count[s1[i] - 'a']++;
                count[s2[i] - 'a']--;
            }
            if (allZero(count)) return true;

            for (int i = len1; i < len2; i++)
            {
                count[s2[i] - 'a']--;
                count[s2[i - len1] - 'a']++;
                if (allZero(count)) return true;
            }

            return false;
        }

        private static bool allZero(int[] count)
        {
            for (int i = 0; i < 26; i++)
            {
                if (count[i] != 0) return false;
            }
            return true;
        }
        public static int LengthOfLongestSubstring(string s)
        {
            int ans = 0;
            var hash = new HashSet<char>();
            int j = 0;
            int i = 0;
            while (j < s.Length)
            {
                if (!hash.Contains(s[j]))
                {
                    hash.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else
                {
                    hash.Remove(s[i++]);
                }
            }

            return ans;
        }

        public static int[] ProductExceptSelf(int[] input)
        {
            int len = input.Length;
            var frwd = new int[len];
            var bkwd = new int[len];
            var ans = new int[len];

            bkwd[len - 1] = 1;
            for (int i = len - 2; i >= 0; i--)
            {
                bkwd[i] = bkwd[i + 1] * input[i + 1];
            }
            frwd[0] = 1;
            for (int i = 1; i < len; i++)
            {
                frwd[i] = frwd[i - 1] * input[i - 1];
            }

            for (int i = 0; i < len; i++)
            {
                ans[i] = frwd[i] * bkwd[i];
            }
            return ans;
        }
        public static int LongestMountain(int[] input)
        {

            int len = input.Length;
            int[] up = new int[len];
            int[] down = new int[len];



            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] < input[i])
                {
                    up[i] = up[i - 1] + 1;
                }
            }
            for (int i = len - 2; i >= 0; i--)
            {
                if (input[i] > input[i + 1])
                {
                    down[i] = down[i + 1] + 1;
                }
            }
            int res = 0;
            for (int i = 0; i < len; i++)
            {
                if (up[i] != 0 && down[i] != 0)
                {
                    if (res < up[i] + down[i] + 1)
                    {
                        res = up[i] + down[i] + 1;
                    }
                }
            }
            return res;

            //int N = A.Length, res = 0;
            //int[] up = new int[N];
            //var down = new int[N];
            //for (int i = N - 2; i >= 0; --i)
            //{
            //    if (A[i] > A[i + 1])
            //        down[i] = down[i + 1] + 1;
            //}

            //for (int i = 0; i < N; ++i)
            //{
            //    if (i > 0 && A[i] > A[i - 1]) 
            //        up[i] = up[i - 1] + 1;
            //    if (up[i] > 0 && down[i] > 0)
            //        res = Math.Max(res, up[i] + down[i] + 1);
            //}
            //return res;
        }
        public static int LongestMountain_notWorking(int[] arr)
        {
            if (arr.Length < 3)
            {
                return 0;
            }
            bool trend = true;
            bool isUp = false;
            bool isdown = false;
            int ans = 0;
            int res = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] < arr[i])
                {
                    if (trend != true)
                    {
                        ans = 0;
                        ans += res;
                        res = 1;
                    }
                    isUp = true;
                    trend = true;
                }
                else if (arr[i - 1] > arr[i])
                {
                    isdown = true;
                    trend = false;
                }
                else
                {
                    trend = false;
                    isdown = false;
                    isUp = false;
                }
                res++;
            }

            if ((isdown && !isUp) || (isUp && !isdown) || (!isUp && !isdown))
            {
                return 0;
            }

            if (ans < res)
            {
                ans = res;
            }
            return ans;
        }
        public static int CountSubstrings(string s)
        {
            var palindromArr = new List<string>();
            var st = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                var str = new StringBuilder();
                str.Append(s[i]);

                for (int j = i + 1; j < s.Length; j++)
                {
                    str.Append(s[j]);
                    st = str.ToString();
                    if (new string(st.Reverse().ToArray()) == st)
                    {
                        palindromArr.Add(st);
                    }
                }
            }
            return palindromArr.Count + s.Length;
        }

        public static int LengthOfLIS(int[] nums)
        {
            int[] temp = new int[nums.Length];
            temp[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                temp[i] = 1;
                for (int j = i; j >= 0; j--)
                {
                    if (nums[j] >= nums[i])
                    {
                        continue;
                    }
                    int possibleAns = temp[j] + 1;
                    if (possibleAns > temp[i])
                    {
                        temp[i] = possibleAns;
                    }
                }
            }
            int res = 0;
            for (int k = 0; k < temp.Length; k++)
            {
                if (temp[k] > res)
                {
                    res = temp[k];
                }
            }
            return res;
        }
        public static int MaxProduct(int[] nums)
        {

            int mef = 1;
            int msf = int.MinValue;
            int c = 0;
            int p = 1;
            int prev = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    if (prev < p)
                    {
                        prev = p;
                    }
                    c = 0;
                    continue;
                }

                if (nums[i] < 0)
                {
                    c++;
                }

                p = p * nums[i];
            }
            if (c != 0 && c % 2 == 0)
            {
                if (prev < p)
                {
                    prev = p;
                }
                return prev;
            }
            int si = 0;
            int sp = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    sp *= nums[i];
                    si = i;
                    break;
                }
                sp *= nums[i];
            }
            int ep = 1;
            int ei = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] < 0)
                {
                    ep *= nums[i];
                    ei = i;
                    break;
                }
                ep *= nums[i];
            }

            if (si != ei)
            {
                int ind = si;
                int resp = 1;
                prev = 1;
                if (sp < ep)
                {

                    for (int i = 0; i < ei; i++)
                    {
                        if (nums[i] == 0)
                        {
                            if (prev < resp)
                            {
                                prev = resp;
                            }
                            c = 0;
                            continue;
                        }
                        resp *= nums[i];
                    }
                }
                else
                {
                    for (int i = nums.Length - 1; i > si; i--)
                    {
                        if (nums[i] == 0)
                        {
                            if (prev < resp)
                            {
                                prev = resp;
                            }
                            c = 0;
                            continue;
                        }

                        resp *= nums[i];
                    }
                }
                if (prev > resp)
                {
                    return prev;
                }
                return resp;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                mef = mef * nums[i];
                {
                    if (mef < nums[i])
                    {
                        mef = nums[i];
                    }
                }
                if (msf < mef)
                {
                    msf = mef;
                }
            }
            return msf;
        }
        public static IList<IList<int>> KSmallestPairs_old(int[] nums1, int[] nums2, int k)
        {
            var res = new List<int[]>();
            if (nums1 == null || nums2 == null || nums1.Length == 0 || nums2.Length == 0)
            {
                return res.ToArray();
            }
            int i = 0;
            int j = 0;
            int sum = nums1[i] + nums2[j];
            if (nums1.Length == 1)
            {
                for (int x = 0; x < k - 1 && x < nums2.Length; x++)
                {
                    res.Add(new int[] { nums1[0], nums2[x] });
                }
                return res.ToArray();
            }
            else if (nums2.Length == 1)
            {
                for (int x = 0; x < k - 1 && x < nums1.Length; x++)
                {
                    res.Add(new int[] { nums1[x], nums2[0] });
                }
                return res.ToArray();
            }
            res.Add(new int[] { nums1[i], nums2[j] });

            while (k > res.Count)
            {
                if (j >= nums2.Length - 1 && i >= nums1.Length - 1)
                {
                    break;
                }
                if (j >= nums2.Length - 1)
                {
                    j--;
                }
                if (i >= nums1.Length - 1)
                {
                    i--;
                }

                var sum1 = nums1[i + 1] + nums2[j];
                var sum2 = nums1[i] + nums2[j + 1];

                if (sum1 < sum2)
                {
                    res.Add(new int[] { nums1[i + 1], nums2[j] });
                    i++;
                }
                else if (sum1 == sum2)
                {
                    res.Add(new int[] { nums1[i], nums2[j + 1] });
                    res.Add(new int[] { nums1[i + 1], nums2[j] });
                    //j++;
                    i++;
                }
                else
                {
                    res.Add(new int[] { nums1[i], nums2[j + 1] });
                    j++;
                }
            }
            return res.ToArray();
        }


        public static int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return new int[] { -1, -1 };
            }
            int s = 0;
            int e = nums.Length;

            int ind = 0;
            while (s < e)
            {
                int mid = (s + e) / 2;
                if (target < nums[mid])
                {
                    e = mid;
                }
                else if (target > nums[mid])
                {
                    s = mid + 1;
                }
                else if (target == nums[mid])
                {
                    ind = mid;
                    break;
                }
                else
                {
                    return new int[] { -1, -1 };
                }
            }
            if (s >= e)
            {
                return new int[] { -1, -1 };
            }
            int start = ind;
            while (start >= 0 && nums[start] == target)
            {
                start--;
            }
            int end = ind;
            while (end < nums.Length && nums[end] == target)
            {
                end++;
            }
            return new int[] { start + 1, end - 1 };
        }
        public static string DecodeString(string s)
        {
            var counts = new Stack<int>();
            var strStack = new Stack<string>();
            int index = 0;
            string res = "";
            while (index < s.Length)
            {
                if (char.IsDigit(s[index]))
                {
                    int count = 0;
                    while (char.IsDigit(s[index]))
                    {
                        count = 10 * count + (s[index] - '0');
                        index++;
                    }
                    counts.Push(count);
                }
                else if (s[index] == '[')
                {
                    strStack.Push(res);
                    res = "";
                    index++;
                }
                else if (s[index] == ']')
                {
                    var temp = strStack.Pop();
                    var cnt = counts.Pop();

                    for (int i = 0; i < cnt; i++)
                    {
                        temp += res;
                    }
                    res = temp;
                    index++;
                }
                else
                {
                    res = res + s[index];
                    index++;
                }
            }
            return res;
        }

        public static IList<IList<int>> ThreeSumAgain(int[] nums)
        {
            Array.Sort(nums);
            var arr = new int[3];
            var list = new HashSet<int[]>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int j = i + 1;
                    int k = nums.Length - 1;
                    while (j < k)
                    {
                        var sum = nums[i] + nums[j] + nums[k];
                        if (sum == 0)
                        {
                            list.Add(new int[] { nums[i], nums[j], nums[k] });
                            while (j < k && nums[j] == nums[j + 1]) { j++; }
                            while (j < k && nums[k] == nums[k - 1]) { k--; }
                        }
                        if (sum > 0)
                        {
                            k--;
                        }
                        else
                        {
                            j++;
                        }
                    }
                }
            }
            return list.ToArray();
        }
        static HashSet<int> arrhash = new HashSet<int>();
        //public static int LengthOfLIS(int[] nums) //guess not working
        //{
        //    nums = new int[] { 10, 9, 2, 5, 3, 7, 101, 17, 18 };
        //    GetSubArrayLength(nums, 0);
        //    int max = arrhash.Max();
        //    return max;
        //}
        private static void GetSubArrayLength(int[] nums, int pos)
        {
            if (nums.Length <= pos)
            {
                return;
            }
            var arr = new HashSet<int>();
            int temp = nums[pos];
            int i = 0;
            foreach (int a in nums)
            {
                if (i < pos)
                {
                    i++;
                    continue;
                }
                if (temp <= a)
                {
                    arr.Add(a);
                }
            }
            arrhash.Add(arr.Count);
            GetSubArrayLength(nums, pos + 1);
        }

        public static void NextPermutation(int[] nums)
        {
            //nums = new int[] { 1, 3, 2,4,5,3 }; //1,3,2,5,3,4
            //nums = new int[] { 1, 2, 3 };//132
            //nums = new int[] { 3, 2, 1 };//123
            //nums = new int[] { 1, 3, 2 };//213
            nums = new int[] { 1, 2, 4, 5, 3 };//12534
            int j = 0;
            int temp = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                j = i - 1;
                if (nums[i] > nums[j])
                {
                    var jpos = j;
                    var tempj = nums[j];
                    while (j < nums.Length)
                    {

                        if (tempj > nums[j] || j == nums.Length - 1)
                        {
                            temp = nums[i];
                            nums[i] = nums[j];
                            nums[j] = temp;
                            Array.Reverse(nums, jpos, nums.Length - jpos);
                            return;
                        }
                        j++;
                    }
                    return;
                }
            }
            Array.Reverse(nums);
        }

        public static void RotateRight(int[] arr)
        {
            int temp = arr[arr.Length - 1];
            int i = 0;
            for (i = arr.Length - 1; i > 0; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[i] = temp;
        }

        public static int[][] Merge(int[][] intervals)
        {
            //Input: intervals = [[1, 3],[8,10],[15,18],[2,6]]
            //Output:[[1,6],[8,10],[15,18]]
            //Explanation: Since intervals[1, 3] and[2, 6] overlaps, merge them into[1, 6].
            Array.Sort(intervals, (s, e) => s[0].CompareTo(e[0]));
            var res = new List<int[]>();
            for (int i = 0; i < intervals.Length; i++)
            {
                if (res.Count == 0 || res[res.Count - 1][1] < intervals[i][0])
                {
                    res.Add(intervals[i]);
                }
                else
                {
                    res[res.Count - 1][1] = Math.Max(res[res.Count - 1][1], intervals[i][1]);
                }
            }
            return res.ToArray();

        }
        public static int kadanaAlgorith(int[] arr)
        {
            int mef = 0;
            int msf = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                mef = mef + arr[i];
                if (mef < arr[i])
                {
                    mef = arr[i];
                }
                if (mef > msf)
                {
                    msf = mef;
                }
            }

            return msf;
        }
        public static void Merge(int[] larr, int m, int[] sarr, int n)
        {
            int[] arr = new int[m + n];
            int l = 0;
            int s = 0;
            int sl = 0;
            while (m > l && n > s)
            {
                if (larr[l] < sarr[s])
                {
                    arr[sl] = larr[l];
                    l++;
                }
                else
                {
                    arr[sl] = sarr[s];
                    s++;
                }
                sl++;
            }
            if (sl < m + n)
            {
                while (s < n)
                {
                    arr[sl] = sarr[s];
                    s++;
                    sl++;
                }

                while (l < m)
                {
                    arr[sl] = larr[l];
                    l++;
                    sl++;
                }
            }
            larr = arr;
        }
        public static int[] mergeTwoSortedArray(int[] s, int[] B)
        {
            int m = s.Length;
            int n = B.Length;
            int[] A = new int[m + n];
            for (int i = 0; i < A.Length; i++)
            {
                if (i >= m)
                {
                    A[m] = int.MinValue;
                }
                else
                {
                    A[i] = s[i];
                }
            }
            while (m > 0 && n > 0)
            {
                if (A[m - 1] > B[n - 1])
                {
                    A[m + n - 1] = A[m - 1];
                    m--;
                }
                else
                {
                    A[m + n - 1] = B[n - 1];
                    n--;
                }
            }

            while (n > 0)
            {
                A[m + n - 1] = B[n - 1];
                n--;
            }

            /*
            int[] arr1 = new int[0];
            int[] arr2 = new int[0];
            if (larr.Length < sarr.Length)
            {
                arr1 = sarr;
                arr2 = larr;
            }
            int m = arr1.Length;
            int n = arr2.Length;
            // code here
            HashSet<int> AnsArr = new HashSet<int>();
            int s = 0; int l = 0; int a = 0;
            while (s < n)
            {
                if (arr1[l] < arr2[s])
                {
                    AnsArr.Add(arr1[l]);
                    l++;
                    a++;
                }
                else
                {
                    AnsArr.Add(arr2[s]);
                    s++;
                    a++;
                }
            }
            while (l < m+n)
            {
                AnsArr.Add(arr1[s]);
                l++;
            }
            */
            return A;
        }

        public static int FindDuplicate(int[] nums)
        {
            HashSet<int> hset = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (hset.Add(nums[i]))
                {
                    return nums[i];
                }

            }
            return 0;
        }

        //N=11 
        //arr=1 3 5 8 9 2 6 7 6 8 9 
        //Output: 3 
        //Explanation: 
        //First jump from 1st element to 2nd
        //element with value 3. Now, from here
        //we jump to 5th element with value 9,
        //and from here we will jump to last.
        public static int minJumps(int[] arr)
        {
            int jump = 0;
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                temp = arr[i];
                if (i < arr.Length)
                {
                    i += temp;
                    jump++;

                }
            }
            return jump;
        }

        public static int getMinDiff(int[] arr, int k)
        {

            Array.Sort(arr);
            var min = -1;
            int l = 0;
            while (min <= arr[l] && min < 0)
            {
                min = arr[l] - k;
                l++;
            }
            var max = arr[arr.Length - 1] - k;

            return max - min;
        }

        public static int MaxSubArray(int[] nums)
        {
            int mef = 0;
            int msf = Int32.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                mef = mef + nums[i];
                if (mef < nums[i])
                {
                    mef = nums[i];
                }
                if (msf < mef)
                {
                    msf = mef;
                }
            }
            return msf;
        }
        public static int FindKthLargest(int[] nums, int k)
        {

            int len = nums.Length;
            if (len < k)
            {
                return 0;
            }
            int j = 0;
            int temp;
            for (int i = 1; i < nums.Length; i++)
            {
                temp = nums[i];
                j = i - 1;

                while (j >= 0 && nums[j] > temp)
                {
                    nums[j + 1] = nums[j];
                    j--;
                }
                nums[j + 1] = temp;

            }
            return nums[len - k];

        }

        public static int NumberOfArithmeticSlices(int[] A)
        {
            int counts = 0;
            if (A.Length == 0)
            {
                return counts;
            }

            Dictionary<int, int>[] dp = new Dictionary<int, int>[A.Length];
            dp[0] = new Dictionary<int, int>();
            for (int i = 1; i < A.Length; i++)
            {
                dp[i] = new Dictionary<int, int>();
                for (int j = i - 1; j >= 0; j--)
                {
                    long diff = (long)A[i] - (long)A[j];
                    if (diff <= Int32.MinValue || diff > Int32.MaxValue) continue;
                    int df = (int)diff;
                    if (!dp[i].ContainsKey(df))
                    {
                        dp[i][df] = 0;
                    }

                    dp[i][df]++;

                    // Get j's dictionary for the given diff.
                    if (dp[j].ContainsKey(df))
                    {
                        var jsDiffCounts = dp[j][df];
                        dp[i][df] += jsDiffCounts;
                        counts += dp[j][df];
                    }
                }
            }

            return counts;

        }

        /*
        public static int NumberOfArithmeticSlices(int[] A)
        {
            //iterate
            //if(j++ =< A.Max())
            //ith j++ ith +1
            //else break
            //if(j++2 > A.Max())
            //ith j++ ith +2
            //else break
            int val = 0;
            if (A[2] - A[1] < 0)
            {
                val = A.Min();
            }
            else
            {
                val = A.Max();
            }
            int count = 0;
            if (0 <= val)
            {
                for (int j = 0; j < val; j++)
                {
                    int ApLen = 0;
                    for (int i = 0; i < A.Length; i++)
                    {
                        if (i + 1 >= A.Length || A[i] + j > A[i + 1])
                        {
                            break;
                        }
                        if (A[i] + j == A[i + 1])
                        {
                            ApLen++;
                            if (ApLen >= 2)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int j = 0; j > val; j--)
                {
                    int ApLen = 0;
                    for (int i = 0; i < A.Length; i++)
                    {
                        if (i + 1 >= A.Length || A[i] + j > A[i + 1])
                        {
                            break;
                        }
                        if (i + 1 < A.Length && A[i] + j == A[i + 1])
                        {
                            ApLen++;
                            if (ApLen > 2)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }
        */
        public static int MinSetSize(int[] arr)
        {

            var dic = new Dictionary<int, int>();
            var len = arr.Length;
            for (int i = 0; i < arr.Length; i++)
            {
                if (dic.ContainsKey(arr[i]))
                {
                    dic[arr[i]] += 1;
                }
                else
                {
                    dic.Add(arr[i], 1);
                }
            }
            var c = MaxIntCount(dic, len);
            return c;
        }
        static int count;
        static int maxFreqInt;
        static int MaxIntCount(Dictionary<int, int> dict, int len)
        {
            count++;
            maxFreqInt += dict.Values.Max();
            if (maxFreqInt < len / 2)
            {
                var keyOfMaxValue = dict.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                dict.Remove(keyOfMaxValue);
                MaxIntCount(dict, len);
            }
            return count;
        }
        /*
        public static int MinSetSize(int[] arr)
        {
            var dic = new Dictionary<int, int>();
            var len = arr.Length;
            for (int i = 0; i < arr.Length; i++)
            {
                if (dic.ContainsKey(arr[i]))
                {
                   dic[arr[i]] += 1;
                }
                else
                {
                    dic.Add(arr[i], 1);
                }
            }
            return MaxIntCount(dic, len);

        }
        static int count;
        static int maxFreqInt;
        static int MaxIntCount(Dictionary<int, int> dict, int len)
        {
            count++;
            maxFreqInt += dict.Values.Max();
            if (maxFreqInt >= len / 2)
            {
                return count;
            }
            else
            {
                var keyOfMaxValue = dict.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                dict.Remove(keyOfMaxValue);
                MaxIntCount(dict, len);
            }
            return 0;
        }
        */
        public static int Trap(int[] height)
        {
            var lh = 0;
            var rh = 0;
            var sum = 0;
            var rsum = 0;
            var res = 0;
            if (height == null) return 0;
            int len = height.Length;
            if (len == 0) return 0;
            int maxValue = height.Max();
            int maxIndex = height.ToList().IndexOf(maxValue);
            for (int i = 0; i <= maxIndex; i++)
            {
                if (height[i] >= lh)
                {
                    lh = height[i];
                    res += sum;
                    sum = 0;
                }
                else
                {
                    sum += lh - height[i];
                }
            }
            for (int j = len - 1; j >= maxIndex; j--)
            {
                if (height[j] >= rh)
                {
                    rh = height[j];
                    res += rsum;
                    rsum = 0;
                }
                else
                {
                    rsum += rh - height[j];
                }
            }

            return res;
        }
        public static int NumSubmatrixSumTarget(int[][] matrix, int target)
        {
            int count = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.Length; j++)
                {

                    sum += matrix[i][j];
                    if (sum == target)
                    {
                        count++;
                        sum = 0;
                    }
                }
            }
            return count;
        }
        public static int RemoveElement(int[] nums, int val)
        {
            nums = nums.Where(n => n != val).ToArray();
            return nums.Length;
        }

        public static IList<string> LetterCombinations(string digits)
        {
            int len = digits.Length;
            int num = Convert.ToInt32(digits);
            string[][] arrCollection = new string[][]
            {
                new string[] {"a","b","c"},
                new string[] {"d","e","f"},
                new string[] {"g","h","i"},
                new string[] {"j","k","l"},
                new string[] {"m","n","o"},
                new string[] {"p","q","r","s"},
                new string[] {"t","u","v"},
                new string[] {"w","x","y","z"}
            };

            var arrRes = new List<string>();
            int digit = num;
            while (num >= 1)
            {
                var temp = num;
                digit = num % 10;
                num = temp / 10;
                var opertionArr = arrCollection[digit];
                var arrlen = arrCollection[digit].Length;
                for (int a = 0; a < arrlen - 1; a++)
                {
                    for (int b = 0; b < arrlen - 1; b++)
                    {
                        var arrStr = new StringBuilder();
                        arrStr.Append(opertionArr[a]);
                        arrStr.Append(opertionArr[b]);
                        arrRes.Add(arrStr.ToString());
                    }
                }

            }
            return arrRes.ToArray();

        }
        public static IList<IList<int>> ThreeSum(int[] nums)
        {

            Array.Sort(nums);
            var numLen = nums.Length;
            //var lists = new List<IList<int>>();
            var lists = new HashSet<int[]>();
            if (numLen < 3) return lists.ToArray();
            var a = new List<int>();
            var b = new List<int>();
            for (int i = 0; i < numLen; i++)
            {
                if (a.Contains(nums[i]))
                {
                    continue;
                }
                a.Add(nums[i]);
                int j = i + 1;
                int k = numLen - 1;

                while (j < k)
                {

                    var sum = nums[i] + nums[j] + nums[k];
                    if (!b.Contains(nums[i]))
                    {
                        if (sum == 0)
                        {

                            var l = new int[] { nums[i], nums[j], nums[k] };
                            //if (!lists.Any(m => m.SequenceEqual(l)))
                            //if(!lists.Contains(l))
                            {
                                lists.Add(l);
                            }
                        }
                    }
                    b.Add(nums[i]);

                    if (sum > 0)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            return lists.ToArray();
        }
    }
}
