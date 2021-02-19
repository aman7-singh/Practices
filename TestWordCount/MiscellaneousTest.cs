using NUnit.Framework;
using System;
using System.Collections.Generic;
using WordCount;

namespace TestWordCount
{
    public class MiscellaneousTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SortAlogTest()
        {
            //Assert
            int[] input = new int[] {5,2,5,7,3,-5,-2,1,0,5 };
            int[] exp = new int[] { -5, -2, 0, 1, 2, 3, 5, 5, 5, 7 };
            var expRes = string.Join(',', exp);

            //Act
            var output = Miscellaneous.SortAlog(input);
            var res = string.Join(',', output);
                        
            Assert.AreEqual(expRes, res);
        }

        [TestCase(new int[] { 5, 6, 2, 3, 5, 7, 0, 13, 17, 9 }, "0,-1,2,3,-1,5,6,7,-1,9")]
        [TestCase(new int[] { -5, -6, 2, 3, -5, -7, 0, 13, 17, 9 }, "0,-1,2,3,-1,-1,-1,-1,-1,9")]
        public void RearrangeArrayReplaceAproachTest(int[] input, string exptedOpt)
        {
            var expRes = string.Join(',', exptedOpt);

            var output = Miscellaneous.RearrangeArrayReplaceAproach(input);
            var res = string.Join(',', output);

            Assert.AreEqual(expRes, res);
        }

        [Test]
        public void SmallestPostiveintegerTest()
        {
            int[] input = new int[] { 1, 3, 6, 4, 1, 2 };
            
            var output = Miscellaneous.SmallestPostiveinteger(input);

            Assert.AreEqual(5, output);
        }
        [TestCase("baaaa",-1)]
        [TestCase("dog",8)]
        [TestCase("aa",0)]
        public void A_CountTest(string input, int expOutput)
        {
            var output = Miscellaneous.A_Count(input);

            Assert.AreEqual(expOutput, output);
        }
        [TestCase("baaaa", -1)]
        [TestCase("dog", 8)]
        [TestCase("aa", 0)]
        public void countATest(string input, int expOutput)
        {
            var output = Miscellaneous.countA(input);

            Assert.AreEqual(expOutput, output);
        }

        [TestCase(new int[] { 1,5,3,7,-5}, "-5,7,3,5,1" )]
        [TestCase(new int[] { 1,0,3,-7,-5}, "-5,-7,3,0,1" )]
        public void ReveerseArrTest(int[] input, string expectedOutput)
        {
            Miscellaneous.reverseArray(input,0, input.Length-1);
            var output = string.Join(",",input);
            Assert.AreEqual(expectedOutput,output);
        }

