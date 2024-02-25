using Romertal;

namespace RomanNumeralTests.Acceptance
{
    [TestClass]
    public class RomanToIntTests
    {
        [TestMethod]
        public void Empty_String_Equals_0()
        {
            // Arrange
            var input = "";
            var numeral = new RomanNumeral(input);

            // Act
            var number = Converter.Convert(numeral);

            // Assert
            Assert.AreEqual(number, 0);
        }

        [TestMethod]
        public void MCCCCX_Is_Invalid()
        {
            // Arrange
            var input = "MCCCCX";

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => {var numeral = new RomanNumeral(input);});
        }

        [TestMethod]
        public void MDCCCXCIX_Equals_1899()
        {
            // Arrange
            var input = "MDCCCXCIX";
            var numeral = new RomanNumeral(input);

            // Act
            var number = Converter.Convert(numeral);

            // Assert
            Assert.AreEqual(number, 1899);
        }

        [TestMethod]
        public void MCMXCIX_Equals_1999()
        {
            // Arrange
            var input = "MCMXCIX";
            var numeral = new RomanNumeral(input);

            // Act
            var number = Converter.Convert(numeral);

            // Assert
            Assert.AreEqual(number, 1999);
        }

        [TestMethod]
        public void MMCDXLIV_Equals_2444()
        {
            // Arrange
            var input = "MMCDXLIV";
            var numeral = new RomanNumeral(input);

            // Act
            var number = Converter.Convert(numeral);

            // Assert
            Assert.AreEqual(number, 2444);
        }

        [TestMethod]
        public void XC_Equals_90()
        {
            // Arrange
            var input = "XC";
            var numeral = new RomanNumeral(input);

            // Act
            var number = Converter.Convert(numeral);

            // Assert
            Assert.AreEqual(number, 90);
        }
    }
}