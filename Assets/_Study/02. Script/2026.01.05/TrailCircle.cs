using UnityEngine;

public class TrailCircle : MonoBehaviour
{
    private TrailRenderer trail;

    private float theta;
    public float timer = 1f;
    public float speed = 10f;
    public float radius = 5f;


    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
        trail.time = timer;
    }

    private void Update()
    {
        theta += speed * Time.deltaTime;

        radius = Mathf.PingPong(Time.time, 5f);

        transform.position = radius * new Vector3(Mathf.Cos(theta), Mathf.Sin(theta), 0);
        


    }



}
