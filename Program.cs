using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AnagramChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string phrase1 = "spot";
            string phrase2 = "Pots";

            string phrase3 = "Hemant";
            string phrase4 = "Sakpal";

            if (CheckforStringsAreAnagrams(phrase1, phrase2))
            {
                Console.WriteLine("{0} is an anagram of {1}", phrase1, phrase2);
            }
            else
            {
                Console.WriteLine("{0} is NOT an anagram of {1}", phrase1, phrase2);
            }

            if (CheckforStringsAreAnagrams(phrase3, phrase4))
            {
                Console.WriteLine("{0} is an anagram of {1}", phrase3, phrase4);
            }
            else
            {
                Console.WriteLine("{0} is NOT an anagram of {1}", phrase3, phrase4);
            }
        }

        /// <summary>
        /// This Method will test whether two strings are sorted and Equal.
        /// Also This method does not considers the any spacial characters in Words or 2 strings.
        /// e.g. Hemant.Sakpal or Hemant_Sakpal or HemantSakpal! HemantSakpal ? 
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        static bool CheckforStringsAreAnagrams(string str1, string str2)
        {
            //Check for Null with Old Style
            if (str1 == null || str2 == null)
            {
                return false;
            }
            // remove spaces and puncuation
            str1 = Regex.Replace(str1, "[\\s\\p{P}]", "");
            str2 = Regex.Replace(str2, "[\\s\\p{P}]", "");
            str1 = str1.ToLower();
            str2 = str2.ToLower();

            // Here depend on our Cultural Selection we can use String Comparison Type.
            if (str1.Equals(str2, StringComparison.CurrentCulture))
            {
                return false;
            }

            // Null Checking with New C# 6.0 Style.
            // Null Checking Again With C# 6.0 it also Checks Length of strings
            if (str1?.Length == str2?.Length)
            {
                char[] char1Array = str1.ToCharArray();
                char[] char2Array = str2.ToCharArray();

                Array.Sort(char1Array);
                Array.Sort(char2Array);
                return Enumerable.SequenceEqual(char1Array, char2Array);
            }
            else
            {
                return false;
            }
        }
    }
}
