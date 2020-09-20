using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using TMPro;
using System;

public class weatherTell : MonoBehaviour
{
    public GameObject ClearSky;
    public GameObject FewClouds;
    public GameObject Rain;
    public GameObject ThunderStorm;
    public GameObject BrokenClouds;
    public GameObject ScatteredClouds;
    public GameObject Snow;
    public GameObject ShowerRain;
    public GameObject Mist;

    public GameObject baseMain;

       string url = "http://api.openweathermap.org/data/2.5/weather?lat=41.88&lon=-87.6&APPID=acc4bbc98bd69f9619ec12b379277df0&units=imperial";

   
    void Start()
    {
        
        ClearSky.GetComponent<GameObject>();
        FewClouds.GetComponent<GameObject>();
        Rain.GetComponent<GameObject>();
        ThunderStorm.GetComponent<GameObject>();
        BrokenClouds.GetComponent<GameObject>();
        ScatteredClouds.GetComponent<GameObject>();
        Snow.GetComponent<GameObject>();
        ShowerRain.GetComponent<GameObject>();
        Mist.GetComponent<GameObject>();

        baseMain.GetComponent<GameObject>();

       // wait a couple seconds to start and then refresh every 900 seconds
       InvokeRepeating("GetDataFromWeb", 2f, 30f);
   }

   void GetDataFromWeb()
   {
       if(baseMain.activeInHierarchy){
       StartCoroutine(GetRequest(url));
       }
   }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                String condition = " ";
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);

                
                var weather = JsonConvert.DeserializeObject<WeatherResponse>(webRequest.downloadHandler.text);
 
                Debug.Log(weather.weather.Capacity);

                foreach(Weather x in weather.weather)
                {
                    condition = x.icon;
                } 

                Debug.Log(condition);

                if(condition == "01d" || condition == "01n")
                {
                        deactivateModels();
                        ClearSky.SetActive(true);
                }
                else if(condition == "02d" || condition == "02n")
                {
                        deactivateModels();
                        FewClouds.SetActive(true);
                }
                else if(condition == "03d" || condition == "03n")
                {
                        deactivateModels();
                        ScatteredClouds.SetActive(true);
                }
                else if(condition == "04d" || condition == "04n")
                {
                        deactivateModels();
                        BrokenClouds.SetActive(true);
                }
                else if(condition == "09d" || condition == "09n")
                {
                        deactivateModels();
                        ShowerRain.SetActive(true);
                }
                else if(condition == "10d" || condition == "10n")
                {
                        deactivateModels();
                        Rain.SetActive(true);
                }
                else if(condition == "11d" || condition == "11n")
                {
                       deactivateModels(); 
                       ThunderStorm.SetActive(true);
                }
                else if(condition == "13d" || condition == "13n")
                {
                        deactivateModels();
                        Snow.SetActive(true);
                }
                else if(condition == "50d" || condition == "50n")
                {
                    deactivateModels();
                    Mist.SetActive(true);
                }
                else
                {
                    Debug.Log("Error 5th");
                }



            }
        }
    }

    public void deactivateModels()
    {
        ClearSky.SetActive(false);
        FewClouds.SetActive(false);
        ScatteredClouds.SetActive(false);

        BrokenClouds.SetActive(false);
        ShowerRain.SetActive(false);
        Rain.SetActive(false);

        ThunderStorm.SetActive(false);
        Snow.SetActive(false);
        Mist.SetActive(false);
    }
    
}