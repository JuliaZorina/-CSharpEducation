using System;

namespace Task5
{
  public class UserNotFoundException : ArgumentNullException
  {
    public UserNotFoundException(string message)
    : base(message)
    { }
  }
}
