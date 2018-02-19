using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickEvent : Singleton<BrickEvent> {
	public delegate void OnBrickDestroy(Brick whichBrick);
}
