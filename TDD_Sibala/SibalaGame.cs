namespace TDD_Sibala
{
    internal class SibalaGame
    {
        public SibalaGame()
        {
        }

        internal string ShowResult(string input)
        {
            var parser = new Parser();
            var players = parser.Parse(input);
            var description = string.Empty;
            var winnerName = string.Empty;
            var winnerOutput = string.Empty;
            int compareResult = 0;

            var category1 = players[0].Dices.GetCategory();
            var category2 = players[1].Dices.GetCategory();

            if (category1.Type != category2.Type)
            {
                compareResult = category1.Type - category2.Type;
            }
            else
            {
                switch (category1.Type)
                {
                    case CategoryType.AllOfAKind:
                        var valueMap = new Dictionary<int, int> { { 1, 6 }, { 2, 1 }, { 3, 2 }, { 4, 5 }, { 5, 3 }, { 6, 4 } };

                        compareResult = valueMap[players[0].Dices.First().Value] - valueMap[players[1].Dices.First().Value];
                        break;

                    case CategoryType.NormalPoint:
                        var pairDices1 = players[0].Dices.GroupBy(dice => dice.Value).First(g => g.Count() == 2).ToList();
                        var point1 = players[0].Dices.Except(pairDices1).Sum(d => d.Value);
                        var pairDices2 = players[1].Dices.GroupBy(dice => dice.Value).First(g => g.Count() == 2).ToList();
                        var point2 = players[1].Dices.Except(pairDices2).Sum(d => d.Value);

                        compareResult = point1 - point2;
                        if (compareResult == 0)
                        {
                            compareResult = players[0].Dices.Except(pairDices1).Max(d => d.Value) - players[1].Dices.Except(pairDices2).Max(d => d.Value);
                        }
                        break;
                }
            }
            if (compareResult > 0)
            {
                winnerName = players[0].Name;
                description = $"{category1.Description}: {players[0].Dices.Output}";
            }
            else if (compareResult < 0)
            {
                winnerName = players[1].Name;
                description = $"{category1.Description}: {players[1].Dices.Output}";
            }
            else
            {
                return "Tie.";
            }

            return $"{winnerName} wins. - with {description}";
        }
    }
}