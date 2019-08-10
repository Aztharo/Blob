using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipping : MonoBehaviour
{
    public SpriteRenderer sr;
    public bool flipped;

    void Update()
    {
        float z = transform.rotation.eulerAngles.z - 90;
        if (z > 0 && z < 180 && !flipped)
        {
            flipped = true;
            transform.localScale = new Vector3(2, -2, 1);
        }
        else if (z < 360 && z > 180 && flipped || z < 0 && z > -90 && flipped)
        {
            flipped = false;
            transform.localScale = new Vector3(2, 2, 1);
        }
    }
}