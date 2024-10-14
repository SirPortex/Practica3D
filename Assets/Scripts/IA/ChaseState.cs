using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState (S)", menuName ="ScriptableObject/States/ChaseState")] //IMPORTANTE

public class ChaseState : State
{

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>(); // al herederar de ScriptableObject hay que poner owner para poder heredar el componente de NavMeshAgent
        GameObject target = owner.GetComponent<TargetReference>().target; // indentificamos cual es el target
        navMeshAgent.SetDestination(target.transform.position); // tu destino es el target, ve a por el.

        return nextState;
    }
}
