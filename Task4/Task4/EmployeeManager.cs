using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
  /// <summary>
  /// Класс для управления списком сотрудников.
  /// </summary>
  /// <typeparam name="T">В качестве типа T ожидается Employee.</typeparam>
  public class EmployeeManager<T> : IEmployeeManager<T>
    where T: Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Коллекция сотрудников.
    /// </summary>
    protected List<T> employees;

    #endregion
    
    #region Методы

    public void Add(T employee)
    {
      if (this.employees.Contains(employee))
      {
        throw new ArgumentException("Сотрудник с такими данными уже существует");
      }
      else
      {
        this.employees.Add(employee);
      }      
    }

    public T Get(string name)
    {
      if (!this.employees.Any(emp => emp.Name==name))
      {
        throw new ArgumentException($"Не существует сотрудника с именем {name}");
      }
      else
        return this.employees.FirstOrDefault(emp => emp.Name==name);
    }

    public void Update(T employee)
    {
      Console.WriteLine($"Введите новое имя для сотрудника {employee.Name}");
      employee.Name = Console.ReadLine();
      Console.WriteLine($"Введите новое значение зарплаты для сотрудника {employee.Name}");
      employee.BaseSalary = decimal.Parse(Console.ReadLine());
      if (employee is PartTimeEmployee)
      {
        var partTimeEmployee = employee as PartTimeEmployee;
        Console.WriteLine($"Введите новое значение количества отработанных часов для сотрудника {employee.Name}");
        partTimeEmployee.WorkingHours = int.Parse(Console.ReadLine());
      }
    }

    #endregion

    #region Конструкторы

    public EmployeeManager()
    {
      this.employees = new List<T>();
    }

    #endregion
  }
}
