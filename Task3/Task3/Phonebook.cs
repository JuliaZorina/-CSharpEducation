using System;

namespace Task3
{
  class Phonebook
  {
    private static Phonebook instance;
    private Phonebook() 
    { }

    public static Phonebook GetPhonebook()
    {
      if(instance==null)
        instance = new Phonebook();
      return instance;
    }
  }
}
