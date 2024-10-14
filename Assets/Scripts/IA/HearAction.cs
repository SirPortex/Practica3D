using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HearAction (A)", menuName = "ScriptableObject/Actions/HearAction")] //IMPORTANTE


public class HearAction : Action
{
    public float radius = 20f;
    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position, radius, Vector3.up); // Casteamos una esfera alrededor del enemigo

        GameObject target = owner.GetComponent<TargetReference>().target; // accedemos al target ,al igual que en el chase.

        foreach (RaycastHit hit in hits) //Recorremos el array entero de los colliders y si uno de ellos es el target devuelve true
        {
            if(hit.collider.gameObject == target)
            {
                //le hemos escuchado / oler
                return true;
            }
        }
        return false; // no lo escucho

    }

    public override void DrawGizmos(GameObject owner)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(owner.transform.position, radius);

    }

}
