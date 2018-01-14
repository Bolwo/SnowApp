using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMapGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateModel()//Called on button click from menu
    {
        var test = LogHandler.ReadLog();
        foreach(var x in test)
        {
            Debug.Log(x.Latitude + " " + x.Longitude + " " + x.Altitude);
        }
        //this function should use the gps log data to call CreateHeightMap() and generate a heightmap raster image. This will be stored to 
        //the file system, later to be used to generate the terrain.
    }

    void CreateHeightMap(List<GPSPosition> gpsdata)
    {

    }
}
