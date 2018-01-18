using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HeightMapGenerator : MonoBehaviour {

    GameObject settingsPanel;
    // Use this for initialization
    void Start () {
        settingsPanel = GameObject.Find("SettingsPanel");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateModel()//Called on button click from menu
    {
        var gpsdata = LogHandler.ReadLog();
        foreach(var x in gpsdata) //test purposes, read log to settings page
        {
            Debug.Log(x.Latitude + " " + x.Longitude + " " + x.Altitude);
            settingsPanel.GetComponentInChildren<Text>().text += x.Latitude + " " + x.Longitude + " " + x.Altitude;

        }
        //this function should use the gps log data to call CreateHeightMap() and generate a heightmap raster image. This will be stored to 
        //the file system, later to be used to generate the terrain.
        CreateHeightMap(gpsdata);
    }

    void CreateHeightMap(List<GPSPosition> gpsdata)
    {
        //find size of array
        IEnumerable<GPSPosition> orderedlat = gpsdata.OrderByDescending(x => x.Latitude);
        int highest = orderedlat.First().Latitude;
        int lowest = orderedlat.Last().Latitude;

        IEnumerable<GPSPosition> orderedlong = gpsdata.OrderByDescending(x => x.Longitude);
        int leftmost = orderedlong.Last().Longitude;
        int rightmost = orderedlong.First().Longitude;

        int xdisplace = leftmost;
        int ydisplace = lowest;

        int xheight = highest - lowest;
        int yheight = rightmost - leftmost;
        double[,] rasterarray = new double[xheight,yheight]; //create array to that size

        //insert gps data into appropriate index
        foreach(GPSPosition pos in gpsdata)
        {
            rasterarray[pos.Longitude - xdisplace, pos.Latitude - ydisplace] = pos.Altitude;
        }


    }
}
