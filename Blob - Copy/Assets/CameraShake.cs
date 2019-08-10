using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Transform cam;
    Vector3 originalPos;
    public float intensity;

    private void Start()
    {
        cam = GetComponent<Transform>();
        originalPos = cam.localPosition;
    }

    float pendingShakeDuration = 0f;

    public void Shake( float duration)
    {
        if (duration > 0)
        {
            pendingShakeDuration += duration;
        }

    }
    bool isShaking = false;

    void Update()
    {
        if (pendingShakeDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }
    }
    IEnumerator DoShake()
    {
        isShaking = true;
        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + pendingShakeDuration)
        {
            var randomPoint = new Vector3(Random.Range(-1f, 1f)*intensity, Random.Range(-1f, 1f)*intensity, originalPos.z);
            cam.localPosition = randomPoint;
            yield return null;

        }
        pendingShakeDuration = 0f;
        cam.localPosition = originalPos;
        isShaking = false;
            
    }
}
