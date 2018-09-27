using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReverse
{
    class Program
    {
        static void Main(string[] args)
        {

            StringBuilder EncodedString = new StringBuilder();
            //1
            string inputString = "Aman Kumar";//Dpdq Nxpdu
            List<int> asciiArr = new List<int>();
            int codeval = 3;
            for (int i = 0; i < inputString.Length; i++)
            {
                asciiArr.Add((int)Convert.ToChar(inputString[i]));
            }

            foreach (int i in asciiArr)
            {
                if (i >= 65 && i <= 90)
                {
                    if (i + codeval > 90)
                    {
                        EncodedString.Append((char)((i + codeval - 90) + 65));
                    }
                    else
                    {
                        EncodedString.Append((char)(i + codeval));
                    }
                }
                else if (i >= 97 && i <= 122)
                {
                    if (i + codeval > 122)
                    {
                        EncodedString.Append((char)((i + codeval - 122) + 97));
                    }
                    else
                    {
                        EncodedString.Append((char)(i + codeval));
                    }
                }
                else
                {
                    EncodedString.Append((char)(i));
                }
            }



            //2
            ArrayList atozArr = new ArrayList();

            for (int i = 0, j = 65; i < 26; i++, j++)
            {
                atozArr.Add((char)j);
            }

            //3
            int positionAscii = Convert.ToInt32(atozArr[(new Random()).Next(26)]);


            //4
            ArrayList outputArr = new ArrayList();

            for (int i = 0; i < inputString.Length; i++)
            {
                outputArr.Add(Convert.ToInt32(asciiArr[i]) + positionAscii);
            }

            int[] k = (int[])outputArr.ToArray(System.Type.GetType("System.Int32"));

            Console.Write("\nCipher Text: \n\n");

            //foreach (int i in k)
            //{
            //    cipherText = cipherText + (char)i;
            //}

        }
    }
}
