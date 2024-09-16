﻿using System;

namespace Task4
{
  public interface IEmployeeManager<T>
  {
    void Add(T employee);
    T Get(string name);
    void Update(T employee);
  }
}
