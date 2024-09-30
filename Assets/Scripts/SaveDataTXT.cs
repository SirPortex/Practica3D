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
//using static Points;

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

        //List<DateTime> fechas = new List<DateTime>();
        //fechas.Add(DateTime.Now);
        //streamWritter.Write(fechas);

        streamWritter.WriteLine(DateTime.Now);


       

        streamWritter.Close(); //IMPORTANTE !!! CERRAR
    }

    private void OnApplicationFocus()
    {
        
    }
    //private void Awake()
    //{
    //    if (File.Exists(Application.persistentDataPath + '\\' + fileName))
    //    {
    //        try
    //        {
    //            //Cargar informacion
    //            StreamReader streamReader = new StreamReader(Application.persistentDataPath + '\\' + fileName);
    //            streamReader.ReadLine(); //La primera linea no es importante, movemos el cursor del archivo a la siguiente linea
    //            float x = float.Parse(streamReader.ReadLine()); //Parse -> Pasar de un string a otro tipo. EJ: pasar de string a float.
    //            float y = float.Parse(streamReader.ReadLine());
    //            float z = float.Parse(streamReader.ReadLine());
    //            int c = int.Parse(streamReader.ReadLine());

    //            streamReader.Close();

    //            Points point = GetComponent<Points>(); //recupero el objeto Points
    //            point.coins = c;

    //            transform.position = new Vector3(x, y, z);

    //        }
    //        catch (System.Exception e) //como no guardamos la info en ningun server, guardamos en LOCAL.
    //        {                         // No tenemos control sobre los archivos del usuario. Nos aseguramos de que si algo va mal, este todo controlado.
    //                                  //sacar al topo de AC
    //            Debug.Log(e.Message);
    //        }
    //    }
    //}



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(DateTime.Now);
        }
        //if (Input.GetKeyDown(KeyCode.G))
        //{
            
        //    Save();
        //}

        //else if (Input.GetKeyDown(KeyCode.L))
        //{
        //    Load();
        //}

        //void OnApplicationQuit()
        //{
        //    Save();
        //}
        
        //void OnApplicationResume()
        //{
        //    Load();
        //}



        //void Save()
        //{
        //    //guardar
        //    Points point = GetComponent<Points>();
        //    var streamWritter = new StreamWriter(Application.persistentDataPath + '\\' + fileName);
        //    streamWritter.WriteLine("Archivo de guardado");
        //    streamWritter.WriteLine(transform.position.x);
        //    streamWritter.WriteLine(transform.position.y);
        //    streamWritter.WriteLine(transform.position.z);
        //    streamWritter.WriteLine(point.coins);

        //    streamWritter.Close(); //IMPORTANTE !!! CERRAR
        //}

        //void Load()
        //{
        //    if (File.Exists(Application.persistentDataPath + '\\' + fileName))
        //    {
        //        try
        //        {
        //            //Cargar informacion
        //            StreamReader streamReader = new StreamReader(Application.persistentDataPath + '\\' + fileName);
        //            streamReader.ReadLine(); //La primera linea no es importante, movemos el cursor del archivo a la siguiente linea
        //            float x = float.Parse(streamReader.ReadLine()); //Parse -> Pasar de un string a otro tipo. EJ: pasar de string a float.
        //            float y = float.Parse(streamReader.ReadLine());
        //            float z = float.Parse(streamReader.ReadLine());
        //            int c = int.Parse(streamReader.ReadLine());

        //            streamReader.Close();

        //            Points point = GetComponent<Points>(); //recupero el objeto Points
        //            point.coins = c;

        //            transform.position = new Vector3(x, y, z);
                    
        //        }
        //        catch (System.Exception e) //como no guardamos la info en ningun server, guardamos en LOCAL.
        //        {                         // No tenemos control sobre los archivos del usuario. Nos aseguramos de que si algo va mal, este todo controlado.
        //            //sacar al topo de AC
        //            Debug.Log(e.Message);
        //        }
        //    }
        //}
    }
}
