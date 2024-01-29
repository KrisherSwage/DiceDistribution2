using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceDistribution2
{
    internal class Analysis
    {
        private int numberOfDiceSums;
        private ulong numberOfCombinations;

        private Dictionary<int, int> distribution;

        public Analysis(Dictionary<int, int> recDistribution)
        {
            distribution = recDistribution;

            var first = distribution.First();
            var last = distribution.Last();
            numberOfDiceSums = last.Key - first.Key + 1;

            foreach (var d in distribution)
            {
                numberOfCombinations += Convert.ToUInt64(d.Value);
            }
        }

        public void AnalysisOutput()
        {
            Delimiter("-", 35);
            Console.WriteLine($"Количество различных вариантов: {numberOfDiceSums}");
            Delimiter("-", 35);
            Console.WriteLine($"Всего комбинаций: {numberOfCombinations}");
            Delimiter("-", 35);

            MainInformation();
        }

        private void MainInformation()
        {
            string sum = "Сумма";
            string variant = "Вариантов";
            string percentage = "Процентаж";
            string diagram = "Диаграмма";

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{sum}\t| {variant}\t| {percentage}\t| {diagram}");
            Console.ResetColor();

            foreach (var d in distribution)
            {
                Console.Write($"{d.Key}");
                Delimiter2(" ", sum.Length - d.Key.ToString().Length);
                Console.Write("\t| ");

                Console.Write($"{d.Value}");
                Delimiter2(" ", variant.Length - d.Value.ToString().Length);
                Console.Write("\t| ");

                var nowPercent = Math.Round((d.Value * 1.0) / numberOfCombinations, 3);
                if (nowPercent != 0)
                {
                    Console.Write($"{nowPercent} %");
                    Delimiter2(" ", percentage.Length - nowPercent.ToString().Length);
                    Console.Write("\t| ");
                }
                else
                {
                    Console.Write($"< 0.001 %");
                    Console.Write("\t| ");
                }

                if (nowPercent * numberOfDiceSums * 10 == 0)
                {
                    Console.Write("·");
                }
                for (var i = 0; i < Math.Abs(nowPercent * numberOfDiceSums * 10) % 100; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        private void Delimiter(string del, int count)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < count; i++)
                Console.Write(del);
            Console.WriteLine();
            Console.ResetColor();
        }

        private void Delimiter2(string del, int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write(del);
        }

    }
}
