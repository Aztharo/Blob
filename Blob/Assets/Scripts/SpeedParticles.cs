using UnityEngine;

public class SpeedParticles : MonoBehaviour
{
    public ParticleSystem ps;
    private bool first;
    public GameObject player;

    private void Start()
    {
        ps.Pause();
    }

    void FixedUpdate()
    {
        ps.transform.position = player.transform.position + new Vector3(0, 0, -1);
        if (GameObject.Find("Player").GetComponent<PlayerMovement>().ftlright)
        {
            ps.transform.rotation = Quaternion.Euler(0, 0, 90);
            ps.Emit(1);
        }
        else if (GameObject.Find("Player").GetComponent<PlayerMovement>().ftlleft)
        {
            ps.transform.rotation = Quaternion.Euler(0, 0, -90);
            ps.Emit(1);
        }
        else ps.Clear();
        
    }
}