using UnityEngine;

public class MouseParticle : MonoBehaviour
{
    private ParticleSystem ps;

    public int burstCount = 30;
    public float timer = 2f; //입자의 생존 시간. lifetime.

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var mainModule = ps.main;
        mainModule.startLifetime = timer;
        mainModule.gravityModifier = 1f;
        mainModule.simulationSpace = ParticleSystemSimulationSpace.World;
    }


    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPos;

        if (Input.GetMouseButtonDown(0))
        {
            ps.Emit(burstCount);
        }

    }
}
