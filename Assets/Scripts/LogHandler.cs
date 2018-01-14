using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LogHandler : MonoBehaviour {

    static string path = Application.persistentDataPath + "/gps1.txt";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void WriteString(string input)
    {
        
        if (!File.Exists(path))
        {
            File.CreateText(path);
        }
        
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(input);
        writer.Close();
        
    }

    public static List<GPSPosition> ReadLog()
    {
        List<GPSPosition> gpsList = new List<GPSPosition>();
        if (File.Exists(path))
        {
            var logFile = File.ReadAllLines(path);
            var logList = new List<string>(logFile);
            foreach (var item in logList)
            {
                var split = item.Split(',');
                GPSPosition x = new GPSPosition(Convert.ToDouble(split[0]), Convert.ToDouble(split[1]), Convert.ToDouble(split[2]));
                gpsList.Add(x);
            }
        }
        return gpsList;
    }
}
