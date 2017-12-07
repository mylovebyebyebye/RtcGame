using UnityEngine;
using System.Collections.Generic;

public class PoolController : MonoBehaviour
{
  ///设置对象存活时间
  public static readonly float AliveTime = 100f;
  Dictionary<string, PoolItem> itemMap;

  private volatile static PoolController single;
  static Object loackObj = new Object();
  ///双重锁型单例
  public static PoolController Instance
  {
    get
    {
      if (single == null)
      {
        lock (loackObj)
        {
          if (single == null)
            single = new PoolController();
        }
      }
      return single;
    }
  }
  private PoolController() { itemMap = new Dictionary<string, PoolItem>(); }
  public void DestroyTimeOutItem()
  {

  }
  ///创建对象池
  public void CreatePool(string name)
  {
    if (!itemMap.ContainsKey(name))
    {
      itemMap.Add(name, new PoolItem(name));
    }
  }
  ///存储一个对象
  public void Push(string name, GameObject obj)
  {
    if (!itemMap.ContainsKey(name))
      CreatePool(name);
    itemMap[name].Push(obj);
  }
  ///获取一个正处于睡眠状态的obj
  public GameObject Pop(string name)
  {
    if (!itemMap.ContainsKey(name)) return null;
    return itemMap[name].Pop();
  }
  ///睡眠一个对象
  public void ActiveObjectSleep(string name, GameObject obj)
  {
    if (itemMap.ContainsKey(name))
    {
      itemMap[name].Sleep(obj);
    }
  }
  ///同一类型的对象全部睡眠
  public void SleepAll(string name)
  {
    if (itemMap.ContainsKey(name))
      itemMap[name].SleepAll();
  }
  ///销毁一个对象
  public void RemoveObj(string name, GameObject obj)
  {
    if (itemMap.ContainsKey(name))
    {
      itemMap[name].DestroyObj(obj);
    }
  }
  ///清理超时的对象
  public void CleanTimeOutObj()
  {
    foreach (var item in itemMap.Values)
    {
      item.DestroyTimeOutObject();
    }
  }
  ///清理所有对象
  public void Clear()
  {
    foreach (var item in itemMap.Values)
      item.Clear();
    itemMap = new Dictionary<string, PoolItem>();
  }
}
