using System;

namespace Task3
{/// <summary>
/// Структура, содержащая информацию об абоненте.
/// Поле phoneNumber содержит номер телефона абонента, поле name - имя.
/// </summary>
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
