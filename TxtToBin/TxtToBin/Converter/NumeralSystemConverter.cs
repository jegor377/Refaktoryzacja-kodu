using System;
using System.Text;

namespace TxtToBin.Converter
{
    public class NumeralSystemConverter
    {
        protected NumeralSystemBase numeralSystemBase;
        protected NumeralSystemFormat characterCountForNumeralSystem;

        public virtual string ConvertToNumbers(string valueToConvert)
        {
            valueToConvert = removeStringEndingChars(valueToConvert);
            if (!isValueEmpty(valueToConvert))
            {
                var binaryResult = changeValueToNumeralSystem(valueToConvert);
                return binaryResult;
            }
            return "";
        }

        public virtual string ConvertFromNumbers(string valueToConvert)
        {
            valueToConvert = removeStringEndingChars(valueToConvert);
            if (!isValueEmpty(valueToConvert))
            {
                var convertedTextResult = changeNumeralSystemToValue(valueToConvert);
                return convertedTextResult;
            }
            return "";
        }

        protected string changeValueToNumeralSystem(string valueToChange)
        {
            var numeralSystemResult = "";
            var numeralSystemValueConvertedToASCIIbytes = Encoding.ASCII.GetBytes(valueToChange);

            for (var i = 0; i < numeralSystemValueConvertedToASCIIbytes.Length; i++)
            {
                var convertedToNumeralSystemValue = convertToNumeralSystem(numeralSystemValueConvertedToASCIIbytes[i]);

                // It adds some zeros on the front of the string (if the converted value is 
                // less than format character count) to get static format.
                numeralSystemResult += (convertedToNumeralSystemValue.Length == (int)characterCountForNumeralSystem ?
                    convertedToNumeralSystemValue :
                    addZerosOnTheFrontOfResult(convertedToNumeralSystemValue));
            }

            return numeralSystemResult;
        }

        protected string changeNumeralSystemToValue(string valueToChange)
        {
            var convertedTextResult = "";

            // It goes through every character and if 'i' "is every second", then it sets 'i' to the sign.
            // Then it cuts two characters from the string (from 'j' to 'i') and adds the cut out 
            // value to convertedTextResult as char.
            // When it finish, it sets 'j' to 'i' to cut the next value from the last end point of cut.
            for (int i = 0, j = 0; i <= valueToChange.Length; i++)
            {
                if (isEverySecond(i))
                {
                    var convertedFromNumeralSystemValue = convertFromNumeralSystemToValue(valueToChange.Substring(j, i - j));
                    convertedTextResult += Convert.ToChar(convertedFromNumeralSystemValue);
                    j = i;
                }
            }

            return convertedTextResult;
        }

        protected string convertToNumeralSystem(byte valueToConvert)
        {
            return Convert.ToString(valueToConvert, (int)numeralSystemBase);
        }

        protected int convertFromNumeralSystemToValue(string valueToConvert)
        {
            return valueToConvert.Equals(string.Empty) ? 0 : Convert.ToInt32(valueToConvert, (int)numeralSystemBase);
        }

        protected string addZerosOnTheFrontOfResult(string valueToAddZeros)
        {
            return new string('0', Math.Abs(valueToAddZeros.Length - (int)characterCountForNumeralSystem)) + valueToAddZeros;
        }

        protected string removeStringEndingChars(string value)
        {
            return value.Replace("\n", string.Empty).Replace("\r", string.Empty);
        }

        protected bool isValueEmpty(string valueToCheck)
        {
            return valueToCheck.Equals(string.Empty);
        }

        protected bool isEverySecond(int index)
        {
            return index % (int)characterCountForNumeralSystem == 0 && index != 0;
        }
    }
}
