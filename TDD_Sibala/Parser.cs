namespace TDD_Sibala
{
    internal class Parser
    {
        internal List<Player> Parse(string input)
        {
            var playersSection = input.Split("  ", StringSplitOptions.RemoveEmptyEntries);
            Player player1 = GetPlayer(playersSection, 0);
            Player player2 = GetPlayer(playersSection, 1);
            return new List<Player>
            {
                player1,
                player2
            };
        }

        private static Player GetPlayer(string[] playersSection, int index)
        {
            var playerName = playersSection[index].Split(":", StringSplitOptions.RemoveEmptyEntries)[0];
            var diceList = playersSection[index].Split(":", StringSplitOptions.RemoveEmptyEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => new Dice(int.Parse(x), x)).ToList();

            return new Player
            {
                Name = playerName,
                Dices = new Dices(diceList)
            };
        }
    }
}