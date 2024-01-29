using System.Collections.Generic;

namespace DiceDistribution2
{
    internal class Calculate
    {
        static Dictionary<int, int> distr;
        public Dictionary<int, int> Distr { get { return distr; } set { distr = value; } }

        static List<Dice> dices;
        public List<Dice> Dices { get { return dices; } set { dices = value; } }

        public Calculate(Dictionary<int, int> distInput, List<Dice> dicesInput)
        {
            Distr = distInput;
            Dices = dicesInput;
        }

        public void ReceivingDistribution(int numberOfDice, int result)
        {
            if (numberOfDice == dices.Count - 1)
            {
                foreach (var ex in dices[numberOfDice])
                {
                    distr[result + ex]++;
                }
            }
            else
            {
                foreach (var d in dices[numberOfDice])
                {
                    ReceivingDistribution(numberOfDice + 1, result + d);
                }
            }
        }
    }
}
