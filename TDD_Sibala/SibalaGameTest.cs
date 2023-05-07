using FluentAssertions;

namespace TDD_Sibala
{
    [TestFixture]
    internal class SibalaGameTest
    {
        private SibalaGame _target;

        [SetUp]
        public void @SetUp()
        {
            _target = new SibalaGame();
        }

        [Test]
        [TestCase("Black: 5 5 5 5  White: 2 2 2 2", "Black wins. - with all of a kind: 5")]
        public void A01_SibalaGame_ShowResult(string input, string expected)
        {
            var actual = _target.ShowResult(input);

            AssertShowResultShouldReturn(actual, expected);
        }

        private static void AssertShowResultShouldReturn(string actual, string expected)
        {
            actual.Should().Be(expected);
        }
    }
}