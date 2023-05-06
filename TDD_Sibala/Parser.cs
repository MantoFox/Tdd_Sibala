namespace TDD_Sibala
{
    internal class Parser
    {
        internal List<Player> Parse(string input)
        {
            var playersSection = input.Split("  ", StringSplitOptions.RemoveEmptyEntries);
            var player1 = new Player();
            player1.Name = playersSection[0].Split(":", StringSplitOptions.RemoveEmptyEntries)[0];
            var dicesSection = playersSection[0].Split(":", StringSplitOptions.RemoveEmptyEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            player1.Dices = new Dices(new List<Dice>
                    {
                        new Dice {Value = int.Parse(dicesSection[0]), Output = dicesSection[0]},
                        new Dice {Value = int.Parse(dicesSection[1]), Output = dicesSection[1]},
                        new Dice {Value = int.Parse(dicesSection[2]), Output = dicesSection[2]},
                        new Dice {Value = int.Parse(dicesSection[3]), Output = dicesSection[3]},
                    });

            return new List<Player>
            {
                player1
            };
        }
    }
}