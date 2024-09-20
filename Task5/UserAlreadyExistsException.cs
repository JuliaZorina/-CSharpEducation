using System;

namespace Task5
{
  /// <summary>
  /// Пользователь уже существует.
  /// </summary>
  public class UserAlreadyExistsException:ArgumentException 
  {
    #region Конструторы 

    public UserAlreadyExistsException(string message)
      : base(message)
    { }

    #endregion
  }
}