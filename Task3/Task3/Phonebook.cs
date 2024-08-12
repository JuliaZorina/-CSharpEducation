using System;

namespace Task3
{
  class Phonebook
  {
    private static Phonebook phonebook;
    
    private Phonebook() 
    { }

    public static Phonebook GetPhonebook()
    {
      if(phonebook==null)
        phonebook = new Phonebook();//Вызывает приватный конструктор. Должен вернуть объект класса Phonebook,
                                        //в котором лежит List<Abonent>
      return phonebook;
    }

    public static void CreateAbonent()//Должен добавлять в List<Abonent> нового абонента.
    {
      var abonent = new Abonent();
      try
      {
        Console.WriteLine("Введите номер телефона");
        abonent.PhoneNumber = Console.ReadLine();
        Console.WriteLine("Введите имя абонента");
        abonent.PhoneNumber = Console.ReadLine();
        
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
