using UnityEngine;

public class AnimalArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraManager.cameraAction?.Invoke(3, 11);
        }
    }

    private void OnTriggerExit(Collider ohter)
    {
        if (ohter.CompareTag("Player"))
        {
            CameraManager.cameraAction?.Invoke(3, 0);
        }
    }
}
