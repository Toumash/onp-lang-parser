using NUnit.Framework;
using Touscript.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touscript.Core.Tests
{
    [TestFixture()]
    public class LexerTests
    {
        [Test()]
        public void GivenAssignmentToken_WhenGetNextToken_ThenReturnAssignment()
        {
            var lexer = new Lexer("=");
            var token = lexer.GetNextToken();
            var expected = new Token(TokenTypes.ASSIGN, '=');
            Assert.AreEqual(expected, token);
        }

        [Test()]
        public void GivenVariableToken_WhenGetNextToken_ThenReturnFullVariableName()
        {
            var lexer = new Lexer("abc");
            var token = lexer.GetNextToken();
            var expected = new Token(TokenTypes.VAR, "abc");
            Assert.AreEqual(expected, token);
        }

        [Test()]
        public void GivenVariableTokenWithAssignment_WhenGetNextToken_ThenReturnVariable()
        {
            var lexer = new Lexer("abc=1");
            var variableToken = lexer.GetNextToken();
            var variableExpected = new Token(TokenTypes.VAR, "abc");
            Assert.AreEqual(variableExpected, variableToken);
        }

        [Test()]
        public void GivenVariableTokenWithAssignment_WhenGetNextToken_ThenReturnValue()
        {
            var lexer = new Lexer("abc=1");
            // ignore variableToken
            lexer.GetNextToken();
            // ignore assignmentToken
            lexer.GetNextToken();

            var valueToken = lexer.GetNextToken();
            var expectedToken = new Token(TokenTypes.NUMBER, 1);
            Assert.AreEqual(valueToken, expectedToken);
        }

        [Test()]
        public void GivenMultidigitInteger_WhenParsinUsingInteger_ThenGetFullNumber()
        {
            var lexer = new Lexer("15289374");
            var numberToken = lexer.GetNextToken();
            Assert.AreEqual(TokenTypes.NUMBER, numberToken.Type);
            Assert.AreEqual(15289374, numberToken.Value);
        }
    }
}