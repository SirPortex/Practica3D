using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text POINTS;
    public int coins;


    private void Start()
    {
        //POINTS = GetComponent<TMP_Text>();
    }

    void Update()
    {
        POINTS.text = coins.ToString();
    }
    public void agarrar()
    {
        coins += 1; // sumara 1 puntos a cada objecto asugnado que choque con pumtuacion
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        Color color = POINTS.color;
        for (float alpha = 1.0f; alpha >= 0; alpha -= 0.01f)
        {
            color.a = alpha;
            POINTS.color = color;
            yield return null;
        }
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
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
