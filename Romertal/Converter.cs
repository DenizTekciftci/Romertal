using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romertal
{
    public static class Converter
    {
        private static readonly Dictionary<char, int> NumeralValuePairs = new Dictionary<char, int>
        {
            { 'M', 1000 },
            { 'D', 500 },
            { 'C', 100 },
            { 'L', 50 },
            { 'X', 10 },
            { 'V', 5 },
            { 'I', 1 },
        };

        private static readonly Dictionary<int, char> ValueNumeralPairs = new Dictionary<int, char>
        {
            { 1000, 'M' },
            { 500, 'D' },
            { 100, 'C' },
            { 50, 'L' },
            { 10, 'X' },
            { 5, 'V' },
            { 1, 'I'},
        };

        // Only powers of ten as divisors
        private static readonly List<int> Divisors = new List<int> {1000, 100, 10, 1};

        public static int Convert(RomanNumeral romanNumeral)
        {
            int result = 0;
            
            // Empty or null strings we consider to be 0
            if(romanNumeral.numeral == null || romanNumeral.numeral.Length == 0)
            {
                return result;
            }

            // Single character numeral
            if(romanNumeral.numeral.Length == 1)
            {
                return NumeralValuePairs[romanNumeral.numeral[0]];
            }

            char prevChar = romanNumeral.numeral[0];
            int prevValue = NumeralValuePairs[prevChar];

            foreach (char currentChar in romanNumeral.numeral.Skip(1))
            {
                var currentValue = NumeralValuePairs[currentChar];

                if(prevValue < currentValue) 
                {
                    result -= prevValue;
                }
                else
                {
                    result += prevValue;
                }

                prevChar = currentChar;
                prevValue = NumeralValuePairs[prevChar];
            }

            // Add the last character
            result += NumeralValuePairs[romanNumeral.numeral.Last()];

            return result;
        }

        public static RomanNumeral Convert(int number)
        {
            var limit = Divisors[0] * 3 - 1;
            var roman = "";
            var remainder = number;

            if (number > limit)
            {
                throw new ArgumentException($"Cannot convert numbers larger than {limit}");
            }

            foreach(var divisor in Divisors)
            {
                var numeral = ValueNumeralPairs[divisor];
                int divCount = remainder / divisor;

                // Up to three of the same character
                if(divCount < 4)
                {
                    roman = roman + new string(numeral, divCount);
                }
                else if (divCount == 9)
                {
                    roman = roman + numeral + ValueNumeralPairs[divisor * 10];
                }
                else
                {
                    if (divCount == 4)
                    {
                        roman += numeral;
                    }
                    roman = roman + ValueNumeralPairs[divisor * 5] + new string(numeral, Math.Max(divCount - 5, 0));
                }

                // Update
                remainder -= divCount * divisor;
            }

            return new RomanNumeral(roman);
        }
    }
}
