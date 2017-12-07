using UnityEngine;
using System.Collections.Generic;


public class RtsManager : MonoBehaviour {

	public static RtsManager Current = null;

	public List<PlayerSetupDefinition> Players = new List<PlayerSetupDefinition>();

	// Use this for initialization
	void Start () {
		Current = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
