using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 10901;
            Console.WriteLine(GenerateInvoice(count));
        }
        
        static string ArabicToRoman(int arabic)
        {
            string[] ThouLetters = { "", "M", "MM", "MMM" };
            string[] HundLetters = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] TensLetters = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] OnesLetters = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            // See if it's >= 4000.
            if (arabic >= 4000)
            {
                // Use parentheses.
                int thou = arabic / 1000;
                arabic %= 1000;
                return "(" + ArabicToRoman(thou) + ")" +
                    ArabicToRoman(arabic);
            }

            // Otherwise process the letters.
            string result = "";

            // Pull out thousands.
            int num;
            num = arabic / 1000;
            result += ThouLetters[num];
            arabic %= 1000;

            // Handle hundreds.
            num = arabic / 100;
            result += HundLetters[num];
            arabic %= 100;

            // Handle tens.
            num = arabic / 10;
            result += TensLetters[num];
            arabic %= 10;

            // Handle ones.
            result += OnesLetters[arabic];

            return result;
        }

        static string GenerateInvoice(int count)
        {
            DateTime now = DateTime.Now.AddDays(1);
            return $"INV/{now.Year}{Convert.ToString(now.Month).PadLeft(2, '0')}{now.Day}/{ArabicToRoman(now.Day)}/{Convert.ToString(now.DayOfWeek).Substring(0, 2).ToUpper()}/{ArabicToRoman(Convert.ToInt32(Convert.ToString(now.Year).Substring(2,2)))}/{count + 1}";
        }
    }
}
