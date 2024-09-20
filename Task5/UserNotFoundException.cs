using System;

namespace Task5
{
  /// <summary>
  /// Пользователь не найден.
  /// </summary>
  public class UserNotFoundException : ArgumentNullException
  {
    #region Конструкторы

    public UserNotFoundException(string message)
    : base(message)
    { }

    #endregion
  }
}
