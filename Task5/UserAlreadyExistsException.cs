using System;

namespace Task5
{
  public class UserAlreadyExistsException:ArgumentException 
  {
    public UserAlreadyExistsException(string message)
    :base(message)
    { }
  }
}
