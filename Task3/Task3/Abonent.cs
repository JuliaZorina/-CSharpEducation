using System;

namespace Task3
{
  class Abonent
  {
    private string phoneNumber;

    public string PhoneNumber
    {
      get 
      { 
        return this.phoneNumber; 
      }
      set
      {
        if (string.IsNullOrEmpty(value))
        {
          throw new ArgumentException("Номер телефона не может быть пустой строкой!");
        }
        else
        {
          this.phoneNumber = value;
        }
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

    public static void CreateAbonent()//Должен добавлять в List<Abonent> нового абонента.
    {
      var abonent = new Abonent();
      try
      {
        Console.WriteLine("Введите номер телефона");
        abonent.PhoneNumber = Console.ReadLine();
        Console.WriteLine("Введите имя абонента");
        abonent.Name = Console.ReadLine();

      }
      catch
      {
        Console.WriteLine();
      }

    }

    public static void ReadAbonent()//Должен находить абонента по номеру телефона или номер телефона по имени абонента.
    {

    }

    public static void UpdateAbonent()//Должен обновлять данные абонента по номеру телефона или по имени абонента.
    {

    }

    public static void DeleteAbonent()//Удалить всю информацию об абоненте.
    {

    }
  }
}
