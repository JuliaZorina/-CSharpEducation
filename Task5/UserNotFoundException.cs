using System;

namespace Task5
{
  public class UserNotFoundException : ArgumentNullException
  {
    #region Конструкторы
    public UserNotFoundException(string message)
    : base(message)
    { }
    #endregion
  }
}
