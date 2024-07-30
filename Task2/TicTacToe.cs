using System;

namespace Task2
{
  internal class TicTacToe
  {
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
        Console.WriteLine("Для того, чтобы выбрать клетку поля, куда вы хотите сходить\n" +
          "нажмите кнопку с соответствующим числом.");
        Mode.TwoPlayers(gamebox);
      }
      else if (playersType == "n")
      {
        Console.WriteLine("Для того, чтобы выбрать клетку поля, куда вы хотите сходить\n" +
          "нажмите кнопку с соответствующим числом.");
        Mode.OnePlayer(gamebox);
      }
      else
      {
        Console.WriteLine("Введено некорректное значение.");
        Game();
      }
    }

    public static void PlayAgain(string[] gamebox)
    {
      Console.WriteLine("Хотите сыграть еще? [y/n]");

      var playAgain = Console.ReadLine();

      if (playAgain == "y")
      {
        for (int i = 0; i < gamebox.Length; i++)
          gamebox[i] = null;

        Game();
      }
      else if (playAgain == "n")
        Console.WriteLine("Выход из игры...");
      else
      {
        Console.WriteLine("Введено некорректное значение.");
        PlayAgain(gamebox);
      }
    }

    public static bool CheckWinner(string[] gamebox, Player player)
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

      for (int i = 0; i < winSituations.GetLength(0); i++)
      {
        if ((gamebox[winSituations[i][0]] != null) && (gamebox[winSituations[i][0]].Equals(player.ToString()))
            && (gamebox[winSituations[i][1]] != null) && (gamebox[winSituations[i][1]].Equals(player.ToString()))
            && (gamebox[winSituations[i][2]] != null) && (gamebox[winSituations[i][2]].Equals(player.ToString())))
        {
          result = true;
        }
      }
      return result;
    }
  }
}
