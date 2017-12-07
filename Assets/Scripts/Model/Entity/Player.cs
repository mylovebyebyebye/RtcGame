using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Player
{
  ///玩家名字
  public string name;
  //玩家种族
  public Phyle phyle;
  ///玩家出生地
  public Transform transform;
  ///可操控单位
  public List<GameObject> controlled = new List<GameObject>();
  ///地图上的标识
  public List<RectTransform> mapFlags = new List<RectTransform>();
  ///颜色标识
  public Color ColotFlag;
  ///AI
  public bool isAI;
  ///分数
  public float score;
  ///人口上限
  public int personLimit = 10;

}
