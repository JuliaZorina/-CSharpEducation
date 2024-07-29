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
                PlayAgain(gamebox);

            }
            else if(playersType == "n"){
                Console.WriteLine("Вы играете против бота. Вы ходите Х. Ход Х: ");
                GameBoxDraw(gamebox);
            }
            else
            {
                Console.WriteLine("Введено некорректное значение.");
            }
        }

        private static void PlayAgain(string[] gamebox)
        {
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

        public static void GameBoxDraw(string[] gamebox)
        {
            Console.WriteLine("---------------");
            for(int i= 0; i < 3; i++)
            {
                for(int j= 0; j < 3; j++)
                {
                    if (gamebox[i * 3 + j] == null)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write($"| {i*3+j+1} |");
                    }
                    else
                    {
                        Console.Write($"| ");
                        if(gamebox[i * 3 + j] == "X")
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write($"{gamebox[i * 3 + j]}");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write($" |");
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
                var player = players[i % 2];
                Console.WriteLine($"Ход {player}: ");
                var move = Console.ReadLine();
                int number = 0;
                //проверка корректности ввода.
                if (int.TryParse(move, out number))
                {
                    PlayerMove(gamebox, player, number);
                }
                else
                {
                    Console.Write($"Введено неверное значение!\n");
                    while (number == 0)
                    {
                        Console.WriteLine($"Ход {player}: ");
                        int.TryParse(Console.ReadLine(), out number);
                    }
                    PlayerMove(gamebox, player, number);
                }
            }
        }

        private static void PlayerMove(string[] gamebox, string player, int number)
        {
            if (number >= 1 && number <= 9)
            {
                while (gamebox[number - 1] != null)         //проверка того, что клетка пустая
                {
                    Console.Write($"Клетка уже занята!\n");
                    Console.WriteLine($"Ход {player}: ");
                    int.TryParse(Console.ReadLine(), out number);
                    while (!(number >= 1 && number <= 9))
                    {
                        Console.WriteLine($"Ход {player}: ");
                        int.TryParse(Console.ReadLine(), out number);
                    }
                }
                if (gamebox[number - 1] == null)
                {
                    gamebox[number - 1] = player;
                }
                //проверка выигрышная ситуация или нет, если нет, то продолжаем играть
                GameBoxDraw(gamebox);
                if (CheckWin(gamebox, player))
                {
                    Console.WriteLine($"Победил игрок {player}!");
                    //PlayAgain(gamebox);
                }
            }
            else
            {
                Console.Write($"Введено неверное значение!\n");
                while (!(number >=1&&number<=9))
                {
                    Console.WriteLine($"Ход {player}: ");
                    int.TryParse(Console.ReadLine(), out number);
                }
                PlayerMove(gamebox, player, number);
            }
        }

        private static bool CheckWin(string[] gamebox, string player)
        {
            var winSituations = new int[8][];
            winSituations[0] = new int[] { 0, 1, 2 };
            winSituations[1] = new int[] { 3, 4, 5 };
            winSituations[2] = new int[] { 6, 7, 8 };
            winSituations[3] = new int[] { 0, 3, 7 };
            winSituations[4] = new int[] { 2, 5, 8 };
            winSituations[5] = new int[] { 3, 6, 9 };
            winSituations[6] = new int[] { 0, 4, 8 };
            winSituations[7] = new int[] { 2, 4, 6 };
            var result = false; 

            for(int i=0;i<winSituations.GetLength(0);i++)
            {
                if(
                    (gamebox[winSituations[i][0]] != null)&& (gamebox[winSituations[i][0]].Equals(player))
                    && (gamebox[winSituations[i][1]] != null) && (gamebox[winSituations[i][1]].Equals(player))
                    && (gamebox[winSituations[i][2]] != null)&&(gamebox[winSituations[i][2]].Equals(player))
                    )
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
