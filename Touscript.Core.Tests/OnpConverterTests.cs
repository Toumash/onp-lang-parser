using NUnit.Framework;
using System.Collections.Generic;

namespace Touscript.Core.Tests
{
    [TestFixture]
    public class OnpConverterTests
    {
        //[Test]
        //public void GivenNumberOperatorAndNumberThenReturnNumberNumberAndOperator()
        //{
        //    var parser = new OnpConverter();
        //    var input = new List<Token>
        //    {
        //        new Number(5),
        //        new Addition(),
        //        new Number(7)
        //    };
        //    var expectedOnpTokens = new List<Token>
        //    {
        //        new Number(5),
        //        new Number(7),
        //        new Addition(),
        //    };
        //    var onpTokens = parser.ConvertToONP(input);
        //    CollectionAssert.AreEqual(expectedOnpTokens, onpTokens);
        //}

        //[Test]
        //public void GivenExpressionFromExampleThenReturnTheSameButONP()
        //{
        //    var parser = new OnpConverter();
        //    var input = new List<Token>
        //    {
        //        new Number(2),   // b
        //        new Multiplication(),   // *
        //        new Number(3),   // c
        //        new Subtraction(),      // -
        //        new OpeningBracket(),   // (
        //        new Number(4),   // d
        //        new Addition(),         // +
        //        new Number(5),   // E
        //        new ClosingBracket(),   // )
        //        new Multiplication(),   // *
        //        new Number(4)    // 4
        //    };
        //    var expectedOnpTokens = new List<Token>
        //    {
        //        new Number(2),
        //        new Number(3),
        //        new Multiplication(),
        //        new Number(4),
        //        new Number(5),
        //        new Addition(),
        //        new Number(4),
        //        new Multiplication(),
        //        new Subtraction()
        //    };
        //    var onpTokens = parser.ConvertToONP(input);
        //    CollectionAssert.AreEqual(expectedOnpTokens, onpTokens);
        //}

        //[Test]
        //public void GivenSimpleBracketsThenReturnTheSameButONP()
        //{
        //    var parser = new OnpConverter();
        //    var input = new List<Token>
        //    {
        //        new OpeningBracket(),
        //        new Number(5),
        //        new Addition(),
        //        new Number(3),
        //        new ClosingBracket()
        //    };
        //    var expectedOnpTokens = new List<Token>
        //    {
        //       new Number(5),
        //       new Number(3),
        //       new Addition()
        //    };
        //    var onpTokens = parser.ConvertToONP(input);
        //    CollectionAssert.AreEqual(expectedOnpTokens, onpTokens);
        //}

        //[Test]
        //public void GivenOnlyBracketsThenReturnNone()
        //{
        //    var parser = new OnpConverter();
        //    var input = new List<Token>
        //    {
        //        new OpeningBracket(),
        //        new ClosingBracket()
        //    };
        //    var expectedOnpTokens = new List<Token>
        //    {
        //    };
        //    var onpTokens = parser.ConvertToONP(input);
        //    CollectionAssert.AreEqual(expectedOnpTokens, onpTokens);
        //}

        //[Test]
        //public void GivenOnlyOneBracketInvalidValueThenReturnInvalid()
        //{
        //    var parser = new OnpConverter();
        //    var input = new List<Token>
        //    {
        //        new OpeningBracket()
        //    };
        //    var expectedOnpTokens = new List<Token>
        //    {
        //        new OpeningBracket()
        //    };
        //    var onpTokens = parser.ConvertToONP(input);
        //    CollectionAssert.AreEqual(expectedOnpTokens, onpTokens);
        //}
    }
}