using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game();
        }

        public static void Game()
        {
            string[] gamebox = new string[9];
            Console.WriteLine("Хотите сыграть против другого игрока? [y/n]");
            var playersType = Console.ReadLine();
            Console.WriteLine("Для того, чтобы выбрать клетку поля, куда вы хотите сходить\n нажмите кнопку с соответствующим числом.");
            if (playersType == "y")
            {
                TwoPlayersMode(gamebox);
                Console.WriteLine("Хотите сыграть еще? [y/n]");
                var playAgain = Console.ReadLine();
                if (playAgain == "y")
                {
                    for (int i = 0; i < gamebox.Length; i++)
                    {
                        gamebox[i] = null;
                    }
                }
                else
                    Console.WriteLine("Выход из игры...");

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
                    else
                    {
                        Console.Write($"| {gamebox[i * 3 + j]} |");
                    }
                    
                }

                Console.WriteLine("\n---------------");

            }
        }
        public static void TwoPlayersMode(string[] gamebox)
        {
            string[] players = new string[] { "X", "O" };
            Console.WriteLine("Вы играете против другого игрока.");
            GameBoxDraw(gamebox);
            for(int i=0; i < gamebox.Length; i++)
            {
                    Console.WriteLine($"Ход {players[i%2]}: ");
                    var move = Console.ReadLine();
                    //проверка корректности ввода.
                    //проверка того, что клетка пустая
                    gamebox[int.Parse(move)-1] = players[i%2];
                    //проверка выигрышная ситуация или нет, если нет, то продолжаем играть
                    GameBoxDraw(gamebox);
            }
            
        }
    }
}
