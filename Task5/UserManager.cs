using System;
using System.Collections.Generic;
using System.Linq;

namespace Task5
{
  public class UserManager
  {
    #region Поля и свойства
    /// <summary>
    /// Коллекция пользователей.
    /// </summary>
    public List<User> Users { get; set; }
    #endregion

    #region Конструкторы
    public UserManager() 
    {
      this.Users = new List<User>();
    }
    #endregion

    #region Методы
    /// <summary>
    /// Добавить новго пользователя в коллекцию.
    /// </summary>
    /// <param name="user">Пользователь.</param>
    /// <exception cref="NotImplementedException"></exception>
    public void AddUser(User user)
    {
      if (this.Users.FirstOrDefault(x=>x.Id==user.Id)!=null) 
      {
        throw new NotImplementedException();
      }
      else
      {
        this.Users.Add(user);
      }      
    }
    /// <summary>
    /// Удалить пользователя из списка.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <exception cref="NotImplementedException"></exception>
    public void RemoveUser(int id) 
    {
      var foundUser = this.Users.FirstOrDefault(x => x.Id == id);
      if ( foundUser== null)
      {
        throw new NotImplementedException();
      }
      else
      {
        this.Users.Remove(foundUser);
      }
    }
    /// <summary>
    /// Получить данные о пользователе по его идентитфикатору.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <exception cref="NotImplementedException"></exception>
    public void GetUser(int id)
    {
      var foundUser = this.Users.FirstOrDefault(x => x.Id == id);
      if (foundUser == null)
      {
        throw new NotImplementedException();
      }
      else
      {
        Console.WriteLine($"Пользователь найден.\nИмя:{foundUser.Name}. Почта:{foundUser.Email}");
      }
    }
    /// <summary>
    /// Получить список всех пользователей и вывести его в консоль.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void ListUser()
    {
      if (this.Users.Count <= 0)
      {
        throw new NotImplementedException();
      }
      else
      {
        Console.WriteLine("Полный список пользователей:\n");
        foreach (var user in this.Users)
        {
          Console.WriteLine($"Id:{user.Id} Имя:{user.Name} Почта:{user.Email}");
        }
      }
    }
    #endregion
  }
}
