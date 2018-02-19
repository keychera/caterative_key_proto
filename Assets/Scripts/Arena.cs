using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Arena : MonoBehaviour {
	public float height = 10;
	public GameObject wallL, wallR, wallU;

	void Start() {
		wallL.transform.localScale = new Vector3(2,height,1);
		wallL.transform.localPosition = new Vector2(-3,(height-10)/2);
		wallR.transform.localScale = new Vector3(2,height,1);
		wallR.transform.localPosition = new Vector2(3,(height-10)/2);
		wallU.transform.position = new Vector3(0,(height/2) + 0.5f + (height-10)/2,0);
	}
}
