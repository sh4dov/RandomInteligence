using System;
using NUnit.Framework;

namespace RandomInteligence.Test
{
    [TestFixture]
    public class CommandTest
    {
        private CommandStub command;

        [SetUp]
        public void Setup()
        {
            command = new CommandStub();
        }

        [TestCase(0)]
        [TestCase(-1)]
        [ExpectedException(typeof(ArgumentException))]
        public void PriorityCannotBeNegativeOrZero(int priority)
        {
            command.Priority = priority;
        }
    }
}