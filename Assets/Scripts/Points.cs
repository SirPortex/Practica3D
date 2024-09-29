using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text POINTS;
    public int coins;


    void Update()
    {
        POINTS.text = coins.ToString();
    }
    public void agarrar()
    {
        coins += 1; // sumara 1 puntos a cada objecto asugnado que choque con pumtuacion
    }
}
