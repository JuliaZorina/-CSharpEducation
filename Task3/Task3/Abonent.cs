using System;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
  class Abonent
  {
    private long phoneNumber;

    public long PhoneNumber
    {
      get 
      { 
        return this.phoneNumber; 
      }
      set
      {
        this.phoneNumber = value;
      }
    }

    private string name;

    public string Name
    {
      get
      {
        return this.name;
      }
      set
      {
        if (string.IsNullOrEmpty(value))
        {
          throw new ArgumentException("Имя не может быть пустой строкой!");
        }
        else
        {
          this.name = value;
        }        
      }
    }
    /// <summary>
    /// Метод для добавления нового абонента в телефонную книгу при помощи считывания строк из консоли.
    /// </summary>
    /// <param name="abonent"></param>
    public void CreateAbonent(List<Abonent> abonent, string path)//Должен добавлять в List<Abonent> нового абонента.
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

        Console.WriteLine("Введите имя абонента");
        abonentInfo.Name = Console.ReadLine();

        foundAbonents = abonent.FindAll(a => a.PhoneNumber == long.Parse(number));

        if (foundAbonents.Count == 0)
        {
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
        Console.WriteLine("Произошла ошибка при добавлении нового абонента в телефонную книгу. Попытайтесь еще раз.");
      }
      finally
      {
        Phonebook.Menu(abonent);
      }
    }
    /// <summary>
    /// Метод для добавления абонента, когда значение параметра PhoneNumber уже было введено ранее при поиске, 
    /// а имя необходимо считать из консоли.
    /// </summary>
    /// <param name="abonent"></param>
    /// <param name="phoneNumber"></param>
    public void CreateAbonent(List<Abonent> abonent, long phoneNumber, string path)//Должен добавлять в List<Abonent> нового абонента.
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
        Console.WriteLine("Произошла ошибка при добавлении нового абонента в телефонную книгу. Попытайтесь еще раз.");
      }
      finally
      {
        Phonebook.Menu(abonent);
      }
    }
    /// <summary>
    /// Метод для добавления абонента, когда значение параметра Name уже было введено ранее при поиске, 
    /// а номер телефона необходимо считать из консоли.
    /// </summary>
    /// <param name="abonent"></param>
    /// <param name="phoneNumber"></param>
    public void CreateAbonent(List<Abonent> abonent, string name, string path)//Должен добавлять в List<Abonent> нового абонента.
    {
      var abonentInfo = new Abonent();
      var foundAbonents = new List<Abonent>();

      try
      {
        Console.WriteLine("Введите номер телефона");

        var number = Console.ReadLine();

        if (string.IsNullOrEmpty(number))
        {
          throw new ArgumentException("Номер телефона не может быть пустрой строкой!");
        }
        else
          abonentInfo.PhoneNumber = long.Parse(number);

        abonentInfo.Name = name;
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
      }
      catch
      {
        Console.WriteLine("Произошла ошибка при добавлении нового абонента в телефонную книгу. Попытайтесь еще раз.");
      }
      finally
      {
        Phonebook.Menu(abonent);
      }
    }

    public void ReadAbonent(List<Abonent> abonent, string path)
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
          break;
      }
    }
    
    private void FindByNumber(List<Abonent> abonent, string path)
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
        else if(addNew == "n")
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

    private void FindByName(List<Abonent> abonent, string path)
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

    public void ReadAbonent(List<Abonent> abonent)
    {
      Console.WriteLine($"Нажмите клавишу 'и', чтобы найти абонента по имени.\n" +
        $"Нажмите клавишу 'н', чтобы найти абонента по номеру телефона.");

      var searchMethod = (Console.ReadLine()).ToLower();

      switch (searchMethod)
      {
        case "и":
          FindByName(abonent);
          //Phonebook.Menu(abonent);
          break;
        case "н":
          FindByNumber(abonent);
          //Phonebook.Menu(abonent);
          break;
        default:
          Console.WriteLine("Введено недопустимое значение");
          break;
      }
    }

    private void FindByNumber(List<Abonent> abonent)
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
    }

    private List<Abonent> FindByName(List<Abonent> abonent)
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
    /*Для методов UpdateAbonent и DeleteAbonent когда будет осуществляться поиск по имени и будет несколько абонентов
     * с таким именем нужно после вывода всех абонентов запускать поиск по номеру и редактировать/удалять уже этот элемент.
     * В List<Abonent> находить индекс экземпляра класса с введенным значением PhoneNumber.
     * Обновить эти значения в тектовом файле.
     */
    public void UpdateAbonent(List<Abonent> abonent)//Должен обновлять данные абонента по номеру телефона или по имени абонента.
    {
      //ReadAbonent(abonent);
      Console.WriteLine($"Нажмите клавишу 'и', чтобы найти абонента по имени.\n" +
        $"Нажмите клавишу 'н', чтобы найти абонента по номеру телефона.");

      var searchMethod = (Console.ReadLine()).ToLower();
      var foundAbonents = new List<Abonent>();
      long updateNumber = 0; 

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
                UpdateAbonent(abonent);
              } 
              else
              {
                updateNumber = long.Parse(number);
                //после ввода номера вызвать метод, который обновит данные в листе и затем перепишет данные в файле
                //и после успешного обновления данных возврат в меню
                Phonebook.Menu(abonent);
              }
            }
          }
          else if(foundAbonents.Count == 1)
          {
            //после ввода номера вызвать метод, который обновит данные в листе и затем перепишет данные в файле
            //foundAbonents[0].PhoneNumber отправить в этот метод
          }
          else
          {
            Phonebook.Menu(abonent);
          }
          break;
        case "н":
          FindByNumber(abonent);
          //Phonebook.Menu(abonent);
          break;
        default:
          Console.WriteLine("Введено недопустимое значение");
          Phonebook.Menu(abonent);
          break;
      }
    }

    public void DeleteAbonent(List<Abonent> abonent)//Удалить всю информацию об абоненте.
    {
      ReadAbonent(abonent);
    }
  }
}
