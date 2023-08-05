﻿using FluentAssertions;

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
        [TestCase("Black: 5 5 5 5  White: 2 2 2 2", "Black wins. - with all of a kind: 5")]
        [TestCase("Black: 3 3 3 3  White: 6 6 6 6", "White wins. - with all of a kind: 6")]
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