using System;

namespace Task4
{
  /// <summary>
  /// Базовый класс для сотрудника.
  /// </summary>
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

    #region Методы

    /// <summary>
    /// Подсчитать зарплату сотрудника.
    /// </summary>
    /// <returns>Подсчитанное значение зарплаты сотрудника.</returns>
    public abstract decimal CalculateSalary();

    #endregion

    #region Конструкторы
    /// <summary>
    /// Конструктор для создания объекта класса Employee.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <param name="baseSalary">Зарплата сотрудника.</param>
    protected Employee(string name, decimal baseSalary)
    {
      this.Name = name;
      this.BaseSalary = baseSalary;
    }

    #endregion
  }
}
