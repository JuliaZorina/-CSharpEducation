using System;

namespace Task4
{
  public class FullTimeEmployee : Employee
  {
    public override string Name { get; set; }
    public override decimal BaseSalary { get; set; }

    public FullTimeEmployee(string name, decimal baseSalary) 
    {
      this.Name = name;
      this.BaseSalary = baseSalary; 
    }

    public override decimal CalculateSalary()
    {
      return BaseSalary;
    }
  }
}
