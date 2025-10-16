using UnityEngine;
using System.Collections.Generic;

public class Fsm : MonoBehaviour
{
    private Dictionary<EntityMoves, IState> states = new();
    private IState currentState;
    void Update()
    {
        currentState?.Execute();
    }

    void FixedUpdate()
    {
        currentState?.FixedExecute();
    }
    public void RegisterState(EntityMoves em, IState state)
    {
        if (!states.ContainsKey(em))
        {
            states.Add(em, state);
        }
    }
    public void ChangeState(EntityMoves em)
    {
        if (states.ContainsKey(em)&&currentState!=states[em])
        {
            currentState?.Exit();
            currentState = states[em];
            currentState?.Enter();
        }
    }
    public IState GetCurrentState()
    {
        return currentState;
    }
}