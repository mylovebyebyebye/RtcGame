using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputControll : MonoBehaviour
{
  List<Select> selets = new List<Select>();
  public TerrainCollider collider;
  void Update()
  {
    MouseLeftClick();
    MouseRightClick();
  }
  ///鼠标左键点击
  void MouseLeftClick()
  {
    if (!Input.GetMouseButtonDown(0)) return;
    EventSystem es = EventSystem.current;
    if (es != null && es.IsPointerOverGameObject()) return; //选中二位物体
    if (selets.Count > 0)
    {
      if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
      {
        foreach (var selet in selets)
        {
          if (selet != null) selet.DeSetlect();
        }
        selets.Clear();
      }
    }
    if (selets.Count > 0)
    {
      if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift)) //移除已经被鼠标右键选中的和被按键左Shift键多选的  
      {
        foreach (var sel in selets)
        {
          if (sel != null) sel.DeSetlect();
        }
        selets.Clear();
      }
    }
    Ray hitRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (!Physics.Raycast(hitRay, out hit)) return; //如果没有选中物体
    var select = hit.transform.GetComponent<Select>();
    if (select != null)
    {
      select.Setlect();
      selets.Add(select);
    }
  }
  ///鼠标右键点击
  void MouseRightClick()
  {
    if (Input.GetMouseButtonDown(1) && selets.Count > 0)
    {
      foreach (var select in selets)
      {
        if (select != null) select.RightClick(GetRightClickPostion());
      }
    }
  }
  public Vector3? GetRightClickPostion()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (!collider.Raycast(ray, out hit, Mathf.Infinity)) return null;
    return hit.point;
  }
}