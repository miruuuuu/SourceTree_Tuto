using UnityEngine;

public class Mover : MonoBehaviour
{
    public bool isRun, isFly, isSwim;

    void Update()
    {
        if (isRun)
        {
            Debug.Log("달린다!");
        }

        if (isFly)
        {
            Debug.Log("난다!");
        }

        if (isSwim)
        {
            Debug.Log("헤엄친다!");
        }
        
    }
}
