using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DiceDistribution2
{
    internal class InputData
    {
        int numberOfDice;
        int diceFaces;

        /// <summary>
        /// Количество игральных костей
        /// </summary>
        public int NumberOfDice
        {
            get { return numberOfDice; }
            set
            {
                if (value > 1) numberOfDice = value;
                else Console.WriteLine("Количество костей должо быть больше одной");
            }
        }
        /// <summary>
        /// Количество граней каждой игральной кости
        /// </summary>
        public int DiceFaces
        {
            get { return diceFaces; }
            set
            {
                if (value > 1) diceFaces = value;
                else Console.WriteLine("Количество граней должо быть больше одной");
            }
        }

        public InputData(int quantity, int faces)
        {
            NumberOfDice = quantity;
            DiceFaces = faces;
        }

        public Tuple<int, int> RangeOfOptions { get { return new Tuple<int, int>(NumberOfDice, NumberOfDice * DiceFaces); } }
    }
}
