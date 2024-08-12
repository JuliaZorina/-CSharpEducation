using System;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
  class Phonebook
  {
    private static Phonebook phonebook;

    private Phonebook() 
    { }

    public static Phonebook GetPhonebook(string path)
    {
      if(phonebook==null)
        phonebook = new Phonebook();//Вызывает приватный конструктор. Должен вернуть объект класса Phonebook,
                                        //в котором лежит List<Abonent>
      return phonebook;
    }

    const string path = @"..\..\phonebook.txt";

    public List<Abonent> abonent = GetAbonents(GetStrings(path));

    private static List<string> GetStrings(string path)
    {
      FileInfo file = new FileInfo(path);

      if (!file.Exists)
        file.Create();

      var abonentsStrings = new List<string>();

      using (StreamReader sr = new StreamReader(path))
      {
        string line;

        while ((line = sr.ReadLine()) != null)
        {
          abonentsStrings.Add(line);
        }
      }
      return abonentsStrings;
    }

    private static List<Abonent> GetAbonents(List<string> abonentsStrings)
    {
      var abonents = new List<Abonent>();
      foreach (var str in abonentsStrings)
      {
        var abonentInfo = str.Split(' ');
        var abonent = new Abonent();
        abonent.PhoneNumber = abonentInfo[0];
        abonent.Name = abonentInfo[1];
        abonents.Add(abonent);
      }
      return abonents;
    }    
  }
}
