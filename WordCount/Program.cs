using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        //Number of each words in a sentence.
        static void Main(string[] args)
        {
            var s = 3 % 4;

            //Timemanagement();
            string str = "<?xml version=\"1.0\" encoding=\"utf - 8\" ?> <root id=\"1\">   < subElement id = \"1\" >      < subSubElement id = \"1\" /> < subSubElement id = \"2\" /></ subElement >< subElement id = \"2\" /> < subElement id = \"3\" />  </ root >";
            XmlEditor xm = new XmlEditor();
           // xm.ReplaceNodeName(str, "subElement","child");


            StringMap<string> hdt = new StringMap<string>();
            hdt.AddElement("userName", "ishoo");
            hdt.AddElement("password", "1234");
            hdt.AddElement("email", "ishooagarwal");
            hdt.RemoveElement("password");
            hdt.RemoveElement("password");
            hdt.AddElement("password", "1234");
            hdt.AddElement("password", "1234");



            #region MyCodeSchool

            MyCodeSchool.MyLinkedListOperation();
            MyCodeSchool.ListArrayOperations();

            #endregion

            #region GeeksForGeeks

            var inputLongestLCS1 = "stone";
            var inputLongestLCS2 = "longest";
            var outputLongestLCS = GeeksForGeeks.LongestLCS(inputLongestLCS1, inputLongestLCS2);

            var inputUnionOfTwoArray1 = new int[]{ 5,-4,-1, 2, -3, 4, 5, 6, -7, 8, 9};
            var inputUnionOfTwoArray2 = new int[]{ 21,54, -79};
            var outputUnionOfTwoArray = GeeksForGeeks.UnionOfTwoArray(inputUnionOfTwoArray1, inputUnionOfTwoArray2);
            Console.WriteLine(string.Join(",",outputUnionOfTwoArray));

            var inputGetMinAndMax = new int[] { 1, 345, 234, 21, 56789 };
            int min = int.MaxValue;
            int max = int.MinValue;
            GeeksForGeeks.GetMinAndMax(inputGetMinAndMax,out min, out max);
            Console.WriteLine($"{min} {max}");

            //var inputInsertionSort = new int[] { 5,-4,-1, 2, -3, 4, 5, 6, -7, 8, 9 };
            var inputInsertionSort = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            GeeksForGeeks.InsertionSort(inputInsertionSort);

            var inputRearrangePositiveAndNegativeNumbers = new int[] { -4,-1, 2, -3, 4, 5, 6, -7, 8, 9 };
            //var inputRearrangePositiveAndNegativeNumbers = new int[] { 2, 3, 5, 7, 0, 40, -35, 54, 0, 0, 1 };
            GeeksForGeeks.RearrangePositiveAndNegativeNumbers(inputRearrangePositiveAndNegativeNumbers);

            var inputRearrangeArray = new int[] { 2, 3, 5, 7, 0,40,35,54,0,0,1, 5, 6, 2, 3, 5, 7, 11, 13, 17, 19, 5, 6, 2, 3, 5, 7, 11, 13, 17, 19, 5, 6, 2, 3, 5, 7, 11, 13, 17, 19};
            // var inputRearrangeArray = new int[] { 5,6,2, 3, 5, 7, 0, 13, 17, 19 };
            var outputRearrangeArrayReplaceAproach = GeeksForGeeks.RearrangeArrayReplaceAproach(inputRearrangeArray);
            Console.WriteLine(string.Join(",", outputRearrangeArrayReplaceAproach));
            var outputRearrangeArray = GeeksForGeeks.RearrangeArray(inputRearrangeArray);
            Console.WriteLine(string.Join(",", outputRearrangeArray));

            var inputLeftRoatate = new int[] { 2, 3, 5, 7, 11, 13, 17, 19 };
            var outputLeftRoatate = GeeksForGeeks.LeftRoatate(inputLeftRoatate, 2);
            var outputRightRotate = GeeksForGeeks.RightRotate(inputLeftRoatate, 2);

            var outLeftRotateReverseAlgo = GeeksForGeeks.LeftRotateByReverse(inputLeftRoatate,2);
            #endregion

            #region CodingBlock
            var subArray = new int[] { 2,3,5,7,11,13,17,19};
            CodingBlock.NumOfElementsDivisibleByPrimeNum(20, subArray);
            #endregion

            #region Leetcode

            var inputmaxProduct = new int[] {-1,-2,-5 };
            var outputmaxProduct = Leetcode.MaxProduct(inputmaxProduct);

            var outputDecodeString = Leetcode.DecodeString("3[a2[c]]");


            //var inputThreeSumAgain = new int[] { -1, 0, 1, 2, -1, -4, 1 };
            var inputThreeSumAgain = new int[] {0,0,0 };
            var outputThreeSumAgain = Leetcode.ThreeSumAgain(inputThreeSumAgain);

            var inputLengthOfLIS = new int[] { 1,3,2,4,5,7,1};
            var outputLengthOfLIS = Leetcode.LengthOfLIS(inputLengthOfLIS);

            var inputNextPermutation = new int[] { 1,3,2};
            Leetcode.NextPermutation(inputNextPermutation);

            var inputMerge = new int[][] 
            {
                new int[] { 1, 3 },
                new int[]{ 2, 6 },
                new int[]{ 8, 10 },
                new int[]{ 15, 18 },
                new int[]{ 2, 7 },

            };
            var outputMerge = Leetcode.Merge(inputMerge);

            var inputkadanaAlgorith = new int[] { 1, -1, 3, -5, 5, 2,-1,7 };
            //var inputkadanaAlgorith = new int[] { -1, -2, -3, -4, -5 }; //-1
            var outPutkadanaAlgorith = Leetcode.kadanaAlgorith(inputkadanaAlgorith);

            var inputMergeArray1 = new int[] { 0, 2, 6, 8, 9 };
            var inputMergeArray2 = new int[] { 1, 3, 5, 7 };
            Leetcode.Merge(inputMergeArray1,5, inputMergeArray2,4);


            var inputMergeTwoSortedArray1 = new int[] { 0, 2, 6, 8, 9 };
            var inputMergeTwoSortedArray2 = new int[] { 1, 3, 5, 7 };
            var OutputMergeTwoSortedArray = Leetcode.mergeTwoSortedArray(inputMergeTwoSortedArray2, inputMergeTwoSortedArray1);

            //var inputminJumps = new int[] {1, 4, 3, 2, 6, 7 };
            var inputminJumps = new int[] { 1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9 };
            var outputminJumps = Leetcode.minJumps(inputminJumps);

            var inputgetMinDiff = new int[] { 1,2,3,4,5,6,7 };
            var outoutgetMinDiff = Leetcode.getMinDiff(inputgetMinDiff, 2);

            var inputMaxSubArray = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var outputMaxSubArray = Leetcode.MaxSubArray(inputMaxSubArray);

            var inputFindKthLargest = new int[] { 2, 0, 2, 1, 1, 0 };
            var outputFindKthLargest = Leetcode.FindKthLargest(inputFindKthLargest,2);

            var inputNumberOfArithmeticSlices = new int[] { 2, 4, 6, 7, 8, 10 };
            Leetcode.NumberOfArithmeticSlices(inputNumberOfArithmeticSlices);

            var inputMinSetSize = new int[] { 3, 3, 3, 3, 5, 5, 5, 2, 2, 7 };
            Leetcode.MinSetSize(inputMinSetSize);

            #region
            //var inputTrap = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };//6
            //var inputTrap = new int[] { 4, 2, 0, 3, 2, 5, 12, 4, 15 };//17
            var inputTrap = new int[] { 2,0,2 }; //2
            Leetcode.Trap(inputTrap);
            var inputNumSubmatrixSumTarget = new int[][] { new int[] { 0, 1, 0 },
            #endregion  

                new int[] {1, 1, 1},
                new int[] {0, 1, 0}};
            Leetcode.NumSubmatrixSumTarget(inputNumSubmatrixSumTarget,0);
            Leetcode.RemoveElement(new int[] { 3, 2, 2, 3 }, 3);
            Leetcode.LetterCombinations("23");

           // var input = new int[] { -1, 0, 1, 2, -1, -4 };
            //output= 
            var input = new int[] { 0,0,0,0 };
            Leetcode.ThreeSum(input);

            #endregion

            #region LinQ
            LinqClass.Querylinq();
            LinqClass.concurrTask();
            string sentence = "hr id the ys the id";
            var wordList = sentence?.Split(' ');
            Dictionary<string, int> tempWordList = new Dictionary<string, int>();
            int i = 1;
            foreach (var word in wordList)
            {
                if (tempWordList.ContainsKey(word))
                {
                    i = tempWordList[word];
                    i++;
                    tempWordList[word] = i;
                }
                else
                {
                    tempWordList.Add(word, 1);
                }
            }
            foreach (var item in tempWordList)
            {
                Console.WriteLine(item.Key + ":" + item.Value.ToString());
            }
            #endregion

            
            Console.ReadLine();
        }
        public static void Timemanagement()
        {
            int maxTime = 360;
            int Testcases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Testcases; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                int problems = int.Parse(tokens[0]);
                int traveltime = int.Parse(tokens[1]);
                int availableTime = maxTime - traveltime;
                int timeTaken = 0;
                int p ;
                for (p = 1; p <= problems; p++)
                {
                    if (availableTime >= timeTaken)
                    {
                        timeTaken += p * 3;
                    }
                }
                Console.WriteLine(p-1);
            }
            return;
        }
    }
}
