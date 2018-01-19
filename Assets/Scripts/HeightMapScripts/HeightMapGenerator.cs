using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

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
            //Debug.Log(x.Latitude + " " + x.Longitude + " " + x.Altitude);
            //settingsPanel.GetComponentInChildren<Text>().text += x.Latitude + " " + x.Longitude + " " + x.Altitude;

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

        int xheight = rightmost - leftmost;
        int yheight = highest - lowest;

        //double[,] rasterarray = new double[xheight + 1,yheight + 1]; //create array to that size
        var texture = new Texture2D(xheight + 1, yheight + 1);

        Color color = new Color(1, 1, 1);
        Color32[] colors = new Color32[(xheight + 1) * (yheight + 1)];

        //insert gps data into appropriate index
        foreach(var pos in gpsdata)
        {
            var colorindex = ((pos.Latitude - ydisplace) * (xheight + 1)) + (pos.Longitude - xdisplace); //find the flattened index of a 2d array
            colors[colorindex] = color;
        }
        texture.SetPixels32(colors); //apply 1d array of colors to 2d texture
        texture.Apply();

        File.WriteAllBytes(Application.persistentDataPath + "/gpsraster.png", texture.EncodeToPNG());
    }
}
