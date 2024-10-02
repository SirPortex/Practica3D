using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

[System.Serializable]
struct PlayerData
{
    public Vector3 position;
    public int point;
    public string date;
}

public class SaveDataJSON : MonoBehaviour
{
    public string fileName = "Save.json";

    // Start is called before the first frame update
    void Start()
    {

        fileName = Application.persistentDataPath + '\\' + fileName;


        if (File.Exists(fileName)) //Si el archivo existe se guarda
        {

            StreamReader streamReader = new StreamReader(fileName);

            Points point = GetComponent<Points>();

            try
            {
                PlayerData playerData = JsonUtility.FromJson<PlayerData>(streamReader.ReadToEnd()); // "FromJson" -> De JSON a objeto. Leemos todo de principio a fin. Te devuelve en formato JSON
                transform.position = playerData.position;
                point.coins = playerData.point;
                DateTime date = DateTime.Now;
            }
            catch (System.Exception e)
            {
                //Sacar al topo de Animal Crossing
                Debug.Log(e.Message);
            }
            streamReader.Close();
        }
    }

    // Update is called once per frame
    private void OnApplicationQuit()
    {
        Points point = GetComponent<Points>();

        StreamWriter streamWritter = new StreamWriter(fileName);
        PlayerData playerData = new PlayerData(); //instancio el objeto que vamos a guardar
        playerData.position = transform.position; //rellenamos la info del objeto
        playerData.point = point.coins;           
        playerData.date = DateTime.Now.ToString();

        string json = JsonUtility.ToJson(playerData); //"To.Json" -> recibe un objeto serializable y nos genera un string de ese objeto serializable.
        streamWritter.WriteLine(json);

        streamWritter.Close();
    }
}