using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] gamebox = new string[9];
            Game(gamebox);

        }

        public static void Game(string[] gamebox)
        {
            Console.WriteLine("Хотите сыграть против другого игрока? [y/n]");
            var playersType = Console.ReadLine();
            if (playersType == "y")
            {
                Console.WriteLine("Вы играете против другого игрока. Ход Х: ");
                GameBoxDraw(gamebox);

            }
            else if(playersType == "n"){
                Console.WriteLine("Вы играете против компютера. Вы ходите Х. Ход Х: ");
                GameBoxDraw(gamebox);
            }
            else
            {
                Console.WriteLine("Введено некорректное значение.");
            }
        }
        public static void GameBoxDraw(string[] gamebox)
        {
            Console.WriteLine("---------------");
            for(int i= 0; i < 3; i++)
            {
                for(int j= 0; j < 3; j++)
                {
                    if (gamebox[i * 3 + j] == null)
                    {
                        Console.Write($"| {i*3+j+1} |");
                    }
                    
                }

                Console.WriteLine("\n---------------");

            }
        }
    }
}
