namespace TDD_Sibala
{
    internal class Dice
    {
        public Dice(int value, string output)
        {
            Value = value;
            Output = output;
        }

        public string Output { get; internal set; }
        public int Value { get; internal set; }
    }
}