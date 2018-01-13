using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSPosition {

    public string Longitude;
    public string Latitude;
    public string Altitude;

    public GPSPosition(string longitude, string latitude, string altitude)
    {
        Longitude = (longitude);
        Latitude = (latitude);
        Altitude = (altitude);
    }
}
