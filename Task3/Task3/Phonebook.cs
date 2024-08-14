using System;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
  class Phonebook
  {
    private static Phonebook phonebook;

    public string Path { get; private set; }

    private Phonebook(string path) 
    { 
      this.Path = path;
    }

    public static Phonebook getPhonebook(string path)
    {
      if(phonebook==null)
        phonebook = new Phonebook(path);//Вызывает приватный конструктор. 
      GetAbonents(GetFileInfo(phonebook.Path));
      return phonebook;
    }

    public List<Abonent> abonent = new List<Abonent>();
    
    /// <summary>
    /// Метод принимает путь к файлу с телефонной книгой и преобразует его в коллекцию строк.
    /// </summary>
    /// <param name="path"></param>
    /// <returns>Коллекция строк из считанного файла.</returns>
    private static List<string> GetFileInfo(string path)
    {
      FileInfo file = new FileInfo(path);

      if (!file.Exists)
        file.Create();

      var abonentsStrings = new List<string>();

      using (StreamReader sr = new StreamReader(path))
      {
        string line;

        while ((line = sr.ReadLine()) != null)
          abonentsStrings.Add(line);
      }
      return abonentsStrings;
    }

    /// <summary>
    /// Преобразует коллекцию строк в коллекцию экземпляров класса Abonent.
    /// </summary>
    /// <param name="abonentsStrings"></param>
    /// <returns></returns>
    private static void GetAbonents(List<string> abonentsStrings)
    {
      foreach (var str in abonentsStrings)
      {
        var abonentInfo = str.Split(' ');
        var abonent = new Abonent();
        abonent.PhoneNumber = long.Parse(abonentInfo[0]);
        abonent.Name = abonentInfo[1];
        phonebook.abonent.Add(abonent);
      }
    }

    public static void Menu(List<Abonent> abonent)
    {
      var abonentInfo = new Abonent();

      Console.WriteLine("Нажмите 1 для добавления нового контакта.\n" +
        "Нажмите 2 для просмотра уже существующего контакта.\n" +
        "Нажмите 3 для редактирования уже существующего контакта.\n" +
        "Нажмите 4 для удаления контакта.\n" +
        "Нажмите 5 для выхода из программы.");

      var menu = Console.ReadLine();

      switch (menu)
      {
        case "1":
          abonentInfo.CreateAbonent(abonent, phonebook.Path);
          break;
        case "2":
          abonentInfo.ReadAbonent(abonent, phonebook.Path);
          break;
        case "3":
          abonentInfo.UpdateAbonent(abonent, phonebook.Path);
          break;
        case "4":
          abonentInfo.DeleteAbonent(abonent, phonebook.Path);
          break;
        case "5":
          Exit(abonent);
          break;
        default:
          Console.WriteLine("Введено некорректное значение!");
          Menu(abonent);
          break;
      }
    }

    private static void Exit(List<Abonent> abonent)
    {
      Console.WriteLine("Вы действительно хотите выйти из программы? [y/n]");
      var exit = Console.ReadLine();
      if (exit == "y")
        Console.WriteLine("Выход из программы...");
      else if (exit == "n")
        Menu(abonent);
      else
      {
        Console.WriteLine("Введено некорректное значение!");
        Exit(abonent);
      }
    }
  }
}
