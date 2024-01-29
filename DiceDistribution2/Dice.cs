using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceDistribution2
{
    internal class Dice
    {
        int dimensionality;

        /// <summary>
        /// Количество граней одной игральной кости
        /// </summary>
        public int Dimensionality
        {
            get { return dimensionality; }
            private set { if (value > 1) dimensionality = value; } //стоит ли тут оставлять проверку..?
        }

        /// <summary>
        /// Шанс выпадения одной грани
        /// </summary>
        public double ChanceOfEdge { get { return Math.Round(1.0 / Dimensionality, 3); } }

        public Dice(InputData inputData)
        {
            Dimensionality = inputData.DiceFaces;
        }

        public Dice(int dim)
        {
            Dimensionality = dim;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 1; i < Dimensionality + 1; i++)
            {
                yield return i;
            }
        }

    }
}
