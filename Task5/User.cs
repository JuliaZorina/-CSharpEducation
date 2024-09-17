using System;

namespace Task5
{
  public class User
  {
    #region Поля и свойства
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    #endregion

    #region Конструкторы
    public User(string id, string name, string email) 
    { 
      this.Id = id;
      this.Name = name;
      this.Email = email;
    }
    #endregion
  }
}
