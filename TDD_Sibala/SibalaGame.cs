namespace TDD_Sibala
{
    internal class SibalaGame
    {
        public SibalaGame()
        {
        }

        internal string ShowResult(string input)
        {
            // Black: 5 5 5 5  White: 2 2 2 2
            var parser = new Parser();
            var players = parser.Parse(input);
            string description = string.Empty;
            string winnerName = string.Empty;
            string winnerOutput = string.Empty;
            int compareResult = 0;

            // compare type
            Category category = players[0].Dices.GetCategory();
            switch (category.Type)
            {
                case CategoryType.AllOfAKind:
                    Dictionary<int, int> valueMap = new Dictionary<int, int> { { 1, 6 }, { 2, 1 }, { 3, 2 }, { 4, 5 }, { 5, 3 }, { 6, 4 } };

                    compareResult = valueMap[players[0].Dices.First().Value] - valueMap[players[1].Dices.First().Value];
                    break;

                case CategoryType.NormalPoint:
                    List<Dice> pairDices1 = players[0].Dices.GroupBy(dice => dice.Value).First(g => g.Count() == 2).ToList();
                    var point1 = players[0].Dices.Except(pairDices1).Sum(d => d.Value);
                    List<Dice> pairDices2 = players[1].Dices.GroupBy(dice => dice.Value).First(g => g.Count() == 2).ToList();
                    var point2 = players[1].Dices.Except(pairDices2).Sum(d => d.Value);

                    compareResult = point1 - point2;
                    if (compareResult == 0)
                    {
                        compareResult = players[0].Dices.Except(pairDices1).Max(d => d.Value) - players[1].Dices.Except(pairDices2).Max(d => d.Value);
                    }
                    break;
            }

            if (compareResult > 0)
            {
                winnerName = players[0].Name;
                description = $"{category.Description}: {players[0].Dices.Output}";
            }
            else if (compareResult < 0)
            {
                winnerName = players[1].Name;
                description = $"{category.Description}: {players[1].Dices.Output}";
            }
            else
            {
                return "Tie.";
            }

            // Black wins. - with all of a kind: 5
            return $"{winnerName} wins. - with {description}";
        }
    }
}