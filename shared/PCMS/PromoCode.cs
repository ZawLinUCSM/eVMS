using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromoCode_MS
{
    public class PromoCode
    {

        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string RandomNumber()
        {
            var rand = new Random();
            // Generate and display 6 random integers from 0 to 999999.         
            var digitNumbers = string.Format("{0}", rand.Next(0, 999999));
            Console.Write("6 Digit numbers :" + digitNumbers);
            return digitNumbers;
        }
        public string Create()
        {
            return RandomNumber() + RandomString(5);
        }

    }
}
