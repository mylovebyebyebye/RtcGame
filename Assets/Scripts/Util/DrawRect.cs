using UnityEngine;
using System.Collections;

public class DrawRect : MonoBehaviour
{
  ///边框颜色
  Color rectColor = Color.green;
  ///起始点
  Vector3 start = Vector3.zero;
  ///画线材质
  public Material material;
  ///鼠标是否被选中
  bool draw;

  void Start()
  {
    material = new Material("Shader \"Lines/Colored Blended\" {" +
            "SubShader { Pass { " +
            "    Blend SrcAlpha OneMinusSrcAlpha " +
            "    ZWrite Off Cull Off Fog { Mode Off } " +
            "    BindChannels {" +
            "      Bind \"vertex\", vertex Bind \"color\", color }" +
            "} } }");//生成画线的材质
    material.hideFlags = HideFlags.HideAndDontSave;
    material.shader.hideFlags = HideFlags.HideAndDontSave;
  }

  void Update()
  {
    if (Input.GetMouseButton(0))
    {
      start = Input.mousePosition;
      draw = true;
    }
    else if (Input.GetMouseButtonUp(0))
      draw = false;
  }
  void OnPostRender()
  {
    Debug.Log("1111");
    //画线这种操作推荐在OnPostRender（）里进行 而不是直接放在Update，所以需要标志来开启
    // GL.PopMatrix();
    if (draw)
    {
      Vector3 end = Input.mousePosition;//鼠标当前位置
      GL.PushMatrix();//保存摄像机变换矩阵

      if (!material)
        return;

      material.SetPass(0);
      GL.LoadPixelMatrix();//设置用屏幕坐标绘图
      GL.Begin(GL.QUADS);
      GL.Color(new Color(rectColor.r, rectColor.g, rectColor.b, 0.1f));//设置颜色和透明度，方框内部透明
      GL.Vertex3(start.x, start.y, 0);
      GL.Vertex3(end.x, start.y, 0);
      GL.Vertex3(end.x, end.y, 0);
      GL.Vertex3(start.x, end.y, 0);
      GL.End();
      GL.Begin(GL.LINES);
      GL.Color(rectColor);//设置方框的边框颜色 边框不透明
      GL.Vertex3(start.x, start.y, 0);
      GL.Vertex3(end.x, start.y, 0);
      GL.Vertex3(end.x, start.y, 0);
      GL.Vertex3(end.x, end.y, 0);
      GL.Vertex3(end.x, end.y, 0);
      GL.Vertex3(start.x, end.y, 0);
      GL.Vertex3(start.x, end.y, 0);
      GL.Vertex3(start.x, start.y, 0);
      GL.End();
      GL.PopMatrix();//恢复摄像机投影矩阵
    }
  }
}
