using System.Linq;
using NUnit.Framework;

namespace RandomInteligence.Test
{
    [TestFixture]
    public class CommandRandomizerTest
    {
        private CommandRandomizer randomizer;

        [SetUp]
        public void Setup()
        {
            randomizer = new CommandRandomizer(new[] { new CommandStub { Id = 1 }, new CommandStub { Id = 2 } }, 0);
        }

        [Test]
        public void ShouldReturnRandomCommands()
        {
            var expected = new[] { 1, 1, 1, 2, 2, 2, 1, 1, 2, 2 };

            var actual = Enumerable.Range(0, 10).Select(_ => ((CommandStub)randomizer.GetRandom()).Id).ToArray();

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}