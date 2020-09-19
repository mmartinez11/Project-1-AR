using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using TMPro;
using System;

public class tempTeller : MonoBehaviour
{
    public Animator test1;//Testing
    public Animator humidityA;

    public GameObject percentTextObject;
    public GameObject tempTextObject;
    public GameObject humidityTextObject;

       string url = "http://api.openweathermap.org/data/2.5/weather?lat=41.88&lon=-87.6&APPID=acc4bbc98bd69f9619ec12b379277df0&units=imperial";

   
    void Start()
    {
        humidityA.GetComponent<Animator>();
        percentTextObject.GetComponent<TextMeshPro>();
       // wait a couple seconds to start and then refresh every 900 seconds
       InvokeRepeating("GetDataFromWeb", 2f, 900f);
   }

   void GetDataFromWeb()
   {
       if(percentTextObject.activeInHierarchy){
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
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);

                
                var weather = JsonConvert.DeserializeObject<WeatherResponse>(webRequest.downloadHandler.text);
                
                tempTextObject.GetComponent<TextMeshPro>().text = weather.main.temp.ToString();
                humidityTextObject.GetComponent<TextMeshPro>().text = weather.main.humidity.ToString();

                //-----------------------------------------------
                test1.GetComponent<Animator>();
                
                if(weather.main.temp >= 90.0)
                {
                    test1.Play("HundredToInfinity");
                }
                else if(weather.main.temp >= 80.0 && weather.main.temp < 90.0)
                {
                    test1.Play("EightyToEightynine");
                }
                else if(weather.main.temp >= 70.0 && weather.main.temp < 80.0)
                {
                    test1.Play("SeventyToSeventynine");
                    Debug.Log("Seventy more and less than eighty");
                }
                else if(weather.main.temp >= 60.0 && weather.main.temp < 70.0)
                {
                    test1.Play("SixtyToSixtynine");
                }
                else if(weather.main.temp >= 50.0 && weather.main.temp < 60.0)
                {
                    test1.Play("FiftytoFiftynine");
                }
                else if(weather.main.temp >= 40.0 && weather.main.temp < 50.0)
                {
                    test1.Play("FourtyToFourtynine");
                }
                else if(weather.main.temp >= 30.0 && weather.main.temp < 40.0)
                {
                    test1.Play("ThirtyToThirtynine");
                }
                else if(weather.main.temp >= 20.0 && weather.main.temp < 30.0)
                {
                    test1.Play("TwentyToTwentynine");
                }
                else if(weather.main.temp >= 10.0 && weather.main.temp < 20.0)
                {
                    test1.Play("TenToNineteen");
                }
                else if(weather.main.temp < 10.0)
                {
                    test1.Play("ZeroToNine");
                }

                //-----------------------------------------------

                 if(weather.main.humidity >= 90.0)
                {
                    humidityA.Play("100percent");
                }
                else if(weather.main.humidity >= 80.0 && weather.main.humidity < 90.0)
                {
                    humidityA.Play("90percent");
                }
                else if(weather.main.humidity >= 70.0 && weather.main.humidity < 80.0)
                {
                    humidityA.Play("80percent");
                }
                else if(weather.main.humidity >= 60.0 && weather.main.humidity < 70.0)
                {
                    humidityA.Play("70percent");
                }
                else if(weather.main.humidity >= 50.0 && weather.main.humidity < 60.0)
                {
                    humidityA.Play("60percent");
                }
                else if(weather.main.humidity >= 40.0 && weather.main.humidity < 50.0)
                {
                    humidityA.Play("50percent");
                }
                else if(weather.main.humidity >= 30.0 && weather.main.humidity < 40.0)
                {
                    humidityA.Play("40percent");
                }
                else if(weather.main.humidity >= 20.0 && weather.main.humidity < 30.0)
                {
                    humidityA.Play("30percent");
                }
                else if(weather.main.humidity >= 10.0 && weather.main.humidity < 20.0)
                {
                    humidityA.Play("20percent");
                }
                else if(weather.main.humidity < 10.0)
                {
                    humidityA.Play("10percent");
                }
                //-----------------------------------------------

            }
        }
    }

}