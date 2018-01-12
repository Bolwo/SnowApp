using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSPosition : MonoBehaviour {

    public double Longitude;
    public double Latitude;
    public double Altitude;

    public GPSPosition(string longitude, string latitude, string altitude)
    {
        Longitude = Convert.ToDouble(longitude);
        Latitude = Convert.ToDouble(latitude);
        Altitude = Convert.ToDouble(altitude);
    }
}
