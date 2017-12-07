using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour
{
  ///视口位置
  public RectTransform viewport;
  public static MapController single;
  public Transform c1, c2;
  Vector2 terrainSize;
  RectTransform mapTransform;
  void Start()
  {
    single = this;
    terrainSize = new Vector2(c2.position.x - c1.position.x, c2.position.z - c1.position.z);
    mapTransform = GetComponent<RectTransform>();
  }
  public Vector2 GetMapPostion(Vector3 cameraPostion)
  {
    Vector3 pos = cameraPostion - c1.position;
    return new Vector2(pos.x / terrainSize.x * mapTransform.rect.width, pos.z / terrainSize.y * mapTransform.rect.height);
  }
  void Update()
  {
    viewport.position = GetMapPostion(Camera.main.transform.position);
  }
}
