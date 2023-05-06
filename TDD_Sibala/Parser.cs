namespace TDD_Sibala
{
    internal class Parser
    {
        internal List<Player> Parse(string input)
        {
            var playersSection = input.Split("  ", StringSplitOptions.RemoveEmptyEntries);
            Player player1 = GetPlayer(playersSection);

            return new List<Player>
            {
                player1
            };
        }

        private static Player GetPlayer(string[] playersSection)
        {
            var player = new Player();
            player.Name = playersSection[0].Split(":", StringSplitOptions.RemoveEmptyEntries)[0];
            var diceList = playersSection[0].Split(":", StringSplitOptions.RemoveEmptyEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => new Dice(int.Parse(x), x)).ToList();

            return new Player
            {
                Name = player.Name,
                Dices = new Dices(diceList)
            };
        }
    }
}