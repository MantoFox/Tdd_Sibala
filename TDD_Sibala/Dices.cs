namespace TDD_Sibala
{
    internal class Dices : List<Dice>
    {
        public Dices(List<Dice> dices)
            : base(dices)
        {
        }

        public string Output
        {
            get
            {
                if (this.GroupBy(x => x.Value).Any(g => g.Count() == 4))
                {
                    return this.First().Output;
                }
                else if (this.GroupBy(x => x.Value).Any(g => g.Count() == 2))
                {
                    List<Dice> pairDices = this.GroupBy(dice => dice.Value).First(g => g.Count() == 2).ToList();
                    var point = this.Except(pairDices).Sum(d => d.Value);
                    return point.ToString();
                }

                return string.Empty;
            }
        }

        internal Category GetCategory()
        {
            if (this.GroupBy(x => x.Value).Any(g => g.Count() == 4))
            {
                return new Category
                {
                    Type = CategoryType.AllOfAKind,
                    Description = "all of a kind"
                };
            }
            else if (this.GroupBy(x => x.Value).Any(g => g.Count() == 2))
            {
                return new Category
                {
                    Type = CategoryType.NormalPoint,
                    Description = "normal point"
                };
            }

            return new Category
            {
                Type = CategoryType.NoPoint,
                Description = string.Empty
            }; ;
        }
    }
}