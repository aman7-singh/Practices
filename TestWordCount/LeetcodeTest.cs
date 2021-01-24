using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WordCount;

namespace TestWordCount
{
    public class LeetcodeTest
    {
        [TestCase("3[a]2[bc]", "aaabcbc")]
        [TestCase("3[a2[c]]", "accaccacc")]
        [TestCase("2[abc]3[cd]ef", "abcabccdcdcdef")]
        [TestCase("abc3[cd]xyz", "abccdcdcdxyz")]
        [TestCase("abc10[cd]xyz", "abccdcdcdcdcdcdcdcdcdcdxyz")]
        public void DecodeStringTest(string input, string exptedOpt)
        {
            var output = Leetcode.DecodeString(input);

            Assert.AreEqual(exptedOpt, output);
        }
        [TestCase(new int[] { 5, 7, 7, 8, 8, 10 },8, "3,4")]
        [TestCase(new int[] { 5, 7, 7, 8, 8, 10 },5, "0,0")]
        [TestCase(new int[] { 5, 7, 7, 8, 8, 10 },10, "5,5")]
        [TestCase(new int[] { 5, 7, 7, 8, 8, 10 },66, "-1,-1")]
        [TestCase(new int[] { },10, "-1,-1")]
        [TestCase(null,10, "-1,-1")]
        public void SearchRangeTest(int[] input, int target, string exptedOpt)
        {
            var output = Leetcode.SearchRange(input, target);

            var result = string.Join(",",output);
            Assert.AreEqual(exptedOpt, result);
        }

        [TestCase(new int[] { 1, 7, 11 }, new int[] { 2, 4, 6 }, 3, "[1,2],[1,4],[1,6],")]
        [TestCase(new int[] { 1, 1, 2 }, new int[] { 1, 2, 3 }, 2, "[1,1],[1,1],")]
        [TestCase(new int[] { 1, 2 }, new int[] { 3 }, 3, "[1,3],[2,3],")]
        [TestCase(new int[] { 1 }, new int[] { 3 }, 3, "[1,3],")]
        [TestCase(new int[] { 1 }, new int[] {}, 3, "")]
        [TestCase(new int[] { 1 }, null, 3, "")]
        [TestCase(new int[] { 1, 1, 2 }, new int[]{ 1, 2, 3 }, 10, "[1,1],[1,1],[2,1],[1,2],[1,2],[2,2],[1,3],[1,3],[2,3],")]
        public void KSmallestPairsTest(int[] input1, int[] input2, int target, string exptedOpt)
        {
            var output = Leetcode.KSmallestPairs(input1, input2, target);
            string result ="";
            for (int i=0; i<output.Count; i++ )
            {
                result += "[";
                result += string.Join(",", output[i]);
                result += "],";
            }
            Assert.AreEqual(exptedOpt, result);
        }
        [TestCase(new int[] { 1, 1, 2 },  2)]
        [TestCase(new int[] { -2, -5, -6 },  30)]
        [TestCase(new int[] { 3, -2, 4 },  4)]
        [TestCase(new int[] {-2},  -2)]
        [TestCase(new int[] {-2,3,-4},  24)]
        [TestCase(new int[] { -2, 4, -5, 0, 2, -6, 4, 15 },  60)]
        public void maxProductTest(int[] input1, int exptedOpt)
        {
            var result = Leetcode.MaxProduct(input1);
            Assert.AreEqual(exptedOpt, result);
        }

        [TestCase(new int[] { 1, 1, 2 }, 2)]
        [TestCase(new int[] { -2, -5, -6 }, 1)]
        [TestCase(new int[] { 3, -2, 4 }, 2)]
        [TestCase(new int[] { -2 }, 1)]
        [TestCase(new int[] { -2, 3, -4 }, 2)]
        [TestCase(new int[] { -2, 4, -5, 0, 2, -6, 4, 15 }, 5)]
        [TestCase(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
        public void LengthOfLISTest(int[] input1, int exptedOpt)
        {
            var result = Leetcode.LengthOfLIS(input1);
            Assert.AreEqual(exptedOpt, result);
        }

        [TestCase("aabca", 6)]
        [TestCase("aa", 3)]
        [TestCase("aaa", 6)]
        public void CountSubstringsTest(string input, int exptedOpt)
        {
            var result = Leetcode.CountSubstrings(input);
            Assert.AreEqual(exptedOpt, result);
        }

        [TestCase(new int[] { 1, 3, 2, 1}, 4)]
        [TestCase(new int[] { 1, 3, 2, 1,4}, 4)]
        [TestCase(new int[] { 1, 3, 2, 1,4,3,2,1}, 5)]
        [TestCase(new int[] { 1,2,1,2,3,4,3,2,5}, 6)]
        [TestCase(new int[] { 2, 1, 4, 7, 3, 2, 5 }, 5)]
        [TestCase(new int[] { 2, 2,2 }, 0)]
        [TestCase(new int[] { 1,2,3 }, 0)]
        [TestCase(new int[] { 3,2,1 }, 0)]
        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { 0,2,2 }, 0)]
        [TestCase(new int[] { 7,4,8 }, 0)]
        public void LongestMountainTest(int[] input, int exptedOpt)
        {
            var result = Leetcode.LongestMountain(input);
            Assert.AreEqual(exptedOpt, result);
        }

        [TestCase(new int[] { 1,2,3,4 }, "24,12,8,6")]
        [TestCase(new int[] { 1,2,0,3,4 }, "0,0,24,0,0")]
        public void ProductExceptSelfTest(int[] input, string exptedOpt)
        {
            var result = Leetcode.ProductExceptSelf(input);
            var output = string.Join(",", result);
            Assert.AreEqual(exptedOpt, output);
        }

        [TestCase("abcabcab", 3)]
        [TestCase("pwwkew", 3)]
        [TestCase("", 0)]
        [TestCase("bbbb", 1)]
        [TestCase("dvdf", 3)]
        public void LengthOfLongestSubstringTest(string input, int exptedOpt)
        {
            var result = Leetcode.LengthOfLongestSubstring(input);
            Assert.AreEqual(exptedOpt, result);
        }

        [TestCase("aoooob", "eidbaooo", false)]
        [TestCase("ab", "eidbaooo", true)]
        [TestCase("ab", "eidboaoo", false)]
        public void CheckInclusionTest(string input, string input2, bool exptedOpt)
        {
            var result = Leetcode.CheckInclusion(input,input2);
            Assert.AreEqual(exptedOpt, result);
        }
    }
}
