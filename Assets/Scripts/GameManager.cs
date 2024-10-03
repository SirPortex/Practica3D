using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //el game manager controla las variables del juego y es accesible a todos

    private float time;
    private List<string> hours;


    public enum GameManagerVariables { TIME };//para facilitar el codigo

    private void Awake()
    {
        if (!instance)
        {
            instance = this;//se instancia el objecto
            DontDestroyOnLoad(gameObject);// no se destruye entre cargas
            hours = new List<string>(); //Instanciar el objeto.
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
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

    public void SetHours(List<string> value)
    {
        hours = value;
    }

    public List<string> GetHours()
    {
        return hours;
    }
}
