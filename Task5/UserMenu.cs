using System;

namespace Task5
{
  public class UserMenu
  {
    #region Поля и свойства

    public UserManager Manager { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Меню для взаимодействия пользователя с ситемой.
    /// </summary>
    public void Menu()
    {
      try
      {
        string name = string.Empty;
        string email = string.Empty;
        int id = 0;

        Console.WriteLine("Нажмите 1 для добавления пользователя.\n" +
          "Нажмите 2 для удаления пользователя.\n" +
          "Нажмите 3 для получения данных о пользователе.\n" +
          "Нажмите 4 для получения списка всех пользователей.\n" +
          "Нажмите 5 для выхода из программы.");

        var menu = Console.ReadLine();

        switch (menu)
        {
          case "1":
            try
            {
              AddUser(out name, out email, out id);
              Menu();
            }
            catch (UserAlreadyExistsException ex)
            {
              Console.WriteLine(ex.ToString());
              Menu();
            }
            break;
          case "2":
            try
            {
              RemoveUser(out id);
              Menu();
            }
            catch(UserNotFoundException ex)
            {
              Console.WriteLine(ex.ToString());
              Menu();
            }
            break;
          case "3":
            try
            {
              FindUserByID(out id);
              Menu();
            }
            catch (UserNotFoundException ex)
            {
              Console.WriteLine(ex.ToString());
              Menu();
            }
            break;
          case "4":
            GetAllUsers();
            Menu();
            break;
          case "5":
            Exit();
            break;
          default:
            Console.WriteLine("Введено некорректное значение!");
            Menu();
            break;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
        Menu();
      }
    }
    /// <summary>
    /// Получить полный список пользователей системы и вывести его на экран.
    /// </summary>
    private void GetAllUsers()
    {
      var users = this.Manager.ListUser();
      if (users != null)
      {
        Console.WriteLine("Полный список пользователей:\n");
        foreach (var user in users)
        {
          Console.Write($"Id:{user.Id} Имя:{user.Name} Почта:{user.Email}\n");
        }
      }
      else
      {
        Console.WriteLine("Список не найден");
      }
    }
    /// <summary>
    /// Осуществить поиск пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пользователя в системе.</param>
    private void FindUserByID(out int id)
    {
      Console.WriteLine("Введите идентификатор пользователя, которого вы хотите найти.");
      id = int.Parse(Console.ReadLine());
      var foundUser = this.Manager.GetUser(id);
      Console.WriteLine($"Пользователь найден.\nИмя:{foundUser.Name}. Почта:{foundUser.Email}\n");
    }
    /// <summary>
    /// Удалить пользователя из системы.
    /// </summary>
    /// <param name="id">Иддентификатор пользователя в системе.</param>
    private void RemoveUser(out int id)
    {
      Console.WriteLine("Введите идентификатор пользователя, которого вы хотите удалить из системы.");
      id = int.Parse(Console.ReadLine());
      this.Manager.RemoveUser(id);
    }
    /// <summary>
    /// Добавить пользователя в систему.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <param name="email">Адрес электронной почты пользователя.</param>
    /// <param name="id">Идентификатор пользователя в системе.</param>
    private void AddUser(out string name, out string email, out int id)
    {
      Console.WriteLine("Введите id пользователя");
      id = int.Parse(Console.ReadLine());
      Console.WriteLine("Введите имя пользователя");
      name = Console.ReadLine();
      Console.WriteLine("Введите email пользователя");
      email = Console.ReadLine();
      this.Manager.AddUser(new User(id, name, email));
    }
    /// <summary>
    /// Выйти из программы.
    /// </summary>
    private void Exit()
    {
      Console.WriteLine("Вы действительно хотите выйти из программы? [y/n]");
      var exit = Console.ReadLine();

      if (exit == "y")
        Console.WriteLine("Выход из программы...");
      else if (exit == "n")
        Menu();
      else
      {
        Console.WriteLine("Введено некорректное значение!");
        Exit();
      }
    }

    #endregion

    #region Конструкторы

    public UserMenu()
    {
      this.Manager = new UserManager();
    }

    #endregion
  }
}
