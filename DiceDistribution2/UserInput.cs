using System;
using System.Collections.Generic;

namespace DiceDistribution2
{
    internal class UserInput
    {
        private InputData input;
        public InputData Input
        {
            get { return input; }
            set
            {
                input = value;
            }


        }

        public bool InputMode()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите \"1\" для режима одинаковых игральных костей.");
            Console.WriteLine("Введите \"2\" для режима различных игральных костей.");
            Console.ResetColor();

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int x) && (x == 1 || x == 2))
                {
                    if (x == 1)
                        return true;
                    if (x == 2)
                        return false;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введено некорректное значение!");
                Console.ResetColor();
            }
        }

        public List<Dice> IdenticalDice()
        {
            var resultList = new List<Dice>();

            int quantity;
            int faces;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите количество игральных костей (от двух).");
            Console.ResetColor();

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out quantity) && quantity >= 2)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введено некорректное значение!");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите количество граней (от двух).");
            Console.ResetColor();

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out faces) && faces >= 2)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введено некорректное значение!");
                Console.ResetColor();
            }

            Input = new InputData(quantity, faces);

            for (int i = 0; i < quantity; i++)
            {
                resultList.Add(new Dice(Input));
            }

            return resultList;
        }

        public List<Dice> DissimilarDice()
        {
            var resultList = new List<Dice>();

            int faces;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Вводитие количество граней для каждой игральной кости последовательно.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Для выхода введите число \"1\"");
            Console.ResetColor();
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out faces) && faces >= 2)
                {
                    resultList.Add(new Dice(faces));
                    Console.WriteLine($"Количество введенных игральных костей:\t{resultList.Count}");
                }
                else
                {
                    if (faces == 1 && resultList.Count >= 2) // тут тоже не знаю как лучше спроектировать
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введено некорректное значение или недостаточно введенных данных!");
                        Console.ResetColor();
                    }
                }

            }

            return resultList;
        }
    }
}
