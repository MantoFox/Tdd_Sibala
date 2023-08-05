namespace TDD_Sibala
{
    internal class SibalaGame
    {
        internal string ShowResult(string input)
        {
            var parser = new Parser();
            var players = parser.Parse(input);
            Dictionary<int, int> valueMap = new Dictionary<int, int>
            {
                { 1, 6 },
                { 2, 1 },
                { 3, 2 },
                { 4, 5 },
                { 5, 3 },
                { 6, 4 },
            };
            int compareResult = valueMap[players[0].Dices.First().Value] - valueMap[players[1].Dices.First().Value];
            string description;
            string winnerName;
            if (compareResult > 0)
            {
                winnerName = players[0].Name;
                description = $"all of a kind: {players[0].Dices.First().Output}";
            }
            else if (compareResult < 0)
            {
                winnerName = players[1].Name;
                description = $"all of a kind: {players[1].Dices.First().Output}";
            }
            else
            {
                return "Tie.";
            }

            return $"{winnerName} wins. - with {description}";
        }
    }
}