using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipping : MonoBehaviour {
	public SpriteRenderer sr;
	// Update is called once per frame
	void Update () {
		float z = transform.rotation.eulerAngles.z-90;
		if (z > 0 && z < 180 && !sr.flipY)
			sr.flipY = true;
		else if (z < 360 && z > 180 && sr.flipY || z < 0 && z > -90 && sr.flipY)
			sr.flipY = false;
	}
}