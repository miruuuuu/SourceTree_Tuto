using UnityEngine;

public interface IState
{
    public void StateEnter()
    {
        Debug.Log("State Enter...");
    }

    public void StateUpdate()
    {
        Debug.Log("State Update...");
    }

    public void StateExit()
    {
        Debug.Log("State Exit...");
    }
}
