using UnityEngine;
using System.Collections.Generic;
///处理一个类型的对象
public class PoolItem
{
  public string name;
  Dictionary<int, PoolTimeline> map;

  public PoolItem(string name)
  {
    this.name = name;
    map = new Dictionary<int, PoolTimeline>();
  }
  ///对象存储
  public void Push(GameObject obj)
  {
    int key = obj.GetHashCode();
    if (!map.ContainsKey(key))
      map.Add(key, new PoolTimeline(obj));
    else
      map[key].ALive();
  }

  ///返回一个未被使用的Gameobject
  public GameObject Pop()
  {
    if (map.Count == 0) return null;
    foreach (var item in map.Values)
      if (!item.isAlive)
      {
        item.ALive();
        return item.gameObject;
      }
    return null;
  }
  ///是一个对象未被激活
  public void Sleep(GameObject obj)
  {
    int key = obj.GetHashCode();
    if (map.ContainsKey(key))
    {
      map[key].Sleep();
    }
  }
  public void SleepAll()
  {
    foreach (var obj in map.Values)
    {
      obj.Sleep();
    }
  }
  ///销毁一个对象
  public void DestroyObj(GameObject obj)
  {
    int key = obj.GetHashCode();
    if (map.ContainsKey(key))
    {
      GameObject.Destroy(map[key].gameObject);
      map.Remove(key);
    }
  }

  ///销毁所有对象
  public void Clear()
  {
    foreach (var obj in map.Values)
    {
      GameObject.Destroy(obj.gameObject);
    }
    map = new Dictionary<int, PoolTimeline>();
  }
  ///销毁超时的对象
  public void DestroyTimeOutObject()
  {
    List<PoolTimeline> removeList = new List<PoolTimeline>();
    foreach (PoolTimeline timeline in map.Values)
    {
      if (timeline.IsOutTime())
      {
        removeList.Add(timeline);
      }
    }
    int count = removeList.Count;
    for (int i = 0; i < count; i++)
    {
      DestroyObj(removeList[i].gameObject);
    }
  }
}
