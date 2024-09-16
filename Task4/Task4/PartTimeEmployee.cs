using System;

namespace Task4
{
  public class PartTimeEmployee : Employee
  {
    public override string Name { get; set; }
    public override decimal BaseSalary { get; set; }
    public int WorkingHours {  get; set; }

    public PartTimeEmployee(string name, decimal baseSalary, int workingHours) 
    { 
      this.Name = name; 
      this.BaseSalary = baseSalary;
      this.WorkingHours = workingHours;
    }

    public override decimal CalculateSalary()
    {
      return this.BaseSalary * this.WorkingHours;
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (obj is PartTimeEmployee)
      {
        PartTimeEmployee emp = obj as PartTimeEmployee;
        return emp.Name == this.Name;
      }
      return base.Equals(obj);
    }

    public override int GetHashCode()
    {
      return this.Name.GetHashCode() + this.BaseSalary.GetHashCode();
    }
  }
}
