using NUnit.Framework;
using System.Collections.Generic;
using Touscript.Interpreter;
using Touscript.Interpreter.Operators;
using Touscript.Core;

namespace TouScript.Core.Tests
{
    [TestFixture]
    public class OnpParserTests
    {
        [Test]
        public void GivenTwoNumberWhenEvaluatingShouldAdd()
        {
            var parser = new OnpParser();
            var tokens = new List<Token>() {
                new Number(2),
                new Number(2),
                new Addition()
            };
            Assert.AreEqual(4, parser.Evaluate(tokens));
        }

        [Test]
        public void GivenTwoNumberWhenEvaluatingShouldSubtract()
        {
            var parser = new OnpParser();
            var tokens = new List<Token>() {
                new Number(1),
                new Number(2),
                new Subtraction()
            };
            Assert.AreEqual(1, parser.Evaluate(tokens));
        }

        [Test]
        public void GivenTwoNumberWhenEvaluatingShouldDivide()
        {
            var parser = new OnpParser();
            var tokens = new List<Token>() {
                new Number(2),
                new Number(2),
                new Division()
            };
            Assert.AreEqual(1, parser.Evaluate(tokens));
        }

        [Test]
        public void GivenTwoNumberWhenEvaluatingShouldDivideModulo()
        {
            var parser = new OnpParser();
            var tokens = new List<Token>() {
                new Number(2),
                new Number(3),
                new Subtraction()
            };
            Assert.AreEqual(1, parser.Evaluate(tokens));
        }
    }
}