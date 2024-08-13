using System;
using System.Collections.Generic;

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
    public void CreateAbonent(List<Abonent> abonent)//Должен добавлять в List<Abonent> нового абонента.
    {
      var abonentInfo = new Abonent();
      try
      {
        Console.WriteLine("Введите номер телефона");
        var number = Console.ReadLine();
        if (!string.IsNullOrEmpty(number))
        {
          throw new ArgumentException("Номер телефона не может быть пустрой строкой!");
        }
        else
          abonentInfo.PhoneNumber = long.Parse(number);
        Console.WriteLine("Введите имя абонента");
        abonentInfo.Name = Console.ReadLine();
        //Добавить проверку на то, существует такой абонент уже или нет (проверка по номеру телефона)
        abonent.Add(abonentInfo);
      }
      catch
      {
        Console.WriteLine("Произошла ошибка при добавлении нового абонента в телефонную книгу. Попытайтесь еще раз.");
      }
    }
    /// <summary>
    /// Метод для добавления абонента, когда значение параметра PhoneNumber уже было введено ранее при поиске, 
    /// а имя необходимо считать из консоли.
    /// </summary>
    /// <param name="abonent"></param>
    /// <param name="phoneNumber"></param>
    public void CreateAbonent(List<Abonent> abonent, long phoneNumber)//Должен добавлять в List<Abonent> нового абонента.
    {
      var abonentInfo = new Abonent();
      try
      {
        abonentInfo.PhoneNumber = phoneNumber;
        Console.WriteLine("Введите имя абонента");
        abonentInfo.Name = Console.ReadLine();
        //Добавить проверку на то, существует такой абонент уже или нет (проверка по номеру телефона)
        abonent.Add(abonentInfo);
      }
      catch
      {
        Console.WriteLine("Произошла ошибка при добавлении нового абонента в телефонную книгу. Попытайтесь еще раз.");
      }
    }
    /// <summary>
    /// Метод для добавления абонента, когда значение параметра Name уже было введено ранее при поиске, 
    /// а номер телефона необходимо считать из консоли.
    /// </summary>
    /// <param name="abonent"></param>
    /// <param name="phoneNumber"></param>
    public void CreateAbonent(List<Abonent> abonent, string name)//Должен добавлять в List<Abonent> нового абонента.
    {
      var abonentInfo = new Abonent();
      try
      {
        Console.WriteLine("Введите номер телефона");
        var number = Console.ReadLine();
        if (!string.IsNullOrEmpty(number))
        {
          throw new ArgumentException("Номер телефона не может быть пустрой строкой!");
        }
        else
          abonentInfo.PhoneNumber = long.Parse(number);
        abonentInfo.Name = name;
        //Добавить проверку на то, существует такой абонент уже или нет (проверка по номеру телефона)
        abonent.Add(abonentInfo);
        //выводить уведомление о том, что абонент был добавлен в телефонную книгу
      }
      catch
      {
        Console.WriteLine("Произошла ошибка при добавлении нового абонента в телефонную книгу. Попытайтесь еще раз.");
      }
    }

    public static void AddNewAbonent(List<Abonent> abonent)
    {
      //Проверить есть ли новые абоненты и если есть, то добавить их
    }

    public void ReadAbonent(List<Abonent> abonent)//Должен находить абонента по номеру телефона или номер телефона по имени абонента.
    {
      Console.WriteLine($"Нажмите клавишу 'и', чтобы найти абонента по имени.\n" +
        $"Нажмите клавишу 'н', чтобы найти абонента по номеру телефона.");
      var searchMethod = (Console.ReadLine()).ToLower();
      switch (searchMethod)
      {
        case "и":
          FindByName(abonent);
          Phonebook.Menu(abonent);
          break;
        case "н":
          FindByNumber(abonent);
          break;
        default:
          Console.WriteLine("Введено недопустимое значение");
          break;
      }
    }

    private void FindByNumber(List<Abonent> abonent)
    {
      //нужно по имени/номеру найти индекс листа и вывести номер/имя соответственно
      var foundAbonents = new List<Abonent>();
      Console.WriteLine("Введите номер абонента для поиска.");
      var number = Console.ReadLine();
      if (!string.IsNullOrEmpty(number))
      {
        throw new ArgumentException("Номер телефона не может быть пустрой строкой!");
      }
      else
      {
        foundAbonents = abonent.FindAll(a => a.PhoneNumber == long.Parse(number));
      }
        
      if (foundAbonents.Count == 0)
      {
        Console.WriteLine($"Абонент с номером {number} не существует в телефонной книге. Добавить нового абонента? [y/n]");
        var addNew = Console.ReadLine();
        if (addNew == "y")
        {

        }
        else if(addNew == "n")
        {

        }
        else
        {
          Console.WriteLine("Было введено некорректное значение.");
        }
      }
        
      foreach(var foundAbonent in foundAbonents)
      {
        Console.WriteLine($"{foundAbonent.Name} {foundAbonent.PhoneNumber}");
      }
    }
    private void FindByName(List<Abonent> abonent)
    {
      //нужно по имени/номеру найти индекс листа и вывести номер/имя соответственно
      Console.WriteLine("Введите имя абонента для поиска.");
      var name = Console.ReadLine();
      var foundAbonents = abonent.FindAll(a => a.Name == name);
      if (foundAbonents.Count == 0)
      {
        Console.WriteLine($"Абонент с именем {name} не существует в телефонной книге. Добавить нового абонента? [y/n]");
        var addNew = Console.ReadLine();
        if (addNew == "y")
        {

        }
        else if(addNew == "n")
        {

        }
        else
        {
          Console.WriteLine("Было введено некорректное значение.");
        }
      }
        
      foreach(var foundAbonent in foundAbonents)
      {
        Console.WriteLine($"{foundAbonent.Name} {foundAbonent.PhoneNumber}");
      }
    }

    public void UpdateAbonent()//Должен обновлять данные абонента по номеру телефона или по имени абонента.
    {

    }

    public void DeleteAbonent()//Удалить всю информацию об абоненте.
    {

    }
  }
}
