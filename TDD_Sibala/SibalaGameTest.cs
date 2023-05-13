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
        [TestCase("Black: 3 3 3 3  White: 6 6 6 6", "White wins. - with all of a kind: 6")]
        [TestCase("Black: 3 3 3 3  White: 3 3 3 3", "Tie.")]
        [TestCase("Black: 4 4 4 4  White: 5 5 5 5", "Black wins. - with all of a kind: 4")]
        [TestCase("Black: 6 6 6 6  White: 4 4 4 4", "White wins. - with all of a kind: 4")]
        [TestCase("Black: 4 4 4 4  White: 1 1 1 1", "White wins. - with all of a kind: 1")]
        public void A01_SibalaGame_ShowResult_BothAllOfAKind(string input, string expected)
        {
            var actual = _target.ShowResult(input);

            AssertShowResultShouldReturn(actual, expected);
        }

        [Test]
        [TestCase("Black: 2 6 2 3  White: 5 3 5 4", "Black wins. - with normal point: 9")]
        [TestCase("Black: 2 1 3 3  White: 2 2 1 3", "White wins. - with normal point: 4")]
        [TestCase("Black: 2 3 4 2  White: 1 1 4 3", "Tie.")]
        [TestCase("Black: 2 2 4 4  White: 2 3 2 1", "Black wins. - with normal point: 8")]
        [TestCase("Black: 3 4 5 5  White: 4 1 4 6", "White wins. - with normal point: 7")]
        public void A02_SibalaGame_ShowResult_BothNormalPoint(string input, string expected)
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