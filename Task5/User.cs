using System;

namespace Task5
{
  public class User
  {
    #region Поля и свойства
    /// <summary>
    /// Уникальный идентивикатор пользователя.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Адрес электронной почты пользователя.
    /// </summary>
    public string Email { get; set; }
    #endregion

    #region Конструкторы
    public User(int id, string name, string email) 
    { 
      this.Id = id;
      this.Name = name;
      this.Email = email;
    }
    #endregion
  }
}
