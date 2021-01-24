using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subarray_conation_all_distinct_element
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "aeccabbaaccea";

            Dictionary<char, List<int>> info = new Dictionary<char, List<int>>();
            List<int> CharValue = new List<int>();
            var charArray = input.ToCharArray().ToList();
            List<char> tempArray = new List<char>();
            tempArray.AddRange(charArray);
            int q = 0;
            List<int> temp = new List<int>();

            foreach (var c in charArray.Distinct())
            {
                List<int> foundIndexes = new List<int>();

                for (int i = input.IndexOf(c); i > -1; i = input.IndexOf(c, i + 1))
                {
                    // for loop end when i=-1 ('a' not found)
                    foundIndexes.Add(i);
                }
                info.Add(c, foundIndexes);
            }

            foreach (var i in info)
            {               
                foreach (var z in i.Value)
                {
                    

                }



            }
            var l =temp[temp.Count - 1] - temp[0] +1;
        }
    }
}
