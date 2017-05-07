using Touscript.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touscript.Core.Tests
{
    [TestFixture()]
    public class InterpreterTests
    {
        [Test()]
        public void GivenSimpleAssign_WhenInterpreting_ThenLeaveVariableOnHeap()
        {
            var instructions = "a=5";
            var interpreter = new Interpreter(new Lexer(instructions));
            interpreter.Interpret();
            Assert.IsTrue(interpreter.Variables.ContainsKey("a"));
            Assert.AreEqual(5, interpreter.Variables["a"]);
        }
        [Test()]
        public void GivenTwoSimpleAssignOnyTheSameLine_WhenInterpreting_ThenLeaveVariableOnHeap()
        {
            var instructions = "a=5";
            var interpreter = new Interpreter(new Lexer(instructions));
            interpreter.Interpret();
            Assert.IsTrue(interpreter.Variables.ContainsKey("a"));
            Assert.AreEqual(5, interpreter.Variables["a"]);
        }
    }
}