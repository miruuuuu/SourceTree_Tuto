using UnityEngine;

public class StudyParticle : MonoBehaviour
{
    public ParticleSystem particle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            particle.Play();
    }
}
