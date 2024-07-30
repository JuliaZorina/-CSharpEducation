using System;

namespace Task2
{
  internal class Mode
  {
    public static Random rnd = new Random();

    public static void TwoPlayers(string[] gamebox)
    {
      var player = (TicTacToe.Player)(rnd.Next(0, 2));

      Console.WriteLine("Вы играете против другого игрока.");
      GameBox.GameBoxDraw(gamebox);

      for (int i = 0; i < gamebox.Length; i++)
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
        Move.Player(gamebox, player, number);

        if (TicTacToe.CheckWinner(gamebox, player))
        {
          Console.WriteLine($"Победил игрок {player}!");
          break;
        }
        else if (i == gamebox.Length - 1)
          Console.WriteLine($"Игра окончена. Ничья.");
        else
        {
          if (player == TicTacToe.Player.X)
            player = TicTacToe.Player.O;
          else
            player = TicTacToe.Player.X;
        }
      }
      TicTacToe.PlayAgain(gamebox);
    }

    public static void OnePlayer(string[] gamebox)
    {
      var player = (TicTacToe.Player)(rnd.Next(0, 2));
      var userPlayer = player;

      Console.WriteLine($"Вы играете против бота. Вы играете за {player}.");
      GameBox.GameBoxDraw(gamebox);

      for (int i = 0; i < gamebox.Length; i++)
      {
        Console.WriteLine($"Ход {player}: ");
        if (player == userPlayer)
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
          Move.Player(gamebox, player, number);
        }
        else
        {
          var move = rnd.Next(1, 9);

          Console.WriteLine(move);
          Move.Bot(gamebox, player, move, rnd);
        }

        if (TicTacToe.CheckWinner(gamebox, player))
        {
          Console.WriteLine($"Победил игрок {player}!");
          break;
        }

        else if (i == gamebox.Length - 1)
          Console.WriteLine($"Игра окончена. Ничья.");

        else
        {
          if (player == TicTacToe.Player.X)
            player = TicTacToe.Player.O;
          else
            player = TicTacToe.Player.X;
        }
      }
      TicTacToe.PlayAgain(gamebox);
    }
  }
}
