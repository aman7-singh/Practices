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
            Console.ReadLine();
        }
    }
}
