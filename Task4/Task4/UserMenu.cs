using System;
using System.Collections.Generic;

namespace Task4
{
  public class UserMenu
  {
    public void Menu() 
    {
      var manager = new EmployeeManager<Employee>();
      string name = string.Empty;
      decimal baseSalary = 0;
      int workingHours = 0;
      
        Console.WriteLine("Нажмите 1 для добавления полного сотрудника.\n" +
          "Нажмите 2 для добавления частичного сотрудника.\n" +
          "Нажмите 3 для получения данных о сотруднике.\n" +
          "Нажмите 4 для обновления данных сотрудника.\n" +
          "Нажмите 5 для подсчета зарплаты полного сотрудника.\n" +
          "Нажмите 6 для подсчета зарплаты частичного сотрудника.\n" +
          "Нажмите 7 для выхода из программы.");

        var menu = Console.ReadLine();

        switch (menu)
        {
        case "1":
          AddFullTimeEmployee(manager, out name, out baseSalary);
          break;

        case "2":
          AddPartTimeEmployee(manager, out name, out baseSalary, out workingHours);
          break;

        case "3":
          GetEmployee(manager);
          break;

        case "4":
            DeleteAbonent(abonent, phonebook.Path);
            break;
          case "5":
            Exit(abonent);
            break;
          default:
            Console.WriteLine("Введено некорректное значение!");
            Menu();
            break;
        
      }
      
    }

    private static void GetEmployee(EmployeeManager<Employee> manager)
    {
      string name;
      Console.WriteLine("Введите имя сотрудника");
      name = Console.ReadLine();
      var foundEmployee = manager.Get(name).Name;
      if (foundEmployee != null)
      {
        Console.WriteLine($"Имя: {manager.Get(name).Name}. Зарплата: {manager.Get(name).BaseSalary}");
      }
    }

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

    private void AddFullTimeEmployee(EmployeeManager<Employee> manager, out string name, out decimal baseSalary)
    {
      Console.WriteLine("Введите имя сотрудника");
      name = Console.ReadLine();
      Console.WriteLine("Введите зарплату сотрудника");
      baseSalary = decimal.Parse(Console.ReadLine());
      manager.Add(new FullTimeEmployee(name, baseSalary));
    }

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
  }
}
