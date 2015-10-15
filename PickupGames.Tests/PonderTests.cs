using NUnit.Framework;

namespace PickupGames.Tests
{
    [TestFixture]
    public class PonderTests
    {
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void Test()
        {
            var temp = Stuff.Roy.ToString();
            var tempA = Stuff.Roy;
            var temp2 = Stuff.Dave.ToString();
            var temp2A = Stuff.Dave;
        }
    }

    public enum Stuff
    {
        Roy,
        Bob,
        Dave
    }
}
