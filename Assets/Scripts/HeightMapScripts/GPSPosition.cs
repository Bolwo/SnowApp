using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSPosition {

    public int Longitude;
    public int Latitude;
    public int Altitude;

    public GPSPosition(double longitude, double latitude, double altitude)
    {
        var accuracy = 1000000; //How accurate the data should be handled. Each 0 represents a decimal of accuracy. Recomended 6 zeros.
        Longitude = Convert.ToInt32(longitude * accuracy);
        Latitude = Convert.ToInt32(longitude * accuracy);
        Altitude = Convert.ToInt32(longitude * accuracy);
    }
}
