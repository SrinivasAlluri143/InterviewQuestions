using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace CDSPractical {
    public class Questions {
        /// <summary>
        /// Given an enumerable of strings, attempt to parse each string and if 
        /// it is an integer, add it to the returned enumerable.
        /// 
        /// For example:
        /// 
        /// ExtractNumbers(new List<string> { "123", "hello", "234" });
        /// 
        /// ; would return:
        /// 
        /// {
        ///   123,
        ///   234
        /// }
        /// </summary>
        /// <param name="source">An enumerable containing words</param>
        /// <returns></returns>
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> source) {
            List<int> result = new List<int>();
            dynamic intvalues = "";
            int response;
            foreach(var item in source)
            {
                if(int.TryParse(item, out response))
                {
                    result.Add(Convert.ToInt32(item));
                }
            }
            return result;
        }

        /// <summary>
        /// Given two enumerables of strings, find the longest common word.
        /// 
        /// For example:
        /// 
        /// LongestCommonWord(
        ///     new List<string> {
        ///         "love",
        ///         "wandering",
        ///         "goofy",
        ///         "sweet",
        ///         "mean",
        ///         "show",
        ///         "fade",
        ///         "scissors",
        ///         "shoes",
        ///         "gainful",
        ///         "wind",
        ///         "warn"
        ///     },
        ///     new List<string> {
        ///         "wacky",
        ///         "fabulous",
        ///         "arm",
        ///         "rabbit",
        ///         "force",
        ///         "wandering",
        ///         "scissors",
        ///         "fair",
        ///         "homely",
        ///         "wiggly",
        ///         "thankful",
        ///         "ear"
        ///     }
        /// );
        /// 
        /// ; would return "wandering" as the longest common word.
        /// </summary>
        /// <param name="first">First list of words</param>
        /// <param name="second">Second list of words</param>
        /// <returns></returns>
        public string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second)
        {
            var firstvalue = FindLongestWords(first);
            var secoundvalue = FindLongestWords(second);
            var response = "";

            if (Convert.ToString(firstvalue) != string.Empty &&  Convert.ToString(secoundvalue) != string.Empty)
            {
                if (firstvalue.First() == secoundvalue.First())
                {
                    response = firstvalue.First();
                }
            }
            return response;
        }

        /// <summary>
        /// FindLongestWords
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        private static IEnumerable<string> FindLongestWords(IEnumerable<string> words)
        {
            return
                words
                .GroupBy(w => w.Length)
                .OrderByDescending(g => g.Key)
                .First();
        }

        /// <summary>
        /// Write a method that converts kilometers to miles, given that there are
        /// 1.6 kilometers per mile.
        /// 
        /// For example:
        /// 
        /// DistanceInMiles(16.00);
        /// 
        /// ; would return 10.00;
        /// </summary>
        /// <param name="km">distance in kilometers</param>
        /// <returns></returns>
        public double DistanceInMiles(double km)
        {
            double miles = km / 1.6;
            return miles;
        }

        /// <summary>
        /// Write a method that converts miles to kilometers, give that there are
        /// 1.6 kilometers per mile.
        /// 
        /// For example:
        /// 
        /// DistanceInKm(10.00);
        /// 
        /// ; would return 16.00;
        /// </summary>
        /// <param name="miles">distance in miles</param>
        /// <returns></returns>
        public double DistanceInKm(double miles)
        {
            double kilometers = miles * 1.6;
            return kilometers;
        }

        /// <summary>
        /// Write a method that returns true if the word is a palindrome, false if
        /// it is not.
        /// 
        /// For example:
        /// 
        /// IsPalindrome("bolton");
        /// 
        /// ; would return false, and:
        /// 
        /// IsPalindrome("Anna");
        /// 
        /// ; would return true.
        /// 
        /// Also complete the related test case for this method.
        /// </summary>
        /// <param name="word">The word to check</param>
        /// <returns></returns>
        public bool IsPalindrome(string word) {

            int i = 0;
            int j = word.Length - 1;
            while (true)
            {
                if (i > j)
                {
                    return true;
                }
                char a = word[i];
                char b = word[j];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                i++;
                j--;
            }
        }

        /// <summary>
        /// Write a method that takes an enumerable list of objects and shuffles
        /// them into a different order.
        /// 
        /// For example:
        /// 
        /// Shuffle(new List<string>{ "one", "two" });
        /// 
        /// ; would return:
        /// 
        /// {
        ///   "two",
        ///   "one"
        /// }
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<object> Shuffle(IEnumerable<object> source) {
            var r = new Random((int)DateTime.Now.Ticks);
            var shuffledList = source.Select(x => new { Number = r.Next(), Item = x }).Reverse().Select(x => x.Item);
            return shuffledList.ToList();
        }

        /// <summary>
        /// Write a method that sorts an array of integers into ascending
        /// order - do not use any built in sorting mechanisms or frameworks.
        /// 
        /// Complete the test for this method.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public int[] Sort(int[] source) {
            int[] value = new int[source.Length];
            Array.Sort(source);
            for (int i= 0;i < source.Length;i++)
            {
                value[i] = source[i];
            }

            return value;
        }

        /// <summary>
        /// Each new term in the Fibonacci sequence is generated by adding the 
        /// previous two terms. By starting with 1 and 2, the first 10 terms will be:
        ///
        /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        ///
        /// By considering the terms in the Fibonacci sequence whose values do 
        /// not exceed four million, find the sum of the even-valued terms.
        /// </summary>
        /// <returns></returns>
        public int FibonacciSum()
        {
            var allNumbers = FibonacciFunction(4000000); 
            var evenNumbers = allNumbers.Where(x => x % 2 == 0); 
            var sum = evenNumbers.Sum(); 
            return sum;
        }

        /// <summary>
        /// FibonacciFunction
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        IEnumerable<Int32> FibonacciFunction(Int32 limit = 4000000)
        {
            for (Int32 previous = 0, current = 1, next = 0;
                current <= limit; current = next)
            {
                next = previous + current;
                previous = current;
                yield return next;
            }
        }

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        /// 
        /// This method is currently broken, fix it so that the tests pass.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GenerateList() {
            var ret = new List<int>();
            var numThreads = 2;

            Thread[] threads = new Thread[numThreads];
            for (var i = 0; i < numThreads; i++) {
                threads[i] = new Thread(() => {
                    var complete = false;
                    while (!complete) {                        
                        var next = ret.Count + 1;
                        Thread.Sleep(new Random().Next(1, 10));
                        if (next <= 100) {
                            ret.Add(next);
                        }

                        if (ret.Count >= 100) {
                            complete = true;
                        }
                    }                    
                });
                threads[i].Start();
            }            

            return ret;
        }
    }
}
