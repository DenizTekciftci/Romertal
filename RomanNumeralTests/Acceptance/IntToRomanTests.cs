using Romertal;

namespace RomanNumeralTests.Acceptance
{
    [TestClass]
    public class IntToRomanTests
    {
        [TestMethod]
        public void N1899_Equals_MDCCCXCIX()
        {
            // Arrange
            var num = 1899;

            // Act
            var roman = Converter.Convert(num);

            // Assert
            Assert.AreEqual(roman.numeral, "MDCCCXCIX");
        }

        [TestMethod]
        public void N1999_Equals_MCMXCIX()
        {
            // Arrange
            var num = 1999;

            // Act
            var roman = Converter.Convert(num);

            // Assert
            Assert.AreEqual(roman.numeral, "MCMXCIX");
        }

        [TestMethod]
        public void N2444_Equals_MMCDXLIV()
        {
            // Arrange
            var num = 2444;

            // Act
            var roman = Converter.Convert(num);

            // Assert
            Assert.AreEqual(roman.numeral, "MMCDXLIV");
        }

        [TestMethod]
        public void N90_Equals_XC()
        {
            // Arrange
            var num = 90;

            // Act
            var roman = Converter.Convert(num);

            // Assert
            Assert.AreEqual(roman.numeral, "XC");
        }

        [TestMethod]
        public void N0_Equals_Empty_String()
        {
            // Arrange
            var num = 0;

            // Act
            var roman = Converter.Convert(num);

            // Assert
            Assert.AreEqual(roman.numeral, "");
        }

        [TestMethod]
        public void N3000_Is_TooLarge()
        {
            // Arrange
            var num = 3000;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() => { var roman = Converter.Convert(num); });
        }
    }
}