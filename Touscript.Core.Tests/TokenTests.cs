using NUnit.Framework;

namespace Touscript.Core.Tests
{
    [TestFixture()]
    public class TokenTests
    {
        [Test()]
        public void GivenTokenVariable_WhenUsingToString_ThenGiveInternalTokenRepresentation()
        {
            var token = new Token(TokenTypes.VAR, 5);
            var result = token.ToString();
            Assert.IsTrue(result.Contains("5"));
            Assert.IsTrue(result.Contains("Token"));
        }

        [Test()]
        public void GivenTokenAssignment_WhenUsingToString_ThenGiveInternalRepresentation()
        {
            var token = new Token(TokenTypes.ASSIGN, '=');
            var result = token.ToString();
            Assert.IsTrue(result.Contains("="));
            Assert.IsTrue(result.Contains(TokenTypes.ASSIGN));
        }
    }
}