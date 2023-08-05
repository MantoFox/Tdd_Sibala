namespace TDD_Sibala
{
    internal class SibalaGame
    {
        internal string ShowResult(string input)
        {
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
            else if (compareResult < 0)
            {
                winnerName = players[1].Name;
                description = $"all of a kind: {players[1].Dices.First().Output}";
            }

            return $"{winnerName} wins. - with {description}";
        }
    }
}