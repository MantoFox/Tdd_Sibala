using FluentAssertions;

namespace TDD_Sibala.Test
{
    [TestFixture]
    internal class SibalaGameTest
    {
        private SibalaGame _target;

        [SetUp]
        public void _SetUp()
        {
            _target = new SibalaGame();
        }

        [Test]
        public void A01_SibalaGame_ShowResult()
        {
            var actual = _target.ShowResult("Black: 5 5 5 5  White: 2 2 2 2");
            var expected = "Black wins. - with all of a kind: 5";

            AssertShowResultShouldReturn(actual, expected);
        }

        private static void AssertShowResultShouldReturn(string actual, string expected)
        {
            actual.Should().Be(expected);
        }
    }
}