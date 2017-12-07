using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class GameController : MonoBehaviour
{
  public List<Player> players = new List<Player>();
  public static GameController single;
  public GameObject mapPrefab;

  void Awake()
  {
    single = this;
  }
  void Start()
  {
    PlayerAddObj(1, "ToonSoldier_demo");
    PlayerAddObj(1, "Soldier_demo");
    PlayerAddObj(1, "ToonRTS_demo_Knight");
  }
  void Update()
  {
    UpdateObjPostionOnMap();
  }
  ///更新在地图上的位置
  void UpdateObjPostionOnMap()
  {
    if (players.Count > 0)
    {
      foreach (var player in players)
      {
        for (int i = 0; i < player.controlled.Count; i++)
        {
          player.mapFlags[i].position = MapController.single.GetMapPostion(player.controlled[i].transform.position);
        }
      }
    }
  }
  void PlayerAddObj(int player, string name)
  {
    players[player].controlled.Add(GameObject.Find(name));
    var map = GameObject.Instantiate(mapPrefab, MapController.single.transform) as GameObject;
    map.GetComponent<Image>().color = players[player].ColotFlag;
    players[player].mapFlags.Add(map.GetComponent<RectTransform>());
  }
}
