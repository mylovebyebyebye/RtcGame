using System.Collections;
using UnityEngine;

public class SceneCont : MonoBehaviour {
	bool rotate;
	void Update () {
		if (Input.GetMouseButtonDown (1)) rotate = true;
		if (Input.GetMouseButtonUp (1)) rotate = false;
	}
	///更新坐标信息
	void LateUpdate()
	{
			
	}
}