using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GpsLogging : MonoBehaviour {

    GameObject settingsPanel;
    // Use this for initialization
    void Start () {
        settingsPanel = GameObject.Find("SettingsPanel");

        settingsPanel.GetComponentInChildren<Text>().text += Application.persistentDataPath;
        StartCoroutine(LogGPSData());
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void ToggleLogging() 
    {
        settingsPanel.GetComponentInChildren<Text>().text += "Location is enabled by user: " + Input.location.isEnabledByUser + "/n";
        if (Input.location.status == LocationServiceStatus.Running || Input.location.status == LocationServiceStatus.Initializing)
        {
            StopLocationTracking();
        } else
        {
            StartCoroutine(StartLocationTracking());
        }
    }
    IEnumerator StartLocationTracking()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            settingsPanel.GetComponentInChildren<Text>().text += "Not enabled by user, break. /n";
            yield break;
        }
        // Start service before querying location
        settingsPanel.GetComponentInChildren<Text>().text += "Starting location monitoring";
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            settingsPanel.GetComponentInChildren<Text>().text += "Initializing..";
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            settingsPanel.GetComponentInChildren<Text>().text += ("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            settingsPanel.GetComponentInChildren<Text>().text += ("Unable to determine device location");
            yield break;
        }
        else
        {
            settingsPanel.GetComponentInChildren<Text>().text += "Running! SUCCESS!";
        }
    }

    void StopLocationTracking()
    {
        Input.location.Stop();
        settingsPanel.GetComponentInChildren<Text>().text += "Stopped logging";
        
    }

    IEnumerator LogGPSData() //TODO: may fail when working with an empty gps file (ie, if it has to create it because it does not already exist). This may already be fixed with the try catch though
    {

        while(true)
        {
            try
            {
                settingsPanel.GetComponentInChildren<Text>().text += "tick";
                if (Input.location.status == LocationServiceStatus.Running)
                {
                    settingsPanel.GetComponentInChildren<Text>().text += "Updated gps text log";
                    LogHandler.WriteString(Input.location.lastData.latitude + "," + Input.location.lastData.longitude + "," + Input.location.lastData.altitude + "," + Input.location.lastData.horizontalAccuracy + "," + Input.location.lastData.timestamp);
                }
            } catch(Exception e)
            {

            }
            yield return new WaitForSeconds(5);
        }
    }
}
