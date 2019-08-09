using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; 

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -20);
    }
}
