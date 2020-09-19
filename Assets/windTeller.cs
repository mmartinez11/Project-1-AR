using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using TMPro;
using System;

public class windTeller : MonoBehaviour
{
    public Animator windAnimator;
    public Animator speedAnimator;

    public GameObject mphTextObject;

    public GameObject speedTextObject;
    public String windDir;
    public GameObject directionTextObject;
       string url = "http://api.openweathermap.org/data/2.5/weather?lat=41.88&lon=-87.6&APPID=acc4bbc98bd69f9619ec12b379277df0&units=imperial";

   
    void Start()
    {
        mphTextObject.GetComponent<TextMeshPro>();
       // wait a couple seconds to start and then refresh every 900 seconds
        InvokeRepeating("GetDataFromWeb", 2f, 900f);
   }

   void GetDataFromWeb()
   {
        if(mphTextObject.activeInHierarchy)
        {
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
                
                speedTextObject.GetComponent<TextMeshPro>().text = weather.wind.speed.ToString();

                windAnimator.GetComponent<Animator>();
                speedAnimator.GetComponent<Animator>();

                if(weather.wind.deg > 348.0 || weather.wind.deg <= 33.0)
                {
                    windDir ="N";
                }

                if(weather.wind.deg > 33.0 && weather.wind.deg <= 78.0)
                {
                    windDir ="NE";
                }

                if(weather.wind.deg > 78.0 && weather.wind.deg <= 123.0)
                {
                    windDir ="E";
                }

                if(weather.wind.deg > 123.0 && weather.wind.deg <= 168.0)
                {
                    windDir ="SE";
                }

                if(weather.wind.deg > 168.0 && weather.wind.deg <= 213.0)
                {
                    windDir ="S";
                }

                if(weather.wind.deg > 213.0 && weather.wind.deg <= 258.0)
                {
                    windDir ="SW";
                }

                if(weather.wind.deg > 258.0 && weather.wind.deg <= 303.0)
                {
                    windDir ="W";
                }

                if(weather.wind.deg > 303.0 && weather.wind.deg <= 348.0)
                {
                    windDir ="NW";
                }

                directionTextObject.GetComponent<TextMeshPro>().text = windDir;
                windAnimator.Play(windDir);

                playSpeedAnimation(weather.wind.speed, speedAnimator);
            }
        }
    }
    
    public void playSpeedAnimation(double speed, Animator wind)
    {
        String value = " ";

        if(speed <= 10.0)
        {
            value = "10mph";
        }
        else if(speed <= 20.0)
        {
            value = "20mph";
        }
         else if(speed <= 30.0)
        {
            value = "30mph";
        }
         else if(speed <= 40.0)
        {
            value = "40mph";
        }
         else if(speed <= 50.0)
        {
            value = "50mph";
        }
         else if(speed <= 60.0)
        {
            value = "60mph";
        }
         else if(speed <= 70.0)
        {
            value = "70mph";
        }
         else if(speed <= 80.0)
        {
            value = "80mph";
        }
         else if(speed <= 90.0)
        {
            value = "90mph";
        }
         else if(speed > 90.0)
        {
            value = "100mph";
        }

        wind.Play(value);
    }

}