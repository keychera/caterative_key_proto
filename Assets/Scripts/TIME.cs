using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIME : MonoBehaviour
{
    void OnEnable()
    {
        GameManager.OnChangeCounter += Progress;
    }

    void OnDisable()
    {
        GameManager.OnChangeCounter -= Progress;
    }

	void Progress(int counter) {
		transform.localRotation = Quaternion.Euler(
			0,0,
			transform.localEulerAngles.z - 22.5f
		);
	}
}
