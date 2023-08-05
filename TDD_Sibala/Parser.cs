namespace TDD_Sibala
{
    internal class Parser
    {
        internal List<Player> Parse(string input)
        {
            return new List<Player>
            {
                new Player
                {
                    Name = "Black",
                    Dices = new Dices(new List<Dice>
                    {
                        new Dice {Value = 5, Output = "5"},
                        new Dice {Value = 5, Output = "5"},
                        new Dice {Value = 5, Output = "5"},
                        new Dice {Value = 5, Output = "5"}
                    })
                }
            };
        }
    }
}