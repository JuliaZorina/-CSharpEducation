using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game();
        }
        public enum Player
        {
            X = 0,
            O = 1
        }

        public static void Game()
        {
            string[] gamebox = new string[9];
            Console.WriteLine("Хотите сыграть против другого игрока? [y/n]");
            var playersType = Console.ReadLine();
            
            if (playersType == "y")
            {
                Console.WriteLine("Для того, чтобы выбрать клетку поля, куда вы хотите сходить\nнажмите кнопку с соответствующим числом.");
                TwoPlayersMode(gamebox);
            }
            else if(playersType == "n"){
                Console.WriteLine("Для того, чтобы выбрать клетку поля, куда вы хотите сходить\nнажмите кнопку с соответствующим числом.");
                OnePlayerMode(gamebox);
            }
            else
            {
                Console.WriteLine("Введено некорректное значение.");
                Game();
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
                Game();
            }
            else if(playAgain == "n")
            {
                Console.WriteLine("Выход из игры...");
            }
            else
            {
                Console.WriteLine("Введено некорректное значение.");
                PlayAgain(gamebox);
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
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write($"| {i*3+j+1} |");
                    }
                    else
                    {
                        Console.Write($"| ");
                        if(gamebox[i * 3 + j] == Player.X.ToString())
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
            Console.WriteLine("Вы играете против другого игрока.");
            GameBoxDraw(gamebox);
            var rnd = new Random();
            var player = (Player)(rnd.Next(0,2));

            for (int i=0; i < gamebox.Length; i++)
            {
                
                Console.WriteLine($"Ход {player}: ");
                var move = Console.ReadLine();
                var number = 0;

                if (!int.TryParse(move, out number))
                {
                    Console.Write($"Введено неверное значение!\n");
                    while (number == 0)
                    {
                        Console.WriteLine($"Ход {player}: ");
                        int.TryParse(Console.ReadLine(), out number);
                    }
                }
                PlayerMove(gamebox, player, number);
                
                if (CheckWin(gamebox, player))
                {
                    Console.WriteLine($"Победил игрок {player}!");
                    break;
                }
                else if(i == gamebox.Length - 1)
                {
                    Console.WriteLine($"Игра окончена. Ничья.");
                }
                else
                {
                    if (player == Player.X)
                    {
                        player = Player.O;
                    }
                    else
                    {
                        player = Player.X;
                    }
                }
            }
            PlayAgain(gamebox);
        }

        public static void OnePlayerMode(string[] gamebox)
        {
            var rnd = new Random();
            var player = (Player)(rnd.Next(0,2));
            Console.WriteLine($"Вы играете против бота. Вы играете за {player}.");
            var userPlayer = player;
            GameBoxDraw(gamebox);

            for (int i = 0; i < gamebox.Length; i++)
            {
                Console.WriteLine($"Ход {player}: ");
                if(player == userPlayer)
                {
                    var move = Console.ReadLine();
                    var number = 0;

                    if (!int.TryParse(move, out number))
                    {
                        Console.Write($"Введено неверное значение!\n");
                        while (number == 0)
                        {
                            Console.WriteLine($"Ход {player}: ");
                            int.TryParse(Console.ReadLine(), out number);
                        }
                    }
                    PlayerMove(gamebox, player, number);

                }
                else
                {
                    var move = rnd.Next(1,9);
                    Console.WriteLine(move);
                    BotMove(gamebox, player, move, rnd);
                }
                
                if (CheckWin(gamebox, player))
                {
                    Console.WriteLine($"Победил игрок {player}!");
                    break;
                }
                else if (i == gamebox.Length - 1)
                {
                    Console.WriteLine($"Игра окончена. Ничья.");
                }
                else
                {
                    if (player == Player.X)
                    {
                        player = Player.O;
                    }
                    else
                    {
                        player = Player.X;
                    }
                }

            }
            PlayAgain(gamebox);
        }

        private static void PlayerMove(string[] gamebox, Player player, int number)
        {
            if (number >= 1 && number <= 9)
            {
                while (gamebox[number - 1] != null)         
                {
                    Console.Write($"Клетка уже занята!\n");
                    Console.WriteLine($"Ход {player}: ");
                    int.TryParse(Console.ReadLine(), out number);
                    while (!(number >= 1 && number <= 9))
                    {
                        Console.Write($"Введено неверное значение!\n");
                        Console.WriteLine($"Ход {player}: ");
                        int.TryParse(Console.ReadLine(), out number);
                    }
                }
                if (gamebox[number - 1] == null)
                {
                    gamebox[number - 1] = player.ToString();
                }
                GameBoxDraw(gamebox);
            }
            else
            {
                
                while (!(number >=1&&number<=9))
                {
                    Console.Write($"Введено неверное значение!\n");
                    Console.WriteLine($"Ход {player}: ");
                    int.TryParse(Console.ReadLine(), out number);
                }
                PlayerMove(gamebox, player, number);
            }
        }

        private static void BotMove(string[] gamebox, Player player, int number, Random rnd)
        {
            if (number >= 1 && number <= 9)
            {
                while (gamebox[number - 1] != null)
                {
                    Console.Write($"Клетка уже занята!\n");
                    number = rnd.Next(1, 9);
                    Console.WriteLine($"Ход {player}: {number}");
                }
                if (gamebox[number - 1] == null)
                {
                    gamebox[number - 1] = player.ToString();
                }
                GameBoxDraw(gamebox);
            }
        }

        private static bool CheckWin(string[] gamebox, Player player)
        {
            var winSituations = new int[8][];
            winSituations[0] = new int[] { 0, 1, 2 };
            winSituations[1] = new int[] { 3, 4, 5 };
            winSituations[2] = new int[] { 6, 7, 8 };
            winSituations[3] = new int[] { 0, 3, 6 };
            winSituations[4] = new int[] { 1, 4, 7 };
            winSituations[5] = new int[] { 2, 5, 8 };
            winSituations[6] = new int[] { 0, 4, 8 };
            winSituations[7] = new int[] { 2, 4, 6 };
            var result = false; 

            for(int i=0;i<winSituations.GetLength(0);i++)
            {
                if(
                    (gamebox[winSituations[i][0]] != null)&& (gamebox[winSituations[i][0]].Equals(player.ToString()))
                    && (gamebox[winSituations[i][1]] != null) && (gamebox[winSituations[i][1]].Equals(player.ToString()))
                    && (gamebox[winSituations[i][2]] != null)&&(gamebox[winSituations[i][2]].Equals(player.ToString()))
                    )
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
