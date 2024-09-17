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
            AddUser(out name, out email, out id);
            Menu();
            break;
          case "2":
            RemoveUser(out id);
            Menu();
            break;
          case "3":
            FindUserByID(out id);
            Menu();
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

    private void FindUserByID(out int id)
    {
      Console.WriteLine("Введите идентификатор пользователя, которого вы хотите найти.");
      id = int.Parse(Console.ReadLine());
      this.Manager.GetUser(id);
    }

    private void RemoveUser(out int id)
    {
      Console.WriteLine("Введите идентификатор пользователя, которого вы хотите удалить из системы.");
      id = int.Parse(Console.ReadLine());
      this.Manager.RemoveUser(id);
    }

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
  }
}
