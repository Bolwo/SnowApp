using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LogHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void WriteString(string input)
    {
        string path = Application.persistentDataPath + "/gps1.txt";
        if (!File.Exists(path))
        {
            File.CreateText(path);
        }
        
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(input);
        writer.Close();
        
    }
}
