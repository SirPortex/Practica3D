using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]

public struct StateParameters
{
    [Tooltip("Indicates if the action´s check must be true or false")]
    public bool actionValue;
    [Tooltip("Action that is gonna be executed")]
    public Action action;
    [Tooltip("If the actions´s check equals acionValue, nextState is pushed")]
    public State nextState;
}

public abstract class State : ScriptableObject
// El run de la clase state no hace nada.
{

    public StateParameters[] stateParameters;

    public void DrawnAllActionsGizmos( GameObject owner)
    {
        //for (int i = 0; i < stateParameters.Length; i++)
        //{
        //    stateParameters[i].action.DrawGizmos(owner);
        //}

        foreach (StateParameters parameters in stateParameters)
        {
            parameters.action.DrawGizmos(owner);
        }
    }

    protected State CheckActions(GameObject owner) //devolvera true si alguna de sus acciones de cumple, o false si es el contrario
    {
        for (int i = 0; i < stateParameters.Length; i++)
        {
            if (stateParameters[i].actionValue == stateParameters[i].action.Check(owner)) //chekea si se cumple 
            {
                return (stateParameters[i].nextState);
            }
        }
        return null; // ninguna accion se cumple por lo que no cambiamos de estado
    }

    public abstract State Run(GameObject owner); // comprueba si las acciones se cumplen y ademas, ejecuta el comportamiento asociado al estado.
}
