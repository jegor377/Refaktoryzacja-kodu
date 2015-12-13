using System;

namespace TxtToBin.Converter
{
    public class NumeralSystemConverter
    {
        protected NumeralSystemBase numeralSystemBase;
        protected NumeralSystemFormat characterCountForNumeralSystem;

        public virtual string ConvertToNumbers(string valueToConvert)
        {
            valueToConvert = removeUnnecessaryCharacters(valueToConvert);
            if (!isValueEmpty(valueToConvert))
            {
                var binaryResult = changeAllCharactersToNumeralSystem(valueToConvert);
                return binaryResult;
            }
            return "";
        }

        public virtual string ConvertFromNumbers(string valueToConvert)
        {
            valueToConvert = removeUnnecessaryCharacters(valueToConvert);
            if (!isValueEmpty(valueToConvert))
            {
                var convertedTextResult = collectAllNumbersAndChangeThemToCharacters(valueToConvert);
                return convertedTextResult;
            }
            return "";
        }

        protected string changeAllCharactersToNumeralSystem(string valueToChange)
        {
            var numeralSystemResult = "";

            for (var i = 0; i < valueToChange.Length; i++)
            {
                var convertedToNumeralSystemValue = convertCharacterToNumeralSystemNumber((byte)valueToChange[i]);

                // It adds some zeros on the front of the string (if the converted value length is 
                // less than required length for this numeral system) to get static format.
                numeralSystemResult += (convertedToNumeralSystemValue.Length == (int)characterCountForNumeralSystem ?
                    convertedToNumeralSystemValue :
                    addZerosOnTheFrontOfNumeralSystemNumber(convertedToNumeralSystemValue));
            }

            return numeralSystemResult;
        }

        protected string collectAllNumbersAndChangeThemToCharacters(string valueToChange)
        {
            var convertedTextResult = "";

            // It goes through every characters and if 'i' "is every second number", then it sets 'i' to the sign.
            // Then it cuts two characters from the string (from 'j' to 'i') and adds the cut out 
            // value to convertedTextResult as char.
            // When it finish, it sets 'j' to 'i' to cut the next value from the last end point of cut.
            for (int i = 0, j = 0; i <= valueToChange.Length; i++)
            {
                if (isNumberEverySecond(i))
                {
                    var convertedFromNumeralSystemValue = convertNumberToCharacter(valueToChange.Substring(j, i - j));
                    convertedTextResult += Convert.ToChar(convertedFromNumeralSystemValue);
                    j = i;
                }
            }

            return convertedTextResult;
        }

        protected string convertCharacterToNumeralSystemNumber(byte valueToConvert)
        {
            return Convert.ToString(valueToConvert, (int)numeralSystemBase);
        }

        protected int convertNumberToCharacter(string valueToConvert)
        {
            return isValueEmpty(valueToConvert) ? 0 : Convert.ToInt32(valueToConvert, (int)numeralSystemBase);
        }

        protected string addZerosOnTheFrontOfNumeralSystemNumber(string valueToAddZeros)
        {
            return new string('0', Math.Abs(valueToAddZeros.Length - (int)characterCountForNumeralSystem)) + valueToAddZeros;
        }

        protected string removeUnnecessaryCharacters(string value)
        {
            return value.Replace("\n", string.Empty).Replace("\r", string.Empty);
        }

        protected bool isValueEmpty(string valueToCheck)
        {
            return valueToCheck.Equals(string.Empty);
        }

        protected bool isNumberEverySecond(int index)
        {
            return index % (int)characterCountForNumeralSystem == 0 && index != 0;
        }
    }
}
