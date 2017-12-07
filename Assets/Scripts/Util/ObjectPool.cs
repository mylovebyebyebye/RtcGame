using UnityEngine;
using System.Collections.Generic;

public class ObjectPool<T>
{
  Stack<T> stack = new Stack<T>();
  public void Store(T t)
  {
    stack.Push(t);
  }
}
