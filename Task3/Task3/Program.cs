using System;
using System.Collections.Generic;
using System.IO;

namespace Task3
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string path = @"..\..\phonebook.txt";
      GetAbonents(GetStrings(path));
    }

    private static List<string> GetStrings(string path)
    {
      FileInfo file = new FileInfo(path);

      if (!file.Exists)
      {
        file.Create();
      }
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
