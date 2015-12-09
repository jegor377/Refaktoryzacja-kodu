using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TxtToBin.Converter;

namespace UnitConverterTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void chceckIfBinaryAndTextConverterClassConvertValuesToNumeralSystemCorrectly()
        {
            //arrange
            var stringAndBinaryConverter = new BinAndTextConverter();
            var valueWhichHasToConvertToNumbers = "Test\r\n";
            var valueWhichHasToConvertFromNumbers = "01010100011001010111001101110100";

            //act
            var stringAndBinaryConvertionToNumbers = stringAndBinaryConverter.ConvertToNumbers(valueWhichHasToConvertToNumbers);

            //assert
            Assert.AreEqual(stringAndBinaryConvertionToNumbers, valueWhichHasToConvertFromNumbers);
        }

        [TestMethod]
        public void chceckIfBinaryAndTextConverterClassConvertValuesFromNumeralSystemCorrectly()
        {
            //arrange
            var stringAndBinaryConverter = new BinAndTextConverter();
            var valueWhichHasToConvertToNumbers = "Test\r\n";
            var valueWhichHasToConvertFromNumbers = "01010100011001010111001101110100";

            //act
            var stringAndBinaryConvertionFromNumbers = stringAndBinaryConverter.ConvertFromNumbers(valueWhichHasToConvertFromNumbers);

            //assert
            Assert.AreEqual(stringAndBinaryConvertionFromNumbers, valueWhichHasToConvertToNumbers.Substring(0, valueWhichHasToConvertToNumbers.Length - 2));
        }

        [TestMethod]
        public void checkIfHexadecimalAndTextConverterClassConvertValuesToNumeralSystemCorrectly()
        {
            //arrange
            var stringAndHexadecimalConverter = new HexAndTextConverter();
            var valueWhichHasToConvertToNumbers = "Test\r\n";
            var valueWhichHasToConvertFromNumbers = "54657374";

            //act
            var stringAndHexadecimalConvertionToNumbers = stringAndHexadecimalConverter.ConvertToNumbers(valueWhichHasToConvertToNumbers);

            //assert
            Assert.AreEqual(stringAndHexadecimalConvertionToNumbers, valueWhichHasToConvertFromNumbers);
        }

        [TestMethod]
        public void checkIfHexadecimalAndTextConverterClassConvertValuesFromNumeralSystemCorrectly()
        {
            //arrange
            var stringAndHexadecimalConverter = new HexAndTextConverter();
            var valueWhichHasToConvertToNumbers = "Test\r\n";
            var valueWhichHasToConvertFromNumbers = "54657374";

            //act
            var stringAndHexadecimalConvertionFromNumbers = stringAndHexadecimalConverter.ConvertFromNumbers(valueWhichHasToConvertFromNumbers);

            //assert
            Assert.AreEqual(stringAndHexadecimalConvertionFromNumbers, valueWhichHasToConvertToNumbers.Substring(0, valueWhichHasToConvertToNumbers.Length - 2));
        }

        [TestMethod]
        public void checkIfDecimalAndTextConverterClassConvertValuesToNumeralSystemCorrectly()
        {
            //arrange
            var stringAndDecimalConverter = new DecAndTextConverter();
            var valueWhichHasToConvertToNumbers = "Test\r\n";
            var valueWhichHasToConvertFromNumbers = "084101115116";

            //act
            var stringAndDecimalConvertionToNumbers = stringAndDecimalConverter.ConvertToNumbers(valueWhichHasToConvertToNumbers);
            
            //assert
            Assert.AreEqual(stringAndDecimalConvertionToNumbers, valueWhichHasToConvertFromNumbers);
        }

        [TestMethod]
        public void checkIfDecimalAndTextConverterClassConvertValuesFromNumeralSystemCorrectly()
        {
            //arrange
            var stringAndDecimalConverter = new DecAndTextConverter();
            var valueWhichHasToConvertToNumbers = "Test\r\n";
            var valueWhichHasToConvertFromNumbers = "084101115116";

            //act
            var stringAndDecimalConvertionFromNumbers = stringAndDecimalConverter.ConvertFromNumbers(valueWhichHasToConvertFromNumbers);

            //assert
            Assert.AreEqual(stringAndDecimalConvertionFromNumbers, valueWhichHasToConvertToNumbers.Substring(0, valueWhichHasToConvertToNumbers.Length-2));
        }
    }
}
