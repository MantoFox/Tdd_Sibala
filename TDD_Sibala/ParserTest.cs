﻿using FluentAssertions;

namespace TDD_Sibala
{
    [TestFixture]
    internal class ParserTest
    {
        private Parser _target;

        [SetUp]
        public void @SetUp()
        {
            _target = new Parser();
        }

        [Test]
        public void A01_Parser_Parse()
        {
            List<Player> actual = _target.Parse("Black: 5 5 5 5");
            var expected = new List<Player>
            {
                new Player
                {
                    Name = "Black",
                    Dices = new Dices(new List<Dice>
                    {
                        new Dice(5,"5"),
                        new Dice(5,"5"),
                        new Dice(5,"5"),
                        new Dice(5,"5")
                    })
                }
            };

            actual.Should().BeEquivalentTo(expected);
        }
    }
}