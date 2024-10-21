using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "GuardState (S)", menuName = "ScriptableObject/States/GuardState")] //IMPORTANTE

public class GuardState : State
{
    public Vector3 guardPoint;

    public string blendParameter;

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        Animator anim = owner.GetComponent<Animator>();


        navMeshAgent.SetDestination(guardPoint);
        anim.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed);

        return nextState;
    }
}
