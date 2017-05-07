using Touscript.Core;
using NUnit.Framework;
using Touscript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touscript.Core.Tests
{
    [TestFixture()]
    public class StringExtensionsTests
    {
        [Test()]
        public void GivenStringFullOfWhiteSpace_WhenUsingStripWhiteSpace_ThenReturnOnlyABCD()
        {
            var testingString = " a \t b \r c \n d";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("abcd", result);
        }

        [Test()]
        public void GivenStringWithTab_WhenStrippingWhitespace_ThenRemovesIt()
        {
            var testingString = "a\t";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("a", result);
        }

        [Test()]
        public void GivenStringWithSpace_WhenStrippingWhitespace_ThenRemovesIt()
        {
            var testingString = "a ";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("a", result);
        }

        [Test()]
        public void GivenStringWithCaretReturn_WhenStrippingWhitespace_ThenRemovesIt()
        {
            var testingString = "a\r";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("a", result);
        }

        [Test()]
        public void GivenStringWithNewLine_WhenStrippingWhitespace_ThenRemovesIt()
        {
            var testingString = "a\n";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("a", result);
        }

        [Test()]
        public void GivenStringWithNewLineAndCaretReturn_WhenStrippingWhitespace_ThenRemovesIt()
        {
            var testingString = "a\n\r";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("a", result);
        }

        [Test()]
        public void GivenStringWithSpaceBetween_WhenStrippingWhitespace_ThenRemovesIt()
        {
            var testingString = "a b";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("ab", result);
        }

        [Test()]
        public void GivenStringWithMultipleSpacesBetween_WhenStrippingWhitespace_ThenRemovesIt()
        {
            var testingString = "a        b";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("ab", result);
        }

        [Test()]
        public void GivenA_WhenCheckingIfItIsInABC_ThenReturnTrue()
        {
            var value = "A";
            var array = new string[] { "A", "B", "C" };
            var result = value.In(array);
            Assert.IsTrue(result);
        }

        [Test()]
        public void GivenA_WhenCheckingIfItIsInBC_ThenReturnFalse()
        {
            var value = "A";
            var array = new string[] { "B", "C" };
            var result = value.In(array);
            Assert.IsFalse(result);
        }

        [Test()]
        public void GivenA_WhenCheckingIfItIsInBACA_ThenReturnTrue()
        {
            var value = "A";
            var array = new string[] { "B", "A", "C", "A" };
            var result = value.In(array);
            Assert.IsTrue(result);
        }

        [Test()]
        public void GivenStringWith10Chars_WhenUsingNeighBorOn5IndexWithRange3_ThenReturnFrom2To8()
        {
            var str = "0123456789";
            var result = str.Neighboor(4, 3);
            Assert.AreEqual("1234567", result);
        }

        [Test()]
        public void Given4CharsString_WhenUsingNeighBorOn2Char_ThenReturnWholeString()
        {
            var str = "0123";
            var result = str.Neighboor(2, 2);
            Assert.AreEqual("0123", result);
        }

        [Test()]
        public void Given5CharsString_WhenUsingNeighBorOn2Char_ThenReturnWholeString()
        {
            var str = "01234";
            var result = str.Neighboor(2, 2);
            Assert.AreEqual("01234", result);
        }

        [Test()]
        public void Given6CharsString_WhenUsingNeighBorOn2Char_ThenReturnWholeStringExceptLast()
        {
            var str = "012345";
            var result = str.Neighboor(2, 2);
            Assert.AreEqual("01234", result);
        }

        [Test()]
        public void Given6CharsString_WhenUsingNeighBorOn3Char_ThenReturnWholeStringExceptFirst()
        {
            var str = "012345";
            var result = str.Neighboor(3, 2);
            Assert.AreEqual("12345", result);
        }
    }
}