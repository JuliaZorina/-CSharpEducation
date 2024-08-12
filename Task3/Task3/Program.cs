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
      //GetStrings(path);
    }

    private static void GetStrings(string path)
    {
      FileInfo file = new FileInfo(path);

      if (file.Exists)
      {
        var abonentsStrings = new List<string>();
        using (StreamReader sr = new StreamReader(path)) 
        { 
          string line;
          while((line = sr.ReadLine()) != null)
          {
            abonentsStrings.Add(line);
          }
        }

      }
      else
      {
        file.Create();
      }
    }

  }
}
