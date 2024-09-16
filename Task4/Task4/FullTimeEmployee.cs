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

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (obj is FullTimeEmployee)
      {
        FullTimeEmployee emp = obj as FullTimeEmployee;
        return emp.Name == this.Name;
      }
      return base.Equals(obj);
    }

    public override int GetHashCode() 
    { 
      return this.Name.GetHashCode()+this.BaseSalary.GetHashCode();
    }
  }
}
