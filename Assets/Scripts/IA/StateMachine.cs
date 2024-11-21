using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    public State currentState;
    public TMP_Text tMP;

    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
        currentState.UpdateStateText(tMP);
    }

    // Update is called once per frame
    void Update()
    {
        State nextState = currentState.Run(gameObject);

        if(nextState)
        {
            currentState = nextState;
            currentState.UpdateStateText(tMP);
        }
    }

    private void OnDrawGizmos()
    {
        if(currentState)
            currentState.DrawAllActionsGizmos(gameObject);
        else if(initialState)
            initialState.DrawAllActionsGizmos(gameObject);
    }
}
