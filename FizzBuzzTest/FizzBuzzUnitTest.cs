using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using FizzAndBuzzLib;

namespace FizzBuzzTest
{
    [TestClass]
    public class FizzBuzzUnitTest
    {
        [TestMethod]
        public void TestNumber15()
        {
            String expected = "buzz";
            FizzBuzz fizzbuzz = new FizzBuzz(100);
            String result = fizzbuzz.CalcOutput(15);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCustomWords()
        {
            IDictionary<Int64,String> canadaCities = new SortedDictionary<Int64, String>();
            canadaCities.Add(4, "Victoria");
            canadaCities.Add(9, "Yellowknife");
            canadaCities.Add(13, "Goose Bay");
            canadaCities.Add(17, "Val D'Or");
            FizzBuzz fizzbuzz = new FizzBuzz(300, canadaCities);
            String result = fizzbuzz.CalcOutput(36);
            Assert.AreEqual("Yellowknife", result);
            result = fizzbuzz.CalcOutput(34);
            Assert.AreEqual("Val D'Or", result);
        }

        [TestMethod]
        public void TestNumbersOrWords()
        {
            IDictionary<Int64, String> euroCities = new SortedDictionary<Int64, String>();
            euroCities.Add(2, "Oslo");
            euroCities.Add(4, "Helsinki");
            euroCities.Add(8, "Lisbon");
            euroCities.Add(16, "Dubrovnik");
            FizzBuzz fizzbuzz = new FizzBuzz(300, euroCities);
            IEnumerable<String> results = from fb in fizzbuzz select fb;
            long index = 1;
            foreach (String r in results)
            {
                try
                {
                    // odds should be a number
                    Int64 i64 = Convert.ToInt64(r);
                    Assert.AreNotEqual(0, index % 2);
                }
                catch (FormatException)
                {
                    // evens will be a city and throw an exception based on number conversion
                    Assert.AreEqual(0, index % 2);
                }
                finally
                {
                    index++;
                }
            }
            
        }
    }
}
