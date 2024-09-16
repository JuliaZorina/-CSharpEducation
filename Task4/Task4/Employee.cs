using System;

namespace Task4
{
  public abstract class Employee
  {
    public abstract string Name { get; set; }
    public abstract decimal BaseSalary { get; set; }

    protected Employee(string name, decimal baseSalary) 
    {
      this.Name = name;
      this.BaseSalary = baseSalary;
    }

    public abstract decimal CalculateSalary();
  }
}
