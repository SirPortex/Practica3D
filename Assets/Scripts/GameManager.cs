using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //el game manager controla las variables del juego y es accesible a todos

    private float time;
    private int points;
    //public AudioClip SelectClip;

    public enum GameManagerVariables { TIME, POINTS };//para facilitar el codigo

    private void Awake()
    {
        if (!instance)
        {
            instance = this;//se instancia el objecto
            DontDestroyOnLoad(gameObject);// no se destruye entre cargas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public float GetTime()
    {
        return time;
    }

    // getter
    public int GetPoints()
    {
        return points;
    }

    // setter
    public void SetPoints(int value)
    {
        points = value;
    }
}
