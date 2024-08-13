using System;

namespace Task3
{
  internal class Program
  {
    static void Main(string[] args)
    {
      const string path = @"..\..\phonebook.txt";

      Phonebook phonebook = Phonebook.getPhonebook(path);
      

      Menu(phonebook);

    }    
    private static void Menu(Phonebook phonebook)
    {
      var abonent = new Abonent();

      Console.WriteLine("Нажмите 1 для добавления нового контакта.\nНажмите 2 для просмотра уже существующего контакта." +
        "\nНажмите 3 для редактирования уже существующего контакта.\nНажмите 4 для удаления контакта." +
        "\nНажмите 5 для выхода из программы.");
      
      var menu = Console.ReadLine();
      
      switch (menu)
      {
        case "1":
          abonent.CreateAbonent(phonebook.abonent);
          break;
        case "2":
          abonent.ReadAbonent(phonebook.abonent);
          break;
        case "3":
          abonent.UpdateAbonent();
          break;
        case "4":
          abonent.DeleteAbonent();
          break;
        case "5":
          Exit(phonebook);
          break;
        default:
          Console.WriteLine("Введено некорректное значение!");
          Menu(phonebook);
          break;
      }
    }
    
    private static void Exit(Phonebook phonebook)
    {
      Console.WriteLine("Вы действительно хотите выйти из программы? [y/n]");
      var exit = Console.ReadLine();
      if (exit == "y")
      {
        Abonent.AddNewAbonent(phonebook.abonent);
        Console.WriteLine("Выход из программы...");
      }
      else if(exit == "n")
      {
        Menu(phonebook);
      }
      else
      {
        Console.WriteLine("Введено некорректное значение!");
        Exit(phonebook);
      }
    }
  }
}
