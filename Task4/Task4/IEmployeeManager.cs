using System;

namespace Task4
{
  /// <summary>
  /// Интерфейс с методами для управления списками сотрудников.
  /// </summary>
  /// <typeparam name="T">В качестве типа T ожидается Employee.</typeparam>
  public interface IEmployeeManager<T>
    where T : Employee
  {
    /// <summary>
    /// Добавить нового сотрудника.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    void Add(T employee);

    /// <summary>
    /// Получить данные о сотруднике.
    /// </summary>
    /// <param name="name">Имя сотрудника.</param>
    /// <returns></returns>
    T Get(string name);

    /// <summary>
    /// Обновить данные о сотруднике.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    void Update(T employee);
  }
}
