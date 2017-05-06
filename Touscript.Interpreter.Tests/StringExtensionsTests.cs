using NUnit.Framework;
using Touscript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touscript.Tests
{
    [TestFixture()]
    public class StringExtensionsTests
    {
        [Test()]
        public void StripWhiteSpaceTest()
        {
            var testingString = " a \t b \r c \n d";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("abcd", result);
        }

        [Test()]
        public void GivenStringWithTabWhenStrippingWhitespaceRemovesIt()
        {
            var testingString = "a\t";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("a", result);
        }

        [Test()]
        public void GivenStringWithSpaceWhenStrippingWhitespaceRemovesIt()
        {
            var testingString = "a ";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("a", result);
        }

        [Test()]
        public void GivenStringWithCaretReturnWhenStrippingWhitespaceRemovesIt()
        {
            var testingString = "a\r";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("a", result);
        }

        [Test()]
        public void GivenStringWithNewLineWhenStrippingWhitespaceRemovesIt()
        {
            var testingString = "a\n";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("a", result);
        }

        [Test()]
        public void GivenStringWithNewLineAndCaretReturnWhenStrippingWhitespaceRemovesIt()
        {
            var testingString = "a\n\r";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("a", result);
        }

        [Test()]
        public void GivenStringWithSpaceBetweenWhenStrippingWhitespaceRemovesIt()
        {
            var testingString = "a b";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("ab", result);
        }

        [Test()]
        public void GivenStringWithMultipleSpacesBetweenWhenStrippingWhitespaceRemovesIt()
        {
            var testingString = "a        b";
            var result = testingString.StripWhiteSpace();
            Assert.AreEqual("ab", result);
        }
    }
}