using UnityEngine;
using System.Collections;
///单个对象类
public class PoolTimeline
{
  ///操控的对象
  public GameObject gameObject;
  ///是否存活
  public bool isAlive;
  ///存活时间
  public float aliveTime;
  public PoolTimeline(GameObject game)
  {
    gameObject = game;
    isAlive = true;
  }
  public GameObject ALive()
  {
    gameObject.SetActive(true);
    isAlive = true;
    aliveTime = 0;
    return gameObject;
  }
  public void Sleep()
  {
    gameObject.SetActive(false);
    isAlive = false;
    aliveTime = Time.time;
  }
  public bool IsOutTime()
  {
    if (isAlive) return false;
    if (Time.time - aliveTime > PoolController.AliveTime) return true;
    return false;
  }
}
