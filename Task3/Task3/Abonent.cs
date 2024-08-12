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
  }
}
