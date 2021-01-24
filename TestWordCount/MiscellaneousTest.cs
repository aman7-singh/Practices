using NUnit.Framework;
using System;
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
    }
}