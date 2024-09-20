using System;
using System.Collections.Generic;
using System.Linq;

namespace Task5
{
  /// <summary>
  /// Класс для управления списком пользователей.
  /// </summary>
  public class UserManager
  {
    #region Поля и свойства

    /// <summary>
    /// Коллекция пользователей.
    /// </summary>
    public List<User> Users { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Добавить новго пользователя в коллекцию.
    /// </summary>
    /// <param name="user">Пользователь.</param>
    /// <exception cref="UserAlreadyExistsException">Выбросить исключение, если такой пользователь уже существует.</exception>
    public void AddUser(User user)
    {
      if (this.Users.FirstOrDefault(x =>x .Id == user.Id) != null) 
      {
        throw new UserAlreadyExistsException("Пользователь с такими данными уже существует!");
      }
      else
      {
        this.Users.Add(user);
        Console.WriteLine($"Пользователь {user.Name} был успешно добавлен в систему!\n");
      }      
    }
    /// <summary>
    /// Удалить пользователя из списка.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <exception cref="UserNotFoundException">Выбросить исключение, если пользователь не найден.</exception>
    public void RemoveUser(int id) 
    {
      var foundUser = this.Users.FirstOrDefault(x => x.Id == id);
      if ( foundUser== null)
      {
        throw new UserNotFoundException($"Пользователь с идентификатором {id} не существует в системе.");
      }
      else
      {
        this.Users.Remove(foundUser);
        Console.WriteLine($"Пользователь с идентификатором {id} был успешно удален из системы.\n");
      }
    }
    /// <summary>
    /// Получить данные о пользователе по его идентитфикатору.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <exception cref="UserNotFoundException">Выбросить исключение, если пользователь не найден.</exception>
    public User GetUser(int id)
    {
      var foundUser = this.Users.FirstOrDefault(x => x.Id == id);
      if (foundUser == null)
      {
        throw new UserNotFoundException($"Пользователь с идентификатором {id} не существует в системе.");
      }
      else
      {
        return foundUser;
      }
    }
    /// <summary>
    /// Получить список всех пользователей и вывести его в консоль.
    /// </summary>
    public List<User> ListUser()
    {
      return this.Users;
    }

    #endregion

    #region Конструкторы

    public UserManager()
    {
      this.Users = new List<User>();
    }

    #endregion
  }
}
