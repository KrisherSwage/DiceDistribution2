using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DiceDistribution2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var ui = new UserInput();

                var mode = ui.InputMode();
                List<Dice> dices;
                if (mode == true)
                {
                    dices = ui.IdenticalDice();                             // вариант 1
                }
                else
                {
                    dices = ui.DissimilarDice();                              // вариант 2
                }

                var dataDistribution = new DataDistribution(dices);

                Stopwatch time = new Stopwatch(); //время
                time.Start(); //время

                var calc = new Calculate(new Dictionary<int, int>(dataDistribution.ResultDistribution), dices);
                calc.ReceivingDistribution(0, 0);

                time.Stop(); // Za Warudo! Toki wo Tomare!
                double myTime = time.ElapsedMilliseconds / 1000.0; //время
                Console.WriteLine($"\nВремя расчета: {myTime} сек"); //время

                var distributionResult = dataDistribution.ResultDistribution = calc.Distr;

                var analysis = new Analysis(distributionResult);
                analysis.AnalysisOutput();

                Console.WriteLine("Нажмите enter");
                Console.ReadLine();
            }
        }

    }
}