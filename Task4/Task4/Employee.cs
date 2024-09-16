using System;

namespace Task4
{
  public abstract class Employee
  {
    #region Поля и свойства
    /// <summary>
    /// Имя сотрудника.
    /// </summary>
    public abstract string Name { get; set; }
    /// <summary>
    /// Зарплата сотрудника.
    /// </summary>
    public abstract decimal BaseSalary { get; set; }
    #endregion

    #region Конструкторы
    protected Employee(string name, decimal baseSalary) 
    {
      this.Name = name;
      this.BaseSalary = baseSalary;
    }
    #endregion

    #region Методы
    /// <summary>
    /// Подсчитать зарплату сотрудника.
    /// </summary>
    /// <returns>Подсчитанное значение зарплаты сотрудника.</returns>
    public abstract decimal CalculateSalary();
    #endregion
  }
}