        [TestCase(new int[] { 1, 5, 3, 7, -5 }, 3 , "7,-5,1,5,3")]
        [TestCase(new int[] { 1, 0, 3, -7, -5}, 6 ,"0,3,-7,-5,1")]
        public void RotateLeftTest(int[] input, int d,string expectedOutput)
        {
            Miscellaneous.RotateLeft(input, d);
            var output = string.Join(",", input);
            Assert.AreEqual(expectedOutput, output);
        }
        [TestCase(new int[] { 1, 5, 3, 7, -5 }, 3, "3,7,-5,1,5")]
        [TestCase(new int[] { 1, 0, 3, -7, -5 }, 6, "-5,1,0,3,-7")]
        public void RotateRightTest(int[] input, int d, string expectedOutput)
        {
            Miscellaneous.RotateRight(input, d);
            var output = string.Join(",", input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestCase(new int[] { 1, -5, 3, 7, -5 }, 10)]
        [TestCase(new int[] { 1, 0, 3, -7, 5,4,-2,4 }, 11)]
        public void ContiguousSubArrayWithMaximumSumTest(int[] input, int expectedOutput)
        {
            var output = Miscellaneous.ContiguousSubArrayWithMaximumSum(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void SolveTest()
        {
            List<int> list = new List<int>() { 5, 2, 1, 3, 9 };

            var output = Miscellaneous.solve(list, 3);
            Assert.AreEqual(17, output);
        }

        [Test]
        public void spiralOrderTest()
        {
            string expectedOutput = "1,2,3,6,9,8,7,4,5";
            var list = new List<List<int>>() {
                new List<int>(){1,2,3 },
                new List<int>(){ 4,5,6 },
                new List<int>(){ 7,8,9},
            };

            var output = Miscellaneous.spiralOrder(list);
            var result = string.Join(",", output);
            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase(new int[] { 1, 2,3,4,5,6,7,8,9,10}, 12, -1)]
        [TestCase(new int[] { 1, 2,3,4,5,6,7,8,9,10}, 2, 1)]
        [TestCase(new int[] {12 }, 12, 0)]
        public void BinarySearchTest(int[] input, int srh,  int expectedOutput)
        {
            var output = Miscellaneous.BinarySearch(input, srh);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestCase(new int[] { 1, 2, 5,5,5,5,5,5,5, 9, 10 }, 5, 8)]
        [TestCase(new int[] { 1, 2, 7,7,7,7, 7, 8, 9, 10 }, 7, 6)]
        [TestCase(new int[] { 12 }, 12, 0)]
        public void BinarySearchForlastElementTest(int[] input, int srh, int expectedOutput)
        {
            var output = Miscellaneous.BinarySearchForlastElement(input, srh);
            Assert.AreEqual(expectedOutput, output);
        }
        [TestCase(new int[] { 1, 2, 5, 5, 5, 5, 5, 5, 5, 9, 10 }, 5, 2)]
        [TestCase(new int[] { 1, 7, 7, 7, 7, 7, 7, 8, 9, 10 }, 7, 1)]
        [TestCase(new int[] { 12 }, 12, 0)]
        public void BinarySearchForFirstElementTest(int[] input, int srh, int expectedOutput)
        {
            var output = Miscellaneous.BinarySearchForFirstElement(input, srh);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestCase(new int[] { 1, 2, 5, 5, 5, 5, 5, 5, 5, 9, 10 }, 5, 7)]
        [TestCase(new int[] { 1, 7, 7, 7, 7, 7, 7, 8, 9, 10 }, 7, 6)]
        [TestCase(new int[] { 12 }, 12, 1)]
        public void CountElementTest(int[] input, int srh, int expectedOutput)
        {
            var output = Miscellaneous.CountElement(input, srh);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestCase(new int[] { 1, 2, 4,8,9,10, 10,12,14 }, 5, 4)]
        [TestCase(new int[] { 1, 2,3,5,6,7, 8, 9, 10,11,12,15,18,20 }, 14, 12)]
        [TestCase(new int[] { 12 }, 12, 12)]
        [TestCase(new int[] { 12 }, 11, -1)]
        [TestCase(new int[] { 12 }, 13, 12)]
        public void FloorElementInSortedArrayTest(int[] input, int srh, int expectedOutput)
        {
            var output = Miscellaneous.FloorElementInSortedArray(input, srh);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestCase(new int[] { 11,12,13,18,2,3,4 }, 4)]
        public void ArrayRotatedTest(int[] input, int expectedOutput)
        {
            var output = Miscellaneous.ArrayRotated(input);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestCase(new char[] { 'a','b','c','f','h' }, 'c','f')]
        [TestCase(new char[] { 'a','b','c','f','h' }, 'b','c')]
        [TestCase(new char[] { 'a','b','c','f','h' }, 'h','a')]
        [TestCase(new char[] { 'a','b','c','f','h' }, 'a','b')]
        [TestCase(new char[] { 'a','b','c','f','h' }, 'x','\0')]
        public void NextAlphabeticalElementTest(char[] input, char srch, char expectedOutput)
        {
            var output = Miscellaneous.NextAlphabeticalElement(input,srch);
            Assert.AreEqual(expectedOutput, output);
        }

        [TestCase(new int[] { 11, 12, 13, 18, 2, 3, 4 }, 3)]
        [TestCase(new int[] { 11, 12, 13, 18,19}, 4)]
        [TestCase(new int[] { 11, 12, 13, 18,20,19}, 4)]
        [TestCase(new int[] { 11, 12, 13, 18,20,20}, -1)]
        [TestCase(new int[] { 10,9,8,2,1}, 0)]
        [TestCase(new int[] { 1,10,9,8,2,1}, 1)]
        [TestCase(new int[] { 2,2,2,2,2,2}, -1)]
        [TestCase(new int[] { 10,10,9,8,2,1}, -1)]
        public void PeakElementTest(int[] input, int expectedOutput)
        {
            var output = Miscellaneous.PeakElement(input);
            Assert.AreEqual(expectedOutput, output);
        }
    }
}