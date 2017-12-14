using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//NOT CLEAR ABOUT THIS TASK !

namespace _10.Unicode_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            //string value = Console.ReadLine(); ;
            string value = "Hi!";

            int[] arr = value.ToCharArray().Select(m => (int)m).ToArray();
            FindHexDecNumber(arr[1]);
            var result = string.Concat(arr);
            Console.WriteLine(result);


            string unicodeString = "This function contains a unicode character pi (\u0069)";

            Console.WriteLine(unicodeString);

            string encoded = EncodeNonAsciiCharacters(unicodeString);
            Console.WriteLine(encoded);

            string decoded = DecodeEncodedNonAsciiCharacters(encoded);
            Console.WriteLine(decoded);



        }

        private static string FindHexDecNumber(int number)
        {
            string hexDecNum = "";
            var hexDec = "0123456789ABCDEF";
            int num = 0;


            while (number > 0)
            {
                num = number % 16;
                hexDecNum += hexDec[num];
                number /= 16;
            }
            return hexDecNum;
        }

        static string EncodeNonAsciiCharacters(string value)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (c > 127)
                {
                    // This character is too big for ASCII
                    string encodedValue = "\\u" + ((int)c).ToString("x4");
                    sb.Append(encodedValue);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        static string DecodeEncodedNonAsciiCharacters(string value)
        {
            return Regex.Replace(
                value,
                @"\\u(?<Value>[a-zA-Z0-9]{4})",
                m => {
                    return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
                });
        }



    }
}
