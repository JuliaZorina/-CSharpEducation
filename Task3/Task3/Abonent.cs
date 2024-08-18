using System;

namespace Task3
{/// <summary>
/// Содержит информацию об абоненте.
/// </summary>
/// <param name="phoneNumber">Номер телефона абонента.</param>
/// <param name="name">Имя абонента.</param>
  public struct Abonent
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
    
  }
}
