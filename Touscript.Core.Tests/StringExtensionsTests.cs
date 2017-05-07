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
    }
}