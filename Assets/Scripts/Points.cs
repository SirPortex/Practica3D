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
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut() //Corrutina para empezar el fade out
    {
        Color color = POINTS.color; // Se hace una variable de tipo color para poder modificar el color del componente TMP_Text
        for (float alpha = 1.0f; alpha >= 0; alpha -= 0.01f)
        {
            color.a = alpha;
            POINTS.color = color;
            yield return null;
        }
        StartCoroutine(FadeIn()); // cuando se acaba el fade out empieza el fade in
    }

    public IEnumerator FadeIn() // Corrutina Fade in
    {
        Color color = POINTS.color;
        for (float alpha = 0.0f; alpha <= 1; alpha += 0.01f)
        {
            color.a = alpha;
            POINTS.color = color;
            yield return null;

        }
    }
}