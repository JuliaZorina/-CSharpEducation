using System;

namespace Task4
{
  public class FullTimeEmployee : Employee
  {
    #region Поля и свойства

    public override string Name { get; set; }
    public override decimal BaseSalary { get; set; }

    #endregion

    #region Методы

    public override decimal CalculateSalary()
    {
      return BaseSalary;
    }

    #endregion

    #region Базовый класс

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

    #endregion

    #region Конструкторы

    public FullTimeEmployee(string name, decimal baseSalary)
      : base(name, baseSalary) { }

    #endregion
  }
}
