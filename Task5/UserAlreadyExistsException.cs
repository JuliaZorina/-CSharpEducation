using System;

namespace Task5
{
  public class UserAlreadyExistsException:ArgumentException 
  {
    #region Конструторы
    public UserAlreadyExistsException(string message)
    :base(message)
    { }
    #endregion
  }
}
