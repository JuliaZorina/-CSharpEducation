using System;

namespace Task4
{
  public class PartTimeEmployee : Employee
  {
    #region Поля и свойства
    public override string Name { get; set; }
    public override decimal BaseSalary { get; set; }
    public int WorkingHours { get; set; }
    #endregion

    #region Конструкторы
    public PartTimeEmployee(string name, decimal baseSalary, int workingHours)
      : base(name, baseSalary) 
    {
      this.WorkingHours = workingHours;
    }
    #endregion

    #region Методы
    public override decimal CalculateSalary()
    {
      return this.BaseSalary* this.WorkingHours;
    }
    #endregion

    #region Базовый класс
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
    #endregion
  }
}
