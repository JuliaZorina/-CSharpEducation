using System;

namespace Task2
{
  internal class Move
  {
    public static void Player(string[] gamebox, TicTacToe.Player player, int number)
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
          gamebox[number - 1] = player.ToString();

        GameBox.GameBoxDraw(gamebox);
      }
      else
      {
        while (!(number >= 1 && number <= 9))
        {
          Console.Write($"Введено неверное значение!\n");
          Console.WriteLine($"Ход {player}: ");
          int.TryParse(Console.ReadLine(), out number);
        }
        Player(gamebox, player, number);
      }
    }

    public static void Bot(string[] gamebox, TicTacToe.Player player, int number, Random rnd)
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
          gamebox[number - 1] = player.ToString();

        GameBox.GameBoxDraw(gamebox);
      }
    }
  }
}
