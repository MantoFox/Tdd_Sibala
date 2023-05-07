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

            int compareResult = players[0].Dices.First().Value - players[1].Dices.First().Value;
            if (compareResult > 0)
            {
                winnerName = players[0].Name;
                description = $"all of a kind: {players[0].Dices.First().Output}";
            }

            // Black wins. - with all of a kind: 5
            // {winner name} wins. - with {description}
            return $"{winnerName} wins. - with {description}";
        }
    }
}