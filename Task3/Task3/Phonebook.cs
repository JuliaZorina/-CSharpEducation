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
      GetAbonents(ReadAbonentsFromFile(phonebook.Path));//Это переделать.
      return phonebook;
    }

    public List<Abonent> abonent = new List<Abonent>();
    
    /// <summary>
    /// Получить список абонентов из файла.
    /// </summary>
    /// <param name="path"></param>
    /// <returns>Коллекция строк из считанного файла.</returns>
    private static List<string> ReadAbonentsFromFile(string path)
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
    /// Преобразует коллекцию строк в коллекцию экземпляров структуры Abonent.
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
      Console.WriteLine("Нажмите 1 для добавления нового контакта.\n" +
        "Нажмите 2 для просмотра уже существующего контакта.\n" +
        "Нажмите 3 для редактирования уже существующего контакта.\n" +
        "Нажмите 4 для удаления контакта.\n" +
        "Нажмите 5 для выхода из программы.");

      var menu = Console.ReadLine();

      switch (menu)
      {
        case "1":
          CreateAbonent(abonent, phonebook.Path);
          break;
        case "2":
          ReadAbonent(abonent, phonebook.Path);
          break;
        case "3":
          UpdateAbonent(abonent, phonebook.Path);
          break;
        case "4":
          DeleteAbonent(abonent, phonebook.Path);
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

    public static void CreateAbonent(List<Abonent> abonent, string path)
    {
      var abonentInfo = new Abonent();
      var foundAbonents = new List<Abonent>();

      try
      {
        Console.WriteLine("Введите номер телефона");

        var number = Console.ReadLine();

        if (string.IsNullOrEmpty(number))
          throw new ArgumentException("Номер телефона не может быть пустрой строкой!");
        else
          abonentInfo.PhoneNumber = long.Parse(number);
        foundAbonents = abonent.FindAll(a => a.PhoneNumber == long.Parse(number));

        if (foundAbonents.Count == 0)
        {
          Console.WriteLine("Введите имя абонента");
          abonentInfo.Name = Console.ReadLine();

          abonent.Add(abonentInfo);
          using (StreamWriter sw = File.AppendText(path))
          {
            sw.WriteLine($"{abonentInfo.PhoneNumber} {abonentInfo.Name}");
          }
          Console.WriteLine($"Абонент '{abonentInfo.Name}' {abonentInfo.PhoneNumber} успешно добавлен в телефонную книгу.");
        }
        else
          throw new Exception("Абонент с таким номером уже существует!");
        Phonebook.Menu(abonent);
      }
      catch
      {
        Console.WriteLine("Произошла ошибка при добавлении нового абонента в телефонную книгу. Повторите попытку позднее.");
      }
      finally
      {
        Phonebook.Menu(abonent);
      }
    }
    /// <summary>
    /// Создать нового абонента, когда значение параметра PhoneNumber уже было введено ранее при поиске, 
    /// а имя необходимо считать из консоли.
    /// </summary>
    /// <param name="abonent"></param>
    /// <param name="phoneNumber"></param>
    public static void CreateAbonent(List<Abonent> abonent, long phoneNumber, string path)
    {
      var abonentInfo = new Abonent();
      var foundAbonents = new List<Abonent>();

      try
      {
        abonentInfo.PhoneNumber = phoneNumber;

        Console.WriteLine("Введите имя абонента");

        abonentInfo.Name = Console.ReadLine();
        foundAbonents = abonent.FindAll(a => a.PhoneNumber == phoneNumber);

        if (foundAbonents.Count == 0)
        {
          abonent.Add(abonentInfo);
          using (StreamWriter sw = File.AppendText(path))
          {
            sw.WriteLine($"{abonentInfo.PhoneNumber} {abonentInfo.Name}");
          }
        }
        else
          throw new Exception("Абонент с таким номером уже существует!");
        Phonebook.Menu(abonent);
      }
      catch
      {
        Console.WriteLine("Произошла ошибка при добавлении нового абонента в телефонную книгу. Повторите попытку позднее.");
      }
      finally
      {
        Phonebook.Menu(abonent);
      }
    }
    /// <summary>
    /// Создать абонента, когда значение параметра Name уже было введено ранее при поиске, 
    /// а номер телефона необходимо считать из консоли.
    /// </summary>
    /// <param name="abonent"></param>
    /// <param name="phoneNumber"></param>
    public static void CreateAbonent(List<Abonent> abonent, string name, string path)
    {
      var abonentInfo = new Abonent();
      var foundAbonents = new List<Abonent>();

      try
      {
        Console.WriteLine("Введите номер телефона");

        var number = Console.ReadLine();

        if (string.IsNullOrEmpty(number))
          throw new ArgumentException("Номер телефона не может быть пустрой строкой!");
        else
          abonentInfo.PhoneNumber = long.Parse(number);

        abonentInfo.Name = name;
        foundAbonents = abonent.FindAll(a => a.PhoneNumber == abonentInfo.PhoneNumber);

        if (foundAbonents.Count == 0)
        {
          abonent.Add(abonentInfo);
          using (StreamWriter sw = File.AppendText(path))
          {
            sw.WriteLine($"{abonentInfo.PhoneNumber} {abonentInfo.Name}");
          }
        }
        else
          throw new Exception("Абонент с таким номером уже существует!");
      }
      catch
      {
        Console.WriteLine("Произошла ошибка при добавлении нового абонента в телефонную книгу. Повторите попытку позднее.");
      }
      finally
      {
        Phonebook.Menu(abonent);
      }
    }

    public static void ReadAbonent(List<Abonent> abonent, string path)
    {
      try
      {
        Console.WriteLine($"Нажмите клавишу 'и', чтобы найти абонента по имени.\n" +
        $"Нажмите клавишу 'н', чтобы найти абонента по номеру телефона.");

        var searchMethod = (Console.ReadLine()).ToLower();

        switch (searchMethod)
        {
          case "и":
            FindByName(abonent, path);
            Phonebook.Menu(abonent);
            break;
          case "н":
            FindByNumber(abonent, path);
            Phonebook.Menu(abonent);
            break;
          default:
            Console.WriteLine("Введено недопустимое значение");
            Phonebook.Menu(abonent);
            break;
        }
      }
      catch
      {
        Console.WriteLine("Поиск абонента был произведен с ошибкой. Повторите попытку позднее.");
        Phonebook.Menu(abonent);
      }
    }
    /// <summary>
    /// Найти экземпляр структуры Abonent по значению параметра PhoneNumber.
    /// </summary>
    /// <param name="abonent"></param>
    /// <param name="path"></param>
    /// <exception cref="ArgumentException"></exception>
    private static void FindByNumber(List<Abonent> abonent, string path)
    {
      var foundAbonents = new List<Abonent>();

      Console.WriteLine("Введите номер абонента для поиска.");

      var number = Console.ReadLine();

      if (string.IsNullOrEmpty(number))
        throw new ArgumentException("Номер телефона не может быть пустрой строкой!");
      else
        foundAbonents = abonent.FindAll(a => a.PhoneNumber == long.Parse(number));

      if (foundAbonents.Count == 0)
      {
        Console.WriteLine($"Абонент с номером {number} не существует в телефонной книге. Добавить нового абонента? [y/n]");
        var addNew = Console.ReadLine();
        if (addNew == "y")
          CreateAbonent(abonent, long.Parse(number), path);
        else if (addNew == "n")
          Phonebook.Menu(abonent);
        else
          Console.WriteLine("Было введено некорректное значение.");
      }
      else
      {
        foreach (var foundAbonent in foundAbonents)
          Console.WriteLine($"{foundAbonent.Name} {foundAbonent.PhoneNumber}");
      }
    }
    /// <summary>
    /// Найти экземпляр структуры Abonent по значению параметра Name.
    /// </summary>
    /// <param name="abonent"></param>
    /// <param name="path"></param>
    private static void FindByName(List<Abonent> abonent, string path)
    {
      Console.WriteLine("Введите имя абонента для поиска.");

      var name = Console.ReadLine();
      var foundAbonents = abonent.FindAll(a => a.Name == name);

      if (foundAbonents.Count == 0)
      {
        Console.WriteLine($"Абонент с именем {name} не существует в телефонной книге. Добавить нового абонента? [y/n]");

        var addNew = Console.ReadLine();

        if (addNew == "y")
          CreateAbonent(abonent, name, path);
        else if (addNew == "n")
          Phonebook.Menu(abonent);
        else
          Console.WriteLine("Было введено некорректное значение.");
      }
      else
      {
        foreach (var foundAbonent in foundAbonents)
          Console.WriteLine($"{foundAbonent.Name} {foundAbonent.PhoneNumber}");
      }
    }
    /// <summary>
    /// Найти экземпляр структуры Abonent по значению параметра PhoneNumber.
    /// </summary>
    /// <param name="abonent"></param>
    /// <returns>Коллекция экземпляров структуры Abonent, соответсвующих условиям поиска.</returns>
    /// <exception cref="ArgumentException"></exception>
    private static List<Abonent> FindByNumber(List<Abonent> abonent)
    {
      var foundAbonents = new List<Abonent>();
      Console.WriteLine("Введите номер абонента для поиска.");
      var number = Console.ReadLine();
      if (string.IsNullOrEmpty(number))
        throw new ArgumentException("Номер телефона не может быть пустрой строкой!");
      else
        foundAbonents = abonent.FindAll(a => a.PhoneNumber == long.Parse(number));

      if (foundAbonents.Count == 0)
        Console.WriteLine($"Абонент с номером {number} не существует в телефонной книге. ");
      else
      {
        foreach (var foundAbonent in foundAbonents)
          Console.WriteLine($"{foundAbonent.Name} {foundAbonent.PhoneNumber}");
      }
      return foundAbonents;
    }
    /// <summary>
    /// Найти экземпляр структуры Abonent по значению параметра Name.
    /// </summary>
    /// <param name="abonent"></param>
    /// <returns>Коллекция экземпляров структуры Abonent, соответсвующих условиям поиска.</returns>
    private static List<Abonent> FindByName(List<Abonent> abonent)
    {
      Console.WriteLine("Введите имя абонента для поиска.");

      var name = Console.ReadLine();
      var foundAbonents = abonent.FindAll(a => a.Name == name);

      if (foundAbonents.Count == 0)
        Console.WriteLine($"Абонент с именем {name} не существует в телефонной книге.");
      else
      {
        foreach (var foundAbonent in foundAbonents)
          Console.WriteLine($"{foundAbonent.Name} {foundAbonent.PhoneNumber}");
      }
      return foundAbonents;
    }

    public static void UpdateAbonent(List<Abonent> abonent, string path)
    {
      Console.WriteLine($"Нажмите клавишу 'и', чтобы найти абонента по имени.\n" +
        $"Нажмите клавишу 'н', чтобы найти абонента по номеру телефона.");
      try
      {
        var searchMethod = (Console.ReadLine()).ToLower();
        var foundAbonents = new List<Abonent>();

        switch (searchMethod)
        {
          case "и":
            foundAbonents = FindByName(abonent);
            if (foundAbonents.Count > 1)
            {
              Console.WriteLine("Введите номер абонента, данные которого вы хотите обновить");
              var number = Console.ReadLine();

              if (string.IsNullOrEmpty(number))
                throw new ArgumentException("Номер телефона не может быть пустрой строкой!");
              else
              {
                if (!abonent.Exists(a => a.PhoneNumber == long.Parse(number)))
                {
                  Console.WriteLine("Абонента с таким номером не существует в телефонной книге");
                  UpdateAbonent(abonent, path);
                }
                else
                {
                  Console.WriteLine("Абонент найден");
                  UpdateAbonentInfo(abonent, path, long.Parse(number));
                  Phonebook.Menu(abonent);
                }
              }
            }
            else if (foundAbonents.Count == 1)
            {
              Console.WriteLine("Абонент найден");
              UpdateAbonentInfo(abonent, path, foundAbonents[0].PhoneNumber);
              Phonebook.Menu(abonent);
            }
            else
              Phonebook.Menu(abonent);
            break;
          case "н":
            foundAbonents = FindByNumber(abonent);

            if (foundAbonents.Count == 1)
            {
              Console.WriteLine("Абонент найден");
              UpdateAbonentInfo(abonent, path, foundAbonents[0].PhoneNumber);
              Phonebook.Menu(abonent);
            }
            else
              Phonebook.Menu(abonent);
            break;
          default:
            Console.WriteLine("Введено недопустимое значение");
            Phonebook.Menu(abonent);
            break;
        }
      }
      catch
      {
        Console.WriteLine("Редактирование данных об абоненте было выполнено с ошибкой");
        Phonebook.Menu(abonent);
      }
    }
    /// <summary>
    /// Обновить данные о экземпляре структуры Abonent и обновить содержимое файла phonebook.txt.
    /// </summary>
    /// <param name="abonent"></param>
    /// <param name="path"></param>
    /// <param name="updateNumber"></param>
    /// <exception cref="ArgumentException"></exception>
    private static void UpdateAbonentInfo(List<Abonent> abonent, string path, long updateNumber)
    {
      var index = abonent.IndexOf(abonent.Find(a => a.PhoneNumber == updateNumber));
      Console.WriteLine("Введите новое значение имени");

      Abonent updAbonent = abonent[index];
      updAbonent.Name = Console.ReadLine();
      if (string.IsNullOrEmpty(abonent[index].Name))
        throw new ArgumentException("Имя не может быть пустой строкой!");
      else
      {
        Console.WriteLine("Введите новое значение для номера телефона");
        var number = Console.ReadLine();
        if (string.IsNullOrEmpty(number))
          throw new ArgumentException("Номер телефона не может быть пустрой строкой!");
        {
          updAbonent.PhoneNumber = long.Parse(number);

          using (StreamWriter sw = File.CreateText(path))
          {
            foreach (var abonentInfo in abonent)
              sw.WriteLine($"{abonentInfo.PhoneNumber} {abonentInfo.Name}");
          }
          Console.WriteLine($"Данные о пользователе с именем {abonent[index].Name} и номером телефона {abonent[index].PhoneNumber} " +
            $"успешно обновлены");
        }
      }
    }

    public static void DeleteAbonent(List<Abonent> abonent, string path)//Удалить всю информацию об абоненте.
    {
      Console.WriteLine($"Нажмите клавишу 'и', чтобы найти абонента по имени.\n" +
        $"Нажмите клавишу 'н', чтобы найти абонента по номеру телефона.");
      try
      {

        var searchMethod = (Console.ReadLine()).ToLower();
        var foundAbonents = new List<Abonent>();

        switch (searchMethod)
        {
          case "и":
            foundAbonents = FindByName(abonent);
            if (foundAbonents.Count > 1)
            {
              Console.WriteLine("Введите номер абонента, данные которого вы хотите удалить");
              var number = Console.ReadLine();
              if (string.IsNullOrEmpty(number))
                throw new ArgumentException("Номер телефона не может быть пустрой строкой!");
              else
              {
                if (!abonent.Exists(a => a.PhoneNumber == long.Parse(number)))
                {
                  Console.WriteLine("Абонента с таким номером не существует в телефонной книге");
                  DeleteAbonent(abonent, path);
                }
                else
                {
                  Console.WriteLine("Абонент найден");
                  DeleteAbonentInfo(abonent, path, long.Parse(number));
                  Phonebook.Menu(abonent);
                }
              }
            }
            else if (foundAbonents.Count == 1)
            {
              Console.WriteLine("Абонент найден");
              DeleteAbonentInfo(abonent, path, foundAbonents[0].PhoneNumber);
              Phonebook.Menu(abonent);
            }
            else
              Phonebook.Menu(abonent);
            break;
          case "н":
            foundAbonents = FindByNumber(abonent);
            if (foundAbonents.Count == 1)
            {
              Console.WriteLine("Абонент найден");
              DeleteAbonentInfo(abonent, path, foundAbonents[0].PhoneNumber);
              Phonebook.Menu(abonent);
            }
            else
              Phonebook.Menu(abonent);
            break;
          default:
            Console.WriteLine("Введено недопустимое значение");
            Phonebook.Menu(abonent);
            break;
        }
      }
      catch
      {
        Console.WriteLine("Удаление абонента было выполнено с ошибкой. Повторите попытку позднее");
        Phonebook.Menu(abonent);
      }
    }
    /// <summary>
    /// Удалить из коллекции экземпляр структуры Abonent и обновить содержимое файла phonebook.txt
    /// </summary>
    /// <param name="abonent"></param>
    /// <param name="path"></param>
    /// <param name="deleteNumber"></param>
    private static void DeleteAbonentInfo(List<Abonent> abonent, string path, long deleteNumber)
    {
      var index = abonent.IndexOf(abonent.Find(a => a.PhoneNumber == deleteNumber));

      Console.WriteLine($"Вы действительно хотите удалить абонента с именем {abonent[index].PhoneNumber} с номером {deleteNumber}? [y/n]");
      if (Console.ReadLine() == "y")
      {
        abonent.RemoveAt(index);

        using (StreamWriter sw = File.CreateText(path))
        {
          foreach (var abonentInfo in abonent)
            sw.WriteLine($"{abonentInfo.PhoneNumber} {abonentInfo.Name}");
        }
        Console.WriteLine($"Данные о пользователе с номером телефона {deleteNumber} были удалены");
      }
      else if (Console.ReadLine() == "n")
        Phonebook.Menu(abonent);
      else
      {
        Console.WriteLine("Было введено некорректное значение");
        DeleteAbonentInfo(abonent, path, deleteNumber);
      }
    }
  }
}
