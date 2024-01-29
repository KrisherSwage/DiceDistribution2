using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceDistribution2
{
    internal class DataDistribution
    {
        public Dictionary<int, int> ResultDistribution { get; set; }

        public DataDistribution(InputData inputData)
        {
            ResultDistribution = new Dictionary<int, int>();

            var min = inputData.RangeOfOptions.Item1;
            var max = inputData.RangeOfOptions.Item2 + 1;
            for (int i = min; i < max; i++)
            {
                ResultDistribution.Add(i, 0);
            }
        }

        public DataDistribution(List<Dice> dices)
        {
            ResultDistribution = new Dictionary<int, int>();

            var min = dices.Count; // потому что можно каждую игральную кость сделать отличной от других.
                                   // тогда и минимум определяется количеством этих костей
            var max = 1;

            foreach (var dice in dices)
            {
                max += dice.Dimensionality;
            }

            for (int i = min; i < max; i++)
            {
                ResultDistribution.Add(i, 0);
            }
        }
    }
}
