using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
  public class EmployeeManager<T> : IEmployeeManager<T>
    where T: Employee
  {
    protected List<T> employees;

    public EmployeeManager()
    {
      this.employees = new List<T>();
    }

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
      var emp = Get(employee.Name);
      Console.WriteLine($"Введите новое имя для сотрудника {emp.Name}");
      emp.Name = Console.ReadLine();
      Console.WriteLine($"Введите новое значение зарплаты для сотрудника {emp.Name}");
      emp.BaseSalary = int.Parse(Console.ReadLine());
    }    
  }
}
