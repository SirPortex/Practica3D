using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataTXT : MonoBehaviour
{
    public string fileName = "SaveFile.txt";

    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + '\\' + fileName))
        {
            try
            {
                //Cargar informacion
                StreamReader streamReader = new StreamReader(Application.persistentDataPath + '\\' + fileName);
                streamReader.ReadLine(); //La primera linea no es importante, movemos el cursor del archivo a la siguiente linea
                float x = float.Parse(streamReader.ReadLine()); //Parse -> Pasar de un string a otro tipo. EJ: pasar de string a float.
                float y = float.Parse(streamReader.ReadLine());
                float z = float.Parse(streamReader.ReadLine());
                int c = int.Parse(streamReader.ReadLine());
                string t = (streamReader.ReadLine());

                streamReader.Close();

                Points point = GetComponent<Points>(); //recupero el objeto Points
                point.coins = c;

                transform.position = new Vector3(x, y, z);

            }
            catch (System.Exception e) //como no guardamos la info en ningun server, guardamos en LOCAL.
            {                         // No tenemos control sobre los archivos del usuario. Nos aseguramos de que si algo va mal, este todo controlado.
                                      //sacar al topo de AC
                Debug.Log(e.Message);
            }
        }
    }
    private void OnApplicationQuit()
    {
        //guardar
        Points point = GetComponent<Points>();

        var streamWritter = new StreamWriter(Application.persistentDataPath + '\\' + fileName);
        streamWritter.WriteLine("Archivo de guardado");
        streamWritter.WriteLine(transform.position.x);
        streamWritter.WriteLine(transform.position.y);
        streamWritter.WriteLine(transform.position.z);
        streamWritter.WriteLine(point.coins);
        streamWritter.WriteLine(DateTime.Now);

        streamWritter.Close(); //IMPORTANTE !!! CERRAR
    }
}
