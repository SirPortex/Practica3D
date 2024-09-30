using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Points;

public class Puntuation : MonoBehaviour
{
    private GameObject Efecto;
    private float CantidadPuntos;
    

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<PlayerMovement_RB>())
        {
            other.gameObject.GetComponent<Points>().agarrar(); // la moneda sumara puntos y se destruir al entrar en contacto con Puntuacion
            Destroy(gameObject);
        }
    }
}
