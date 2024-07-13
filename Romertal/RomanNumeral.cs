using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Romertal
{
    public class RomanNumeral
    {
        private string? _numeral;
        private string allowedBeforeLargerNumeral = "IXC";

        public string? numeral
        {
            get
            {
                return _numeral;
            }
            set
            {
                if (!isValidRomanNumeral(value))
                {
                    throw new ArgumentException("Input is not a valid Roman numeral.");
                }
                _numeral = value;
            }
        }

        public RomanNumeral(string input)
        {
            numeral = input.ToUpper();
        }

        private bool isValidRomanNumeral(string input)
        {
            string allowedCharacters = "IVXLCDM";
            // Check for characters outside the allowed set
            if (!input.All(allowedCharacters.Contains))
            {
                return false;
            }

            // Arguable wrong
            if (input.Length == 0)
            {
                return true;
            }

            int ascendingCharsCounter = 0;
            int equalCharsCounter = 0;
            char prevChar = input[0];
            int prevValue = Consts.NumeralValuePairs[prevChar];

            foreach (char currentChar in input.Skip(1))
            {
                var currentValue = Consts.NumeralValuePairs[currentChar];

                if (prevValue < currentValue)
                {
                    // Only I, X, and C allowed before larger numeral
                    if (!allowedBeforeLargerNumeral.Contains(prevChar))
                    {
                        return false;
                    }

                    // Check whether previous character is allowed before current
                    if (prevChar == 'I' && !("XV".Contains(currentChar)))
                    {
                        return false;
                    }

                    if (prevChar == 'X' && !("LC".Contains(currentChar)))
                    {
                        return false;
                    }

                    if (prevChar == 'C' && !("DM".Contains(currentChar)))
                    {
                        return false; 
                    }

                    ascendingCharsCounter++;
                }
                else if (prevValue == currentValue)
                {
                    ascendingCharsCounter++;
                    equalCharsCounter++;
                }
                else
                {
                    ascendingCharsCounter = 0;
                    equalCharsCounter = 0;
                }

                // If we have more than 3 of the same char next to each other
                // or we have more than one smaller character before a larger one
                if (equalCharsCounter > 2 || (ascendingCharsCounter > 1 && ascendingCharsCounter != equalCharsCounter))
                {
                    return false;
                }

                prevChar = currentChar;
                prevValue = Consts.NumeralValuePairs[prevChar];
            }

            return true;
        }
    }
}
