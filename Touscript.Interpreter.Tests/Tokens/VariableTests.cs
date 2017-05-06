using NUnit.Framework;
using Touscript.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touscript.Interpreter.Tests
{
    [TestFixture()]
    public class VariableTests
    {
        [Test()]
        public void GivenVariableNameWithSpaceWhenCreatingNewObjectThenRemoveWhitespace()
        {
            var sut = new Variable(" a ");
            Assert.AreEqual("a", sut.Name);
        }
    }
}