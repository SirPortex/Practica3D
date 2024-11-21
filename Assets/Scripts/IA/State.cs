using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public struct ActionParameters
{
    [Tooltip("Action that is gonna be executed")]
    public Action action;
    [Tooltip("Indicates if the action's check must be true or false")]
    public bool actionValue;
}

[System.Serializable]
public struct StateParameters
{
    [Tooltip("ActionParameters' array")]
    public ActionParameters[] actionParameters;
    [Tooltip("If the action's check equals actionValue, nextState is pushed")]
    public State nextState;
    [Tooltip("Se cumplen todas las acciones o solo se tiene que cumplir una?")]
    public bool and;
}

public abstract class State : ScriptableObject
{
    public StateParameters[] stateParameters;

    protected State CheckActions(GameObject owner)
    {
        // devolvera el siguiente estado que toque si alguna de sus acciones se cumple, o null si es al contrario
        for (int i = 0; i < stateParameters.Length; i++)
        {
            bool todasLasAccionesSeHanCumplido = true;
            for (int j = 0; j < stateParameters[i].actionParameters.Length; j++)
            {
                ActionParameters actionParameter = stateParameters[i].actionParameters[j];
                if (actionParameter.action.Check(owner) == actionParameter.actionValue)
                {
                    if (!stateParameters[i].and) // si solo se tiene que cumplir una
                    {
                        // devolvemos directamente el siguiente estado
                        return stateParameters[i].nextState;
                    }
                }
                else if (stateParameters[i].and)
                {
                    todasLasAccionesSeHanCumplido = false;
                    break; // salimos del bucle, porque una accion no se ha cumplido
                           // y estamos en and
                }
            }

            // si llegamos hasta aqui, significa que el disenyador ha marcado que todas las acciones
            // tienen que cumplirse. Tenemos que comprobar si de verdad se han cumnplido todas
            if (stateParameters[i].and && todasLasAccionesSeHanCumplido)
            {
                return stateParameters[i].nextState;
            }
        }

        return null; // ninguna accion se cumple, por lo que no cambiamos de estado
    }

    // comprueba si las acciones se cumplen
    // y ademas, ejecuta el comportamiento asociado al estado
    public abstract State Run(GameObject owner);

    public void DrawAllActionsGizmos(GameObject owner)
    {
        foreach (StateParameters parameter in stateParameters)
        {
            foreach (ActionParameters aP in parameter.actionParameters)
            {
                aP.action.DrawGizmos(owner);
            }
        }
    }

    public void UpdateStateText(TMP_Text text)  
    {
        if(text) 
        {
            text.text = name; // cambiamos el texto del componente al nombre
        }
    }
}
