using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Task4
{
  public class UserMenu
  {
    #region Поля и свойства

    public EmployeeManager<Employee> EmployeeManager { get; set; }
    
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
        decimal baseSalary = 0;
        int workingHours = 0;

        Console.WriteLine("Нажмите 1 для добавления полного сотрудника.\n" +
          "Нажмите 2 для добавления частичного сотрудника.\n" +
          "Нажмите 3 для получения данных о сотруднике.\n" +
          "Нажмите 4 для обновления данных сотрудника.\n" +
          "Нажмите 5 для подсчета зарплаты сотрудника.\n" +
          "Нажмите 6 для выхода из программы.");

        var menu = Console.ReadLine();

        switch (menu)
        {
          case "1":
            AddFullTimeEmployee(this.EmployeeManager, out name, out baseSalary);
            Menu();
            break;
          case "2":
            AddPartTimeEmployee(this.EmployeeManager, out name, out baseSalary, out workingHours);
            Menu();
            break;
          case "3":
            GetEmployee(this.EmployeeManager, out name);
            Menu();
            break;
          case "4":
            UpdateEmployee(this.EmployeeManager, out name);
            Menu();
            break;
          case "5":
            GetEmployeeSalary();
            Menu();
            break;
          case "6":
            Exit();
            break;
          default:
            Console.WriteLine("Введено некорректное значение!");
            Menu();
            break; 
        }

        }
      catch(Exception ex) 
      {
        Console.WriteLine(ex.ToString());
        Menu();
      }

      }
    /// <summary>
    /// Получить подчситанное значение зарплаты сотрудника и вывести это значение в консоль.
    /// </summary>
    private void GetEmployeeSalary()
    {
      string name;
      Console.WriteLine("Введите имя сотрудника, зарплату которого вы хотите подсчитать");
      name = Console.ReadLine();
      var foundEmployee = this.EmployeeManager.Get(name);
      if (foundEmployee != null)
      {
        Console.WriteLine($"Зарплата сотрудника {foundEmployee.Name}: { foundEmployee.CalculateSalary()}");
      }
    }
    /// <summary>
    /// Обновить данные о сотруднике.
    /// </summary>
    /// <param name="manager">Экземпляр класса EmployeeManager.</param>
    /// <param name="name">Имя сотрудника, зарплату которого необходимо подсчитать.</param>
    private static void UpdateEmployee(EmployeeManager<Employee> manager, out string name)
    {
      Console.WriteLine("Введите имя сотрудника, данные которого вы хотите обновить");
      name = Console.ReadLine();
      var foundEmployee = manager.Get(name);
      if (foundEmployee != null)
      {
        manager.Update(foundEmployee);
      }
    }
    /// <summary>
    /// Получить данные о сотруднике и вывести их в консоль.
    /// </summary>
    /// <param name="manager">Экземпляр класса EmployeeManager.</param>
    /// <param name="name">Имя сотрудника.</param>
    private static void GetEmployee(EmployeeManager<Employee> manager, out string name)
    {
      Console.WriteLine("Введите имя сотрудника");
      name = Console.ReadLine();
      var foundEmployee = manager.Get(name);
      if (foundEmployee != null)
      {
        Console.WriteLine($"Имя: {manager.Get(name).Name}. Зарплата: {manager.Get(name).BaseSalary}");
      }
    }
    /// <summary>
    /// Добавить в коллекцию сотрудника с почасовой оплатой.
    /// </summary>
    /// <param name="manager">Экземпляр класса EmployeeManager.</param>
    /// <param name="name">Имя нового сотрудника.</param>
    /// <param name="baseSalary">Почасовая ставка сотрудника.</param>
    /// <param name="workingHours">Количество отработанных сотрудником часов.</param>
    private void AddPartTimeEmployee(EmployeeManager<Employee> manager, out string name, out decimal baseSalary, out int workingHours)
    {
      Console.WriteLine("Введите имя сотрудника");
      name = Console.ReadLine();
      Console.WriteLine("Введите почасовую ставку сотрудника");
      baseSalary = decimal.Parse(Console.ReadLine());
      Console.WriteLine("Введите время, которое отрбаотал сотрудник");
      workingHours = int.Parse(Console.ReadLine());
      manager.Add(new PartTimeEmployee(name, baseSalary, workingHours));
    }
    /// <summary>
    /// Добавить нового сотрудника с фиксированной зарплатой.
    /// </summary>
    /// <param name="manager">Экземпляр класса EmployeeManager.</param>
    /// <param name="name">Имя нового сотрудника.</param>
    /// <param name="baseSalary">Зарплата сотрудника.</param>
    private void AddFullTimeEmployee(EmployeeManager<Employee> manager, out string name, out decimal baseSalary)
    {
      Console.WriteLine("Введите имя сотрудника");
      name = Console.ReadLine();
      Console.WriteLine("Введите зарплату сотрудника");
      baseSalary = decimal.Parse(Console.ReadLine());
      manager.Add(new FullTimeEmployee(name, baseSalary));
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
      EmployeeManager = new EmployeeManager<Employee>();
    }

    #endregion
  }
}
