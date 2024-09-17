using System;

namespace Task5
{
  public class UserMenu
  {
    #region Поля и свойства
    public UserManager Manager { get; set; }
    #endregion

    #region Конструкторы
    public UserMenu()
    {
      Manager = new UserManager();
    }
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
            }
            break;
          case "4":
            this.Manager.ListUser();
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
    /// Осуществить поиск пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пользователя в системе.</param>
    private void FindUserByID(out int id)
    {
      Console.WriteLine("Введите идентификатор пользователя, которого вы хотите найти.");
      id = int.Parse(Console.ReadLine());
      this.Manager.GetUser(id);
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
  }
}
