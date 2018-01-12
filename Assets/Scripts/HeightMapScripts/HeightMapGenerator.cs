using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightMapGenerator : MonoBehaviour {

    public TextAsset GPSData;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateModel()//Called on button click from menu
    {
        var test = ReadFileToArray();
        foreach(var x in test)
        {
            Debug.Log(x.Latitude + " " + x.Longitude + " " + x.Altitude);
        }

    }
    List<GPSPosition> ReadFileToArray() //Converts gps text file data to list of GPSPosition data
    {
        List<string> GPSList = TextAssetToList(GPSData);
        List<GPSPosition> GPSPositions = new List<GPSPosition>();
        foreach(string item in GPSList)
        {
            var split = item.Split(',');
            if(split[0] == "$GPGGA")
            {
                GPSPosition pos = new GPSPosition(split[2], split[4], split[9]);
                GPSPositions.Add(pos);
            }
        }
        return GPSPositions;
    }

    void CreateHeightMap()
    {

    }

    private List<string> TextAssetToList(TextAsset ta)
    {
        var listToReturn = new List<string>();
        var arrayString = ta.text.Split('\n');
        foreach (var line in arrayString)
        {
            listToReturn.Add(line);
        }
        return listToReturn;
    }
}
