using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class CodingBlock
    {
        public static long NumOfElementsDivisibleByPrimeNum(int num, int[] primeNum)
        {
            int len = primeNum.Length;
            var NumOfSubSet = (1 << len) - 1;
            long ans = 0;
            for (int s = 0; s < NumOfSubSet; s++)
            {
                var denom = 1;
                var numOfBitsInNum = (int)Math.Log(num, 2.0) + 1;
                for (int p = 0; p < len; p++)
                {
                    denom *=primeNum[p];
                }

                if ((numOfBitsInNum & 1)!=0) //if odd no of denominator
                {

                }
                else
                {

                }
            }

            return ans;
        }
        public static long NumOfElementsDivisibleByPrimeNumOld(int num, int[] primeNum)
        {
            int len = primeNum.Length;
            var NumOfSubSet = (1 << len) - 1;
            long ans = 0;
            for (int s = 0; s < NumOfSubSet; s++)
            {
                var bit = Convert.ToString(s, 2).Count(c => c == '1');
                long deno = 1;

                for (int j = 0; j < len; j++)
                {
                    if ((s & (1 << j)) != 0)
                    {
                        deno = deno * primeNum[j];
                    }
                }
                if ((bit & 1) ==0) //Even 
                {
                    ans += num / deno;
                }
                else
                {
                    //odd
                    ans -= num / deno;
                }
            }

            return ans;
        }
    }
}
