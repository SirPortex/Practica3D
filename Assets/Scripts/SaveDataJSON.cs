using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
struct PlayerData
{
    public Vector3 position;
    public int score;
}


public class SaveDataJSON : MonoBehaviour
{
    public string fileName = "Save.json";


    // Start is called before the first frame update
    void Start()
    {
        Points point = GetComponent<Points>();

        fileName = Application.persistentDataPath + '\\' + fileName;

        StreamWriter streamWritter = new StreamWriter(fileName);
        PlayerData playerData = new PlayerData(); //instancio el objeto que vamos a guardar
        playerData.position = transform.position; //rellenamos la info del objeto

        //playerData.score = Points

        string json = JsonUtility.ToJson(playerData); //"To.Json" -> recibe un objeto serializable y nos genera un string de ese objeto serializable.
        streamWritter.WriteLine(json);

        streamWritter.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (File.Exists(fileName)) //Si el archivo existe se guarda
        {
            StreamReader streamReader = new StreamReader(fileName);

            string json = streamReader.ReadToEnd();
            streamReader.Close();

            try
            {
                PlayerData playerData = JsonUtility.FromJson<PlayerData>(json); // "FromJson" -> De JSON a objeto. Leemos todo de principio a fin. Te devuelve en formato JSON
                transform.position = playerData.position;
            }
            catch (System.Exception e)
            {
                //Sacar al topo de Animal Crossing
                Debug.Log(e.Message);
            }
        }
    }
}
