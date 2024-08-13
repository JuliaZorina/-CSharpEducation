using System;

namespace Task3
{
  internal class Program
  {
    static void Main(string[] args)
    {
      const string path = @"..\..\phonebook.txt";

      Phonebook phonebook = Phonebook.getPhonebook(path);
      Phonebook.Menu(phonebook.abonent);
    }        
  }
}
