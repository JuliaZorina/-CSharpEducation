using System;

namespace Task2
{
  internal class GameBox
  {
    public static void GameBoxDraw(string[] gamebox)
    {
      Console.WriteLine("---------------");

      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (gamebox[i * 3 + j] == null)
          {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"| {i * 3 + j + 1} |");
          }
          else
          {
            Console.Write($"| ");

            if (gamebox[i * 3 + j] == TicTacToe.Player.X.ToString())
              Console.BackgroundColor = ConsoleColor.Blue;

            else Console.BackgroundColor = ConsoleColor.Red;
            Console.Write($"{gamebox[i * 3 + j]}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($" |");
          }
        }
        Console.WriteLine("\n---------------");
      }
    }
  }
}
