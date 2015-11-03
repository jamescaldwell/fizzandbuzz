using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzAndBuzzLib
{
    public class FizzBuzz : IEnumerable<String>
    {
        private long first;
        private long last;
        private IDictionary<Int64,String> words;        // list of words to use and numbers to mod

        /// <summary>
        /// constructor with default words (fizz, buzz)
        /// </summary>
        /// <param name="endNum">last number in range of 1 to n</param>
        public FizzBuzz(long endNum)
        {
            first = 1;
            last = endNum;
            words = new SortedDictionary<Int64, String>();
            words.Add(new KeyValuePair<long, string>(3, "fizz"));
            words.Add(new KeyValuePair<long, string>(5, "buzz"));
            validate();
        }
        /// <summary>
        /// constructor with custom words
        /// </summary>
        /// <param name="endNum">last number in range of 1 to n</param>
        /// <param name="customWords">hash of number=>word pairs</param>
        public FizzBuzz(long endNum, IDictionary<Int64,String> customWords)
        {
            first = 1;
            last = endNum;
            words = customWords;
            validate();
        }

        /// <summary>
        /// make sure params are good or throw ArgumentException
        /// </summary>
        private void validate()
        {
            if (words == null)
            {
                throw new ArgumentException("Cannot have null custom words", "customWords");
            }
        }
        /// <summary>
        /// generic enumerator
        /// </summary>
        /// <returns>enumerator</returns>
        public IEnumerator<String> GetEnumerator()
        {
            for (long i = first; i <= last; i++)
            {
                yield return CalcOutput(i);
            }
        }

        /// <summary>
        /// Enumerator
        /// </summary>
        /// <returns>enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// function to calculate output for given number
        /// </summary>
        /// <param name="num">number between 1 and Last</param>
        /// <returns>output string</returns>
        public String CalcOutput(long num)
        {
            StringBuilder sb = new StringBuilder();
            int numMods = 0;       // mod counter
            Int64 lastKey = 0;

            // go through each number to see if there is a mod 0
            foreach (KeyValuePair<Int64, String> entry in words)
            {
                //if we get a mod then add word
                if ((num % entry.Key) == 0)
                {
                    lastKey = entry.Key;
                    if (numMods++ == 0)     // only append first one, because if multiple we will use the last one
                        sb.Append(entry.Value);
                }
            }
            // if no mods, then just return number
            if (numMods == 0)
            {
                sb.Append(num.ToString());
            }
            else if (numMods > 1)     // if we have mulitiple mods, then use last one
            {
                sb.Clear();
                sb.Append(words[lastKey]);
            }
            return sb.ToString();
        }

    }
}
