using System;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;
 
public class DebuggerTeller : MonoBehaviour
{
 
    public GameObject vbBtnObj;
    public GameObject clearSkyD;
    public GameObject fewcloudsD;
    public GameObject rainD;
    public GameObject thunderstormD;
    public GameObject brokencloudsD;
    public GameObject scatteredcloudsD;
    public GameObject snowD;
    public GameObject showerrainD;
    public GameObject mistD;

    int turnNumber;
    
    // Use this for initialization
    void Start()
    {
        vbBtnObj = GameObject.Find("Debugger");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);

        clearSkyD.GetComponent<GameObject>();
        fewcloudsD.GetComponent<GameObject>();
        rainD.GetComponent<GameObject>();
        thunderstormD.GetComponent<GameObject>();
        brokencloudsD.GetComponent<GameObject>();
        scatteredcloudsD.GetComponent<GameObject>();
        snowD.GetComponent<GameObject>();
        showerrainD.GetComponent<GameObject>();
        mistD.GetComponent<GameObject>();
        
        turnNumber = 0;
    }
 
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {

        Debug.Log("Button pressed");

        if(turnNumber == 9)
        {
            turnNumber = 0;
            turnNumber = turnNumber + 1;
        }
        else
        {
            turnNumber = turnNumber + 1;
        }

        deactivateAll();
        activateOne(turnNumber);

    }
 
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

        Debug.Log("Button released");
        deactivateAll();
    }

    public void deactivateAll()
    {
        clearSkyD.SetActive(false);
        fewcloudsD.SetActive(false);
        rainD.SetActive(false);

        thunderstormD.SetActive(false);
        brokencloudsD.SetActive(false);
        scatteredcloudsD.SetActive(false);

        snowD.SetActive(false);
        showerrainD.SetActive(false);
        mistD.SetActive(false);
    }

    public void activateOne(int weatherNo)
    {

      switch (weatherNo)
      {
        case 1:
              clearSkyD.SetActive(true);
              break;

        case 2:
              fewcloudsD.SetActive(true);
              break;

        case 3:
              rainD.SetActive(true);
              break;

        case 4:
              thunderstormD.SetActive(true);
              break;

        case 5:
              brokencloudsD.SetActive(true);
              break;

        case 6:
              scatteredcloudsD.SetActive(true);
              break;

        case 7:
              snowD.SetActive(true);
              break;

        case 8:
              showerrainD.SetActive(true);
              break;

        case 9:
              mistD.SetActive(true);
              break;

          default:
              Debug.Log("Error in Debug Switch Case");
              break;
      }

    }
}
